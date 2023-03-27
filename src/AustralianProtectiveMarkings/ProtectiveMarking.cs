//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public record ProtectiveMarking(SecurityClassification SecurityClassification)
{
    public InformationManagementMarker InformationManagementMarkers { get; init; }
    /// <summary>
    /// Permitted characters are limited to those defined for <text> and has maximum length of 128 characters.
    /// </summary>
    public string? Event { get; init; }
    public DateTimeOffset GenDate { get; init; }
    public Caveats? Caveats { get; init; }
}