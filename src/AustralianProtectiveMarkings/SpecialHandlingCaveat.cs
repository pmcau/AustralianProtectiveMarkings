namespace AustralianProtectiveMarkings;

public record struct SpecialHandlingCaveat(
    SpecialHandlingCaveatType Type,
    string? Value = null)
{
}