namespace AustralianProtectiveMarkings;

public static partial class Parser
{
    enum State
    {
        EatWhitespace,
        Key,
        Value,
        Escape
    }

    internal record Pair(string Key, string Value);

    static List<string> order =
    [
        "VER",
        "NS",
        "SEC",
        "CAVEAT",
        "EXPIRES",
        "DOWNTO",
        "ACCESS",
        "NOTE",
        "ORIGIN"
    ];

    static bool AnyValue(this List<Pair> list, string value) =>
        list.Any(_ => _.Value == value);

    public static ProtectiveMarking ParseProtectiveMarking(string input) =>
        ParseProtectiveMarking(input.AsSpan());

    /// <summary>
    /// Parses a <see cref="ProtectiveMarking"/> from a bare classification name or an email-header-style
    /// key-value string. Allocation-free for the bare-classification case.
    /// </summary>
    public static ProtectiveMarking ParseProtectiveMarking(ReadOnlySpan<char> input)
    {
        if (TryParseClassification(input, out var classification))
        {
            return new(classification);
        }

        // The key-value parser operates on strings, so the non-bare path materialises the input once.
        return ParseKeyValueMarking(input.ToString());
    }

    static ProtectiveMarking ParseKeyValueMarking(string input)
    {
        var pairs = ParseKeyValues(input)
            .ToList();
        var keys = pairs
            .Select(_ => _.Key)
            .ToList();
        ValidateOrder(input, keys);
        ValidateVersion(input, pairs);
        ValidateNamespace(input, pairs);

        var access = pairs
            .Where(_ => _.Key == "ACCESS")
            .ToList();

        return new()
        {
            Classification = ReadClassification(input, pairs),
            Caveats = ReadCaveats(input, pairs),
            PersonalPrivacy = access.AnyValue("Personal-Privacy"),
            LegalPrivilege = access.AnyValue("Legal-Privilege"),
            LegislativeSecrecy = access.AnyValue("Legislative-Secrecy"),
            AuthorEmail = ReadAuthorEmail(input, pairs),
            Comment = ReadComment(input, pairs),
            Expiry = ReadExpiry(input, pairs)
        };
    }

    static (string Name, Classification Classification)[] classifications =
    [
        ("Unofficial", Classification.Unofficial),
        ("Official", Classification.Official),
        ("OfficialSensitive", Classification.OfficialSensitive),
        ("Protected", Classification.Protected),
        ("Secret", Classification.Secret),
        ("TopSecret", Classification.TopSecret)
    ];

    /// <summary>
    /// Strictly parses a bare <see cref="Classification"/> name (e.g. "Protected", "OfficialSensitive"),
    /// case-insensitively and ignoring surrounding whitespace. Unlike <c>Enum.TryParse</c> this rejects
    /// numeric input (e.g. "0"), comma/flag-combined input (e.g. "Official, Secret") and anything that is
    /// not exactly one of the defined classification names.
    /// </summary>
    public static bool TryParseClassification(string input, out Classification classification) =>
        TryParseClassification(input.AsSpan(), out classification);

    /// <inheritdoc cref="TryParseClassification(string, out Classification)"/>
    public static bool TryParseClassification(ReadOnlySpan<char> input, out Classification classification)
    {
        // Trim and compare over spans (OrdinalIgnoreCase) to avoid allocating from Trim()/ToUpper().
        var trimmed = input.Trim();
        foreach (var (name, value) in classifications)
        {
            if (trimmed.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                classification = value;
                return true;
            }
        }

        classification = default;
        return false;
    }

    static Expiry? ReadExpiry(string input, List<Pair> pairs)
    {
        var expiresItems = pairs
            .Where(_ => _.Key == "EXPIRES")
            .ToList();
        if (expiresItems.Count > 1)
        {
            throw new($"Only a single EXPIRES is allowed. Input: {input}");
        }

        var downToItems = pairs
            .Where(_ => _.Key == "DOWNTO")
            .ToList();
        if (downToItems.Count > 1)
        {
            throw new($"Only a single DOWNTO is allowed. Input: {input}");
        }

        if (downToItems.Count == 0 &&
            expiresItems.Count == 0)
        {
            return null;
        }

        if (downToItems.Count == 0 ||
            expiresItems.Count == 0)
        {
            throw new($"EXPIRES and DOWNTO cannot be defined without the other. Input: {input}");
        }

        var downTo = ParseClassification(downToItems[0].Value);
        var expires = expiresItems[0].Value;
        if (DateFormatter.TryParse(expires, out var date))
        {
            return new Expiry
            {
                DownTo = downTo,
                GenDate = date
            };
        }

        return new Expiry
        {
            DownTo = downTo,
            Event = expires
        };
    }

    static void ValidateOrder(string input, List<string> keys)
    {
        var ordered = keys
            .OrderBy(_ => order.IndexOf(_));
        if (ordered.SequenceEqual(keys))
        {
            return;
        }

        throw new($"""
                   Incorrect order.
                   Order must be: {string.Join(", ", order)}.
                   Order is: {string.Join(", ", keys)}.
                   Input: {input}
                   """);
    }

    static Classification ReadClassification(string input, List<Pair> pairs)
    {
        var security = pairs
            .Where(_ => _.Key == "SEC")
            .ToList();
        if (security.Count != 1)
        {
            throw new($"A single security 'SEC' must be defined. Input: {input}");
        }

        var value = security[0].Value;
        return ParseClassification(value);
    }

    static string? ReadAuthorEmail(string input, List<Pair> pairs)
    {
        var origins = pairs
            .Where(_ => _.Key == "ORIGIN")
            .ToList();
        if (origins.Count == 0)
        {
            return null;
        }

        if (origins.Count > 1)
        {
            throw new($"Only one ORIGIN is allowed. Input: {input}");
        }

        ThrowForDuplicates(input, origins, "ORIGIN");
        return origins[0].Value;
    }

    static string? ReadComment(string input, List<Pair> pairs)
    {
        var notes = pairs
            .Where(_ => _.Key == "NOTE")
            .ToList();
        if (notes.Count == 0)
        {
            return null;
        }

        if (notes.Count > 1)
        {
            throw new($"Only one NOTE is allowed. Input: {input}");
        }

        ThrowForDuplicates(input, notes, "NOTE");
        return notes[0].Value;
    }

    static void ThrowForDuplicates<T>(string input, List<T> items, string name)
    {
        if (items.Count != items
                .Distinct()
                .Count())
        {
            throw new($"Duplicates not allowed in '{name}'. Input: {input}");
        }
    }

    static Classification ParseClassification(string value) =>
        value switch
        {
            "TOP-SECRET" => Classification.TopSecret,
            "SECRET" => Classification.Secret,
            "PROTECTED" => Classification.Protected,
            "UNOFFICIAL" => Classification.Unofficial,
            "OFFICIAL" => Classification.Official,
            "OFFICIAL:Sensitive" => Classification.OfficialSensitive,
            _ => throw new($"Unknown classification: {value}")
        };

    static void ValidateNamespace(string input, List<Pair> pairs)
    {
        var namespaces = pairs
            .Where(_ => _.Key == "NS")
            .ToList();
        if (namespaces.Count > 1)
        {
            throw new($"Only one namespace 'NS' allowed. Input: {input}");
        }

        if (namespaces.Count == 1)
        {
            var value = namespaces[0];
            if (value.Value != "gov.au")
            {
                throw new($"Namespace 'NS' must be 'gov.au'. Input: {input}");
            }
        }
    }

    static void ValidateVersion(string input, List<Pair> pairs)
    {
        var versions = pairs
            .Where(_ => _.Key == "VER")
            .ToList();
        if (versions.Count > 1)
        {
            throw new($"Only one version 'VER' allowed. Input: {input}");
        }
    }
}