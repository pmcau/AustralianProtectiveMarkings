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
    public static ProtectiveMarking ParseProtectiveMarking(CharSpan input)
    {
        if (TryParseClassification(input, out var classification))
        {
            return new(classification);
        }

        return ParseKeyValueMarking(input);
    }

    static ProtectiveMarking ParseKeyValueMarking(CharSpan input)
    {
        var pairs = ParseKeyValues(input);
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

    // Single source of truth for the classification set: the strict PSPF marking text used in SEC=/DOWNTO=
    // values (matched case-sensitively by ParseClassification) and the enum name accepted as a bare
    // classification (matched case-insensitively by TryParseClassification).
    static (Classification Classification, string Marking, string Name)[] classifications =
    [
        (Classification.Unofficial, "UNOFFICIAL", "Unofficial"),
        (Classification.Official, "OFFICIAL", "Official"),
        (Classification.OfficialSensitive, "OFFICIAL:Sensitive", "OfficialSensitive"),
        (Classification.Protected, "PROTECTED", "Protected"),
        (Classification.Secret, "SECRET", "Secret"),
        (Classification.TopSecret, "TOP-SECRET", "TopSecret")
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
    public static bool TryParseClassification(CharSpan input, out Classification classification)
    {
        // Trim and compare over spans (OrdinalIgnoreCase) to avoid allocating from Trim()/ToUpper().
        var trimmed = input.Trim();
        foreach (var (value, _, name) in classifications)
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

    static Expiry? ReadExpiry(CharSpan input, List<Pair> pairs)
    {
        var expiresItems = pairs
            .Where(_ => _.Key == "EXPIRES")
            .ToList();
        if (expiresItems.Count > 1)
        {
            throw new($"Only a single EXPIRES is allowed. Input: {input.ToString()}");
        }

        var downToItems = pairs
            .Where(_ => _.Key == "DOWNTO")
            .ToList();
        if (downToItems.Count > 1)
        {
            throw new($"Only a single DOWNTO is allowed. Input: {input.ToString()}");
        }

        if (downToItems.Count == 0 &&
            expiresItems.Count == 0)
        {
            return null;
        }

        if (downToItems.Count == 0 ||
            expiresItems.Count == 0)
        {
            throw new($"EXPIRES and DOWNTO cannot be defined without the other. Input: {input.ToString()}");
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

    static void ValidateOrder(CharSpan input, List<string> keys)
    {
        var ordered = keys
            .OrderBy(_ => order.IndexOf(_));
        if (ordered.SequenceEqual(keys))
        {
            return;
        }

        throw new(
            $"""
             Incorrect order.
             Order must be: {string.Join(", ", order)}.
             Order is: {string.Join(", ", keys)}.
             Input: {input.ToString()}
             """);
    }

    static Classification ReadClassification(CharSpan input, List<Pair> pairs)
    {
        var security = pairs
            .Where(_ => _.Key == "SEC")
            .ToList();
        if (security.Count != 1)
        {
            throw new($"A single security 'SEC' must be defined. Input: {input.ToString()}");
        }

        var value = security[0].Value;
        return ParseClassification(value);
    }

    static string? ReadAuthorEmail(CharSpan input, List<Pair> pairs)
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
            throw new($"Only one ORIGIN is allowed. Input: {input.ToString()}");
        }

        ThrowForDuplicates(input, origins, "ORIGIN");
        return origins[0].Value;
    }

    static string? ReadComment(CharSpan input, List<Pair> pairs)
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
            throw new($"Only one NOTE is allowed. Input: {input.ToString()}");
        }

        ThrowForDuplicates(input, notes, "NOTE");
        return notes[0].Value;
    }

    static void ThrowForDuplicates<T>(CharSpan input, List<T> items, string name)
    {
        if (items.Count != items
                .Distinct()
                .Count())
        {
            throw new($"Duplicates not allowed in '{name}'. Input: {input.ToString()}");
        }
    }

    // Strict PSPF marking text (case-sensitive), used for SEC=/DOWNTO= values.
    static Classification ParseClassification(string value)
    {
        foreach (var (classification, marking, _) in classifications)
        {
            if (marking == value)
            {
                return classification;
            }
        }

        throw new($"Unknown classification: {value}");
    }

    static void ValidateNamespace(CharSpan input, List<Pair> pairs)
    {
        var namespaces = pairs
            .Where(_ => _.Key == "NS")
            .ToList();
        if (namespaces.Count > 1)
        {
            throw new($"Only one namespace 'NS' allowed. Input: {input.ToString()}");
        }

        if (namespaces.Count == 1)
        {
            var value = namespaces[0];
            if (value.Value != "gov.au")
            {
                throw new($"Namespace 'NS' must be 'gov.au'. Input: {input.ToString()}");
            }
        }
    }

    static void ValidateVersion(CharSpan input, List<Pair> pairs)
    {
        var versions = pairs
            .Where(_ => _.Key == "VER")
            .ToList();
        if (versions.Count > 1)
        {
            throw new($"Only one version 'VER' allowed. Input: {input.ToString()}");
        }
    }
}
