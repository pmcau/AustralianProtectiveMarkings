namespace AustralianProtectiveMarkings;

public static partial class Parser
{
    internal static IEnumerable<Pair> ParseKeyValues(string input)
    {
        input = input.Trim();
        var state = State.Key;

        var keyBuilder = new StringBuilder();
        var valueBuilder = new StringBuilder();
        for (var index = 0; index < input.Length; index++)
        {
            var ch = input[index];
            switch (state)
            {
                case State.EatWhitespace:
                    if (ch is ' ' or '	' or '\n' or '\r')
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

    static void ValidateKeyChar(string input, char ch)
    {
        if (!char.IsLetter(ch))
        {
            throw new($"Invalid character '{ch}' in key. Input: {input}");
        }
    }
}