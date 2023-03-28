namespace AustralianProtectiveMarkings;

public record struct Caveats(
    IReadOnlyCollection<string> Codeword,
    IReadOnlyCollection<string> ForeignGovernment,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandling,
    IReadOnlyCollection<ReleasabilityIndicatorCaveat> ReleasabilityIndicator);
