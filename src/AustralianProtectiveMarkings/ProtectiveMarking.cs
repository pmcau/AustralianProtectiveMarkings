//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public record struct ProtectiveMarking(SecurityClassification SecurityClassification)
{
    public IReadOnlyCollection<InformationManagementMarker> InformationManagementMarkers { get; init; }
    public string? Event { get; init; }
    public DateTimeOffset GenDate { get; init; }
    public Caveats? Caveats { get; init; }
}