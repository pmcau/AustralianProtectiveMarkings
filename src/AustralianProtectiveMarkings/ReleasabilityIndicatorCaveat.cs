namespace AustralianProtectiveMarkings;

public record struct ReleasabilityIndicatorCaveat(
    ReleasabilityIndicatorCaveatType Type,
    IReadOnlyCollection<CountryCode>? CountryCodes = null)
{
    public static ReleasabilityIndicatorCaveat Agao() =>
        new(ReleasabilityIndicatorCaveatType.Agao);

    public static ReleasabilityIndicatorCaveat Austeo() =>
        new(ReleasabilityIndicatorCaveatType.Austeo);

    public static ReleasabilityIndicatorCaveat Rel(IReadOnlyCollection<CountryCode> countryCodes) =>
        new(ReleasabilityIndicatorCaveatType.Rel, countryCodes);

    public static ReleasabilityIndicatorCaveat Rel(CountryCode countryCode) =>
        new(ReleasabilityIndicatorCaveatType.Rel, new[] {countryCode});

    public static ReleasabilityIndicatorCaveat Rel(params CountryCode[] countryCodes) =>
        new(ReleasabilityIndicatorCaveatType.Rel, countryCodes);
}