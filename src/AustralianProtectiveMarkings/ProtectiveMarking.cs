//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public record struct ProtectiveMarking
{
    public required SecurityClassification SecurityClassification { get; init; }
    public Caveats? Caveats { get; init; }
    public Expiry? Expiry { get; init; }
    public IReadOnlyCollection<InformationManagementMarker>? InformationManagementMarkers { get; init; }
    public string? Note { get; init; }
    public string? Origin { get; init; }
}