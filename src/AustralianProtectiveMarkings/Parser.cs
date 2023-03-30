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

    static List<string> order = new()
    {
        "VER",
        "NS",
        "SEC",
        "CAVEAT",
        "EXPIRES",
        "DOWNTO",
        "ACCESS",
        "NOTE",
        "ORIGIN"
    };

    static bool AnyValue(this List<Pair> list, string value) =>
        list.Any(_ => _.Value == value);

    public static ProtectiveMarking Parse(string input)
    {
        var pairs = ParseKeyValues(input).ToList();
        var keys = pairs.Select(_ => _.Key).ToList();
        CheckForUnknownKeys(input, keys);
        ValidateOrder(input, keys);
        ValidateVersion(input, pairs);
        ValidateNamespace(input, pairs);

        var access = pairs.Where(_ => _.Key == "ACCESS").ToList();

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

    static void CheckForUnknownKeys(string input, List<string> keys)
    {
        foreach (var key in keys.Where(_ => !order.Contains(_)))
        {
            throw new($"Unknown key '{key}'. Input: {input}");
        }
    }

    static Expiry? ReadExpiry(string input, List<Pair> pairs)
    {
        var expiresItems = pairs.Where(_ => _.Key == "EXPIRES").ToList();
        if (expiresItems.Count > 1)
        {
            throw new($"Only a single EXPIRES is allowed. Input: {input}");
        }

        var downToItems = pairs.Where(_ => _.Key == "DOWNTO").ToList();
        if (downToItems.Count > 1)
        {
            throw new($"Only a single DOWNTO is allowed. Input: {input}");
        }

        if (downToItems.Count == 0 && expiresItems.Count == 0)
        {
            return null;
        }

        if (downToItems.Count == 0 || expiresItems.Count == 0)
        {
            throw new($"EXPIRES and DOWNTO cannot be deigned without the other. Input: {input}");
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
        var ordered = keys.OrderBy(_ => order.IndexOf(_)).ToList();
        if (!ordered.SequenceEqual(keys))
        {
            throw new($"""
                Incorrect order.
                Order must be: {string.Join(", ", order)}.
                Order is: {string.Join(", ", keys)}.
                Input: {input}
                """);
        }
    }

    static Classification ReadClassification(string input, List<Pair> pairs)
    {
        var security = pairs.Where(_ => _.Key == "SEC").ToList();
        if (security.Count != 1)
        {
            throw new($"A single security 'SEC' must be defined. Input: {input}");
        }

        var value = security[0].Value;
        return ParseClassification(value);
    }

    static string? ReadAuthorEmail(string input, List<Pair> pairs)
    {
        var origins = pairs.Where(_ => _.Key == "ORIGIN").ToList();
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
        var notes = pairs.Where(_ => _.Key == "NOTE").ToList();
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
        if (items.Count != items.Distinct().Count())
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
        var namespaces = pairs.Where(_ => _.Key == "NS").ToList();
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
        var versions = pairs.Where(_ => _.Key == "VER").ToList();
        if (versions.Count > 1)
        {
            throw new($"Only one version 'VER' allowed. Input: {input}");
        }
    }
}