namespace AustralianProtectiveMarkings;

public static partial class Parser
{
    static Caveats? ReadCaveats(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }
        var codewords = ReadCodewords(input, caveats);
        var foreignGovernmentCaveats = ReadForeignGovernmentCaveats(input, caveats);
        var caveatTypes = ReadCaveatTypes(input, caveats);
        var exclusiveFors = ReadExclusiveForCaveats(input, caveats);
        var countryCodes = ReadCountryCaveats(input, caveats);
        if (codewords == null &&
            foreignGovernmentCaveats == null &&
            caveatTypes == null &&
            exclusiveFors == null &&
            countryCodes == null)
        {
            return null;
        }

        return new()
        {
            Codewords = codewords,
            ForeignGovernments = foreignGovernmentCaveats,
            CaveatTypes = caveatTypes,
            ExclusiveFors = exclusiveFors,
            CountryCodes = countryCodes,
        };
    }

    static List<string>? ReadCodewords(string input, List<Pair> caveats)
    {
        var codewordCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith("C:")).ToList();
        if (codewordCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, codewordCaveats, "CAVEAT=C");
        return codewordCaveats.Select(_ => _.Substring(2)).ToList();
    }

    static List<CaveatType>? ReadCaveatTypes(string input, List<Pair> caveats)
    {
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

    static List<string>? ReadForeignGovernmentCaveats(string input, List<Pair> caveats)
    {
        var prefix = "FG:";
        var fgCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith(prefix)).ToList();
        if (fgCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, fgCaveats, prefix);
        return fgCaveats.Select(_ => _.Substring(3)).ToList();
    }

    static List<CountryCode>? ReadCountryCaveats(string input, List<Pair> caveats)
    {
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

    static List<string>? ReadExclusiveForCaveats(string input, List<Pair> caveats)
    {
        var prefix = "SH:EXCLUSIVE-FOR";
        var exclusiveForCaveats = caveats.Select(_ => _.Value).Where(_ => _.StartsWith(prefix)).ToList();
        if (exclusiveForCaveats.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, exclusiveForCaveats, prefix);
        return exclusiveForCaveats.Select(_ => _.Substring(prefix.Length)).ToList();
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
}