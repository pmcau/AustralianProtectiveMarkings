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
        var keys = pairs.Select(_=>_.Key).ToList();
        ValidateOrder(input, keys);
        ValidateVersion(input, pairs);
        ValidateNamespace(input, pairs);

        var security = ReadSecurity(input, pairs);

        return new()
        {
            SecurityClassification = security
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

        var pair = security[0].Value;
        return ParseClassification(pair);
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
            _ => throw new ($"Unknown classification: {value}")
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
                throw new($"namespace 'NS' must be 'gov.au'. Input: {input}");
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
        State state = State.Key;

        var keyBuilder = new StringBuilder();
        var valueBuilder = new StringBuilder();
        for (var index = 0; index < input.Length; index++)
        {
            var ch = input[index];
            switch (state)
            {
                case State.EatWhitespace:
                    if (ch == ' ')
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
                    var isLast = index == input.Length-1;
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