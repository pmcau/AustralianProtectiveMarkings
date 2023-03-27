namespace AustralianProtectiveMarkings;

public record struct ReleasabilityIndicatorCaveat(
    ReleasabilityIndicatorCaveatType Type,
    CountryCodes? CountryCodes = null)
{
    public ReleasabilityIndicatorCaveat Agao() =>
        new(ReleasabilityIndicatorCaveatType.Agao);

    public ReleasabilityIndicatorCaveat Austeo() =>
        new(ReleasabilityIndicatorCaveatType.Austeo);

    public ReleasabilityIndicatorCaveat Rel(CountryCodes countryCodes) =>
        new(ReleasabilityIndicatorCaveatType.Rel, countryCodes);
}