namespace AustralianProtectiveMarkings;

public record SpecialHandlingCaveat(
    SpecialHandlingCaveatType Type,
    string? Value)
{
}
    public enum SpecialHandlingCaveatType
    {
        DelicateSource,
        // Originator control marking
        Orcon,
        ExclusiveFor,
        Cabinet,
        NationalCabinet,
    }

public record ReleasabilityIndicatorCaveat(
    ReleasabilityIndicatorCaveatType Type,
    string? Value = null)
{
    public ReleasabilityIndicatorCaveat Agao() => new(ReleasabilityIndicatorCaveatType.Agao);
    public ReleasabilityIndicatorCaveat Austeo() => new(ReleasabilityIndicatorCaveatType.Austeo);
    public ReleasabilityIndicatorCaveat Rel(string countryCode) => new(ReleasabilityIndicatorCaveatType.Rel, countryCode);
    public ReleasabilityIndicatorCaveat Rel(params string[] countryCodes) => new(ReleasabilityIndicatorCaveatType.Rel, MegeCountryCodes(countryCodes));
    public ReleasabilityIndicatorCaveat Rel(IEnumerable<string> countryCodes) => new(ReleasabilityIndicatorCaveatType.Rel, MegeCountryCodes(countryCodes));

    static string MegeCountryCodes(IEnumerable<string> countryCodes)
    {
        foreach (var countryCode in countryCodes)
        {
          //  ValidateCountryCode(countryCodes);
        }
        return string.Join('/', countryCodes);
    }
}
    public enum ReleasabilityIndicatorCaveatType
    {
        Agao,
        Austeo,
        Rel
    }
