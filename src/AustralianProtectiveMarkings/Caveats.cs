namespace AustralianProtectiveMarkings;

public record struct Caveats(
    IReadOnlyCollection<string> CodewordCaveats,
    IReadOnlyCollection<string> ForeignGovernmentCaveats,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandlingCaveats);