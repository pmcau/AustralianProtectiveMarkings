namespace AustralianProtectiveMarkings;

public record struct SpecialHandlingCaveat(
    SpecialHandlingCaveatType Type,
    string? Value = null)
{
    public static SpecialHandlingCaveat DelicateSource() =>
        new(SpecialHandlingCaveatType.DelicateSource);

    public static SpecialHandlingCaveat Orcon() =>
        new(SpecialHandlingCaveatType.Orcon);

    public static SpecialHandlingCaveat ExclusiveFor(string personOrIndicator) =>
        new(SpecialHandlingCaveatType.ExclusiveFor, personOrIndicator);

    public static SpecialHandlingCaveat Cabinet() =>
        new(SpecialHandlingCaveatType.Cabinet);

    public static SpecialHandlingCaveat Rel() =>
        new(SpecialHandlingCaveatType.NationalCabinet);
}