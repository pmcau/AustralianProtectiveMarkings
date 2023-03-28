namespace AustralianProtectiveMarkings;

public readonly record struct Caveats
{
    public IReadOnlyCollection<string>? CodewordCaveats { get; init; }
    public IReadOnlyCollection<string>? ForeignGovernmentCaveats { get; init; }
    public IReadOnlyCollection<CaveatType>? CaveatTypes { get; init; }
    public IReadOnlyCollection<string>? ExclusiveForCaveats { get; init; }
    public IReadOnlyCollection<CountryCode>? CountryCodeCaveats { get; init; }
}