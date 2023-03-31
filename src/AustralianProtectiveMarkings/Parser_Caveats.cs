namespace AustralianProtectiveMarkings;

public static partial class Parser
{
    static Caveats? ReadCaveats(string input, List<Pair> pairs)
    {
        if (TryReadCaveats(pairs, out var caveats))
        {
            return null;
        }

        var codeword = ReadCodeword(input, caveats);
        var foreignGovernmentCaveat = ReadForeignGovernmentCaveat(input, caveats);
        var isAgao = caveats.AnyValue("RI:AGAO");
        var isAusteo = caveats.AnyValue("RI:AUSTEO");
        var isDelicateSource = caveats.AnyValue("SH:DELICATE SOURCE");
        var isOrcon = caveats.AnyValue("SH:ORCON");
        var isCabinet = caveats.AnyValue("SH:CABINET");
        var isNationalCabinet = caveats.AnyValue("SH:NATIONAL-CABINET");
        var exclusiveFor = ReadExclusiveForCaveat(input, caveats);
        var countryCodes = ReadCountryCaveats(input, caveats);

        return new()
        {
            Agao = isAgao,
            Austeo = isAusteo,
            DelicateSource = isDelicateSource,
            Orcon = isOrcon,
            Cabinet = isCabinet,
            NationalCabinet = isNationalCabinet,
            Codeword = codeword,
            ForeignGovernment = foreignGovernmentCaveat,
            ExclusiveFor = exclusiveFor,
            CountryCodes = countryCodes,
        };
    }

    static string? ReadCodeword(string input, List<Pair> caveats)
    {
        var codewords = caveats
            .Select(_ => _.Value)
            .Where(_ => _.StartsWith("C:"))
            .ToList();
        if (codewords.Count == 0)
        {
            return null;
        }

        if (codewords.Count > 1)
        {
            throw new($"Only one codeword 'CAVEAT=C:' is allowed. Input: {input}");
        }

        ThrowForDuplicates(input, codewords, "CAVEAT=C:");
        return codewords[0][2..];
    }

    static string? ReadForeignGovernmentCaveat(string input, List<Pair> caveats)
    {
        var prefix = "FG:";
        var fgCaveats = caveats
            .Select(_ => _.Value)
            .Where(_ => _.StartsWith(prefix))
            .ToList();
        if (fgCaveats.Count == 0)
        {
            return null;
        }
        if (fgCaveats.Count > 1)
        {
            throw new($"Only one ForeignGovernment Caveat 'CAVEAT=FG:' is allowed. Input: {input}");
        }

        ThrowForDuplicates(input, fgCaveats, prefix);
        return fgCaveats[0][3..];
    }

    static List<Country>? ReadCountryCaveats(string input, List<Pair> caveats)
    {
        var prefix = "REL:";
        var countries = caveats
            .Select(_ => _.Value)
            .Where(_ => _.StartsWith(prefix))
            .ToList();
        if (countries.Count == 0)
        {
            return null;
        }

        ThrowForDuplicates(input, countries, prefix);
        var countryCodes = countries
            .SelectMany(_ => _[4..].Split('/'))
            .Select(CountryCodes.GetCodeForLetters)
            .ToList();
        ThrowForDuplicates(input, countryCodes, prefix);
        return countryCodes;
    }

    static string? ReadExclusiveForCaveat(string input, List<Pair> caveats)
    {
        var prefix = "SH:EXCLUSIVE-FOR";
        var exclusiveFors = caveats
            .Select(_ => _.Value)
            .Where(_ => _.StartsWith(prefix))
            .ToList();
        if (exclusiveFors.Count == 0)
        {
            return null;
        }
        if (exclusiveFors.Count > 1)
        {
            throw new($"Only one ExclusiveFors Caveat 'CAVEAT=SH:EXCLUSIVE-FOR' is allowed. Input: {input}");
        }

        ThrowForDuplicates(input, exclusiveFors, prefix);
        return exclusiveFors[0][prefix.Length..];
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