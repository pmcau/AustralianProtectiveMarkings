namespace AustralianProtectiveMarkings;

public record struct SpecialHandlingCaveat(
    SpecialHandlingCaveatType Type,
    string? Value = null)
{
    public SpecialHandlingCaveat DelicateSource() =>
        new(SpecialHandlingCaveatType.DelicateSource);

    public SpecialHandlingCaveat Orcon() =>
        new(SpecialHandlingCaveatType.Orcon);

    public SpecialHandlingCaveat ExclusiveFor(string personOrIndicator) =>
        new(SpecialHandlingCaveatType.ExclusiveFor, personOrIndicator);

    public SpecialHandlingCaveat Cabinet() =>
        new(SpecialHandlingCaveatType.Cabinet);

    public SpecialHandlingCaveat Rel() =>
        new(SpecialHandlingCaveatType.NationalCabinet);
}