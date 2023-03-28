//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public readonly record struct ProtectiveMarking
{
    readonly Expiry? expiry;
    public required SecurityClassification SecurityClassification { get; init; }
    public Caveats? Caveats { get; init; }

    public Expiry? Expiry
    {
        readonly get => expiry;
        init
        {
            if (value == null)
            {
                return;
            }

            var @event = value.Value.Event;
            var genDate = value.Value.GenDate;

            if (genDate == null && @event == null)
            {
                throw new("Either GenDate or Event must be defined");
            }

            if (genDate != null && @event != null)
            {
                throw new("GenDate and Event cannot be both defined");
            }

            expiry = value;
        }
    }

    public IReadOnlyCollection<InformationManagementMarker>? InformationManagementMarkers { get; init; }
    public string? Note { get; init; }
    public string? Origin { get; init; }
}