namespace AustralianProtectiveMarkings;

public record struct Caveats(
    IReadOnlyCollection<string> Codeword,
    IReadOnlyCollection<string> ForeignGovernment,
    IReadOnlyCollection<ReleasabilityIndicatorCaveat> ReleasabilityIndicator,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandling);