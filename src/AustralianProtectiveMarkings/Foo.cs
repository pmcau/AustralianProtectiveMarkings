//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public record ProtectiveMarking(SecurityClassification SecurityClassification)
{
    public InformationManagementMarker InformationManagementMarkers { get; init; }
    /// <summary>
    /// Permitted characters are limited to those defined for <text> and has maximum length of 128 characters.
    /// </summary>
    public string Event { get; init; }
    public DateTimeOffset GenDate { get; init; }
    public IReadOnlyCollection<ICaveat> Caveats { get; init; }
}

public interface ICaveat
{
}

public record Caveats(
    IReadOnlyCollection<string> CodewordCaveats,
    IReadOnlyCollection<string> ForeignGovernmentCaveats,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandlingCaveats);

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information10 and requires a security classification of PROTECTED or higher (with the exception of
/// the NATIONAL CABINET caveat, which can appear in conjunction with either the OFFICIAL: Sensitive marking or a security classification).
/// </summary>
public enum CaveatType
{
    // C
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    Codeword,
    // FG
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    ForeignGovernment,
    // SH
    SpecialHandling,
    // RI
    ReleasabilityIndicator
}
public enum ReleasabilityIndicator
{
    // C
    AGAO,
    // FG
    AUSTEO,
    // SH
    SpecialHandling,
    // RI
    ReleasabilityIndicator
}