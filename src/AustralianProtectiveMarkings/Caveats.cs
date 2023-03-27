namespace AustralianProtectiveMarkings;

public record Caveats(
    IReadOnlyCollection<string> CodewordCaveats,
    IReadOnlyCollection<string> ForeignGovernmentCaveats,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandlingCaveats);