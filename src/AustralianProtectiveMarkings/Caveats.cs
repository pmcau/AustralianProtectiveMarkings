namespace AustralianProtectiveMarkings;

public record struct Caveats(
    IReadOnlyCollection<string> Codeword,
    IReadOnlyCollection<string> ForeignGovernment,
    IReadOnlyCollection<CaveatType> CaveatTypes,
    IReadOnlyCollection<string> ExclusiveFor,
    IReadOnlyCollection<CountryCode> CountryCodes);
