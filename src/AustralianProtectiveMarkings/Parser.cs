namespace AustralianProtectiveMarkings;

public static class Parser
{
    enum State
    {
        EatWhitespace,
        Key,
        Value,
        Escape
    }

    record Pair(string Key, string Value);

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

    public static ProtectiveMarking Parse(string input)
    {
        var pairs = ParseKeyValues(input).ToList();
        var keys = pairs.Select(_ => _.Key).ToList();
        ValidateOrder(input, keys);
        ValidateVersion(input, pairs);
        ValidateNamespace(input, pairs);

        return new()
        {
            SecurityClassification = ReadSecurity(input, pairs),
            CodewordCaveats = ReadCodewords(input, pairs),
            ForeignGovernmentCaveats = ReadForeignGovernmentCaveats(input, pairs),
            CaveatTypes = ReadCaveatTypes(input, pairs),
            ExclusiveForCaveats = ReadExclusiveForCaveats(input, pairs),
            CountryCodeCaveats = ReadCountryCaveats(input, pairs),
            InformationManagementMarkers = ReadInformationManagementMarkers(input, pairs),
            AuthorEmail = ReadAuthorEmail(input, pairs),
            Comment = ReadComment(input, pairs),
            Expiry = ReadExpiry(input, pairs)
        };
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
            throw new($@"Incorrect order.
Order must be: {string.Join(", ", order)}.
Order is: {string.Join(", ", keys)}.
Input: {input}");
        }
    }

    static SecurityClassification ReadSecurity(string input, List<Pair> pairs)
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

    static List<InformationManagementMarker>? ReadInformationManagementMarkers(string input, List<Pair> pairs)
    {
        var access = pairs.Where(_ => _.Key == "ACCESS").ToList();
        if (access.Count == 0)
        {
            return null;
        }

        var markers = access.Select(_ => ParseInformationManagementMarker(_.Value)).ToList();

        ThrowForDuplicates(input, markers, "ACCESS");
        return markers;
    }

    static InformationManagementMarker ParseInformationManagementMarker(string value) =>
        value switch
        {
            "Personal-Privacy" => InformationManagementMarker.PersonalPrivacy,
            "Legal-Privilege" => InformationManagementMarker.LegalPrivilege,
            "Legislative-Secrecy" => InformationManagementMarker.LegislativeSecrecy,
            _ => throw new($"Unknown ACCESS: {value}")
        };

    static List<string>? ReadCodewords(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var codewordCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith("C:")).ToList();
        if (codewordCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, codewordCaveats, "CAVEAT=C");
        return codewordCaveats.Select(_ => _.Substring(2)).ToList();
    }

    static List<CaveatType>? ReadCaveatTypes(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var caveatTypes = new List<CaveatType>();
        foreach (CaveatType caveatType in Enum.GetValues(typeof(CaveatType)))
        {
            var caveatTpeString = caveatType.Render();
            var codewordCaveats = caveats.Where(_ => _.Value == caveatTpeString).ToList();
            if (codewordCaveats.Count == 0)
            {
                continue;
            }

            if (codewordCaveats.Count > 1)
            {
                throw new($"Only one caveat of type '{caveatTpeString}' allowed. Input: {input}");
            }

            caveatTypes.Add(caveatType);
        }

        return caveatTypes;
    }

    static List<string>? ReadForeignGovernmentCaveats(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var prefix = "FG:";
        var fgCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith(prefix)).ToList();
        if (fgCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, fgCaveats, prefix);
        return fgCaveats.Select(_ => _.Substring(3)).ToList();
    }

    static List<CountryCode>? ReadCountryCaveats(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var prefix = "REL:";
        var countryCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith(prefix)).ToList();
        if (countryCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, countryCaveats, prefix);
        var countryCodes = countryCaveats
            .SelectMany(_ => _.Substring(4).Split('/'))
            .Select(CountryCodes.GetCodeForLetters)
            .ToList();
        ThrowForDuplicates(input, countryCodes, prefix);
        return countryCodes;
    }

    static List<string>? ReadExclusiveForCaveats(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var prefix = "SH:EXCLUSIVE-FOR";
        var exclusiveForCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith(prefix)).ToList();
        if (exclusiveForCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, exclusiveForCaveats, prefix);
        return exclusiveForCaveats.Select(_ => _.Substring(prefix.Length)).ToList();
    }

    static void ThrowForDuplicates<T>(string input, List<T> items, string name)
    {
        if (items.Count != items.Distinct().Count())
        {
            throw new($"Duplicates not allowed in '{name}'. Input: {input}");
        }
    }

    static bool TryReadCaveats(List<Pair> pairs, out List<Pair> caveats)
    {
        caveats = pairs.Where(_ => _.Key == "CAVEAT").ToList();
        if (caveats.Count == 0)
        {
            return true;
        }

        return false;
    }

    static SecurityClassification ParseClassification(string value) =>
        value switch
        {
            "TOP-SECRET" => SecurityClassification.TopSecret,
            "SECRET" => SecurityClassification.Secret,
            "PROTECTED" => SecurityClassification.Protected,
            "UNOFFICIAL" => SecurityClassification.Unofficial,
            "OFFICIAL" => SecurityClassification.Official,
            "OFFICIAL:Sensitive" => SecurityClassification.OfficialSensitive,
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

    static IEnumerable<Pair> ParseKeyValues(string input)
    {
        var state = State.Key;

        var keyBuilder = new StringBuilder();
        var valueBuilder = new StringBuilder();
        for (var index = 0; index < input.Length; index++)
        {
            var ch = input[index];
            switch (state)
            {
                case State.EatWhitespace:
                    if (ch is ' ' or '\n' or '\r')
                    {
                        continue;
                    }

                    ValidateKeyChar(input, ch);
                    keyBuilder.Append(ch);
                    state = State.Key;
                    continue;
                case State.Key:
                    if (ch == '=')
                    {
                        state = State.Value;
                        continue;
                    }

                    ValidateKeyChar(input, ch);
                    keyBuilder.Append(ch);
                    continue;
                case State.Value:
                    var isLast = index == input.Length - 1;
                    if (ch == ',' || isLast)
                    {
                        if (isLast)
                        {
                            valueBuilder.Append(ch);
                        }

                        var value = valueBuilder.ToString();
                        var key = keyBuilder.ToString();
                        ValidateValueWhiteSpace(input, value);
                        yield return new(key, value);
                        valueBuilder.Clear();
                        keyBuilder.Clear();
                        state = State.EatWhitespace;

                        if (isLast)
                        {
                            yield break;
                        }

                        continue;
                    }

                    if (ch == '\\')
                    {
                        state = State.Escape;
                        continue;
                    }

                    ValidateValueChar(input, ch);

                    valueBuilder.Append(ch);
                    continue;
                case State.Escape:
                    if (ch is not ('\\' or ',' or '=' or ':'))
                    {
                        valueBuilder.Append('\\');
                    }

                    valueBuilder.Append(ch);
                    state = State.Value;
                    continue;
            }
        }

        throw new($"Incorrect ending state. Input: {input}");
    }

    static void ValidateValueWhiteSpace(string input, string value)
    {
        if (value.EndsWith(' '))
        {
            throw new($"Trailing whitespace in value '{value}'. Input: {input}");
        }

        if (value.StartsWith(' '))
        {
            throw new($"Leading whitespace in value '{value}'. Input: {input}");
        }
    }

    static void ValidateValueChar(string input, char ch)
    {
        if (ch >= 32 && ch <= 44)
        {
            return;
        }

        if (ch >= 45 && ch <= 91)
        {
            return;
        }

        if (ch >= 93 && ch <= 126)
        {
            return;
        }

        throw new($"Character '{ch}' not allowed in value. Input: {input}");
    }

    static void ValidateKeyChar(string input, char ch)
    {
        if (!char.IsLetter(ch))
        {
            throw new($"Invalid character '{ch}' in key. Input: {input}");
        }
    }
}