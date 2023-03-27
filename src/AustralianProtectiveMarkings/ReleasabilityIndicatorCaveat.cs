namespace AustralianProtectiveMarkings;

public record struct ReleasabilityIndicatorCaveat(
    ReleasabilityIndicatorCaveatType Type,
    CountryCodes? CountryCodes = null)
{
    public static ReleasabilityIndicatorCaveat Agao() =>
        new(ReleasabilityIndicatorCaveatType.Agao);

    public static ReleasabilityIndicatorCaveat Austeo() =>
        new(ReleasabilityIndicatorCaveatType.Austeo);

    public static ReleasabilityIndicatorCaveat Rel(CountryCodes countryCodes) =>
        new(ReleasabilityIndicatorCaveatType.Rel, countryCodes);
}