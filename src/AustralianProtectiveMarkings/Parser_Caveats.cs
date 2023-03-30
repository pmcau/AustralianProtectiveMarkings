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
        var isAgao = caveats.Any(_ => _.Value == "RI:AGAO");
        var isAusteo = caveats.Any(_ => _.Value == "RI:AUSTEO");
        var isDelicateSource = caveats.Any(_ => _.Value == "SH:DELICATE SOURCE");
        var isOrcon = caveats.Any(_ => _.Value == "SH:ORCON");
        var isCabinet = caveats.Any(_ => _.Value == "SH:CABINET");
        var isNationalCabinet = caveats.Any(_ => _.Value == "SH:NATIONAL-CABINET");
        var exclusiveFors = ReadExclusiveForCaveats(input, caveats);
        var countryCodes = ReadCountryCaveats(input, caveats);

        return new()
        {
            Agao = isAgao,
            Austeo = isAusteo,
            DelicateSource = isDelicateSource,
            Orcon = isOrcon,
            Cabinet = isCabinet,
            NationalCabinet = isNationalCabinet,
            Codewords = codewords,
            ForeignGovernments = foreignGovernmentCaveats,
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