//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public readonly record struct ProtectiveMarking
{
    public required SecurityClassification SecurityClassification { get; init; }

    readonly IReadOnlyCollection<string>? codewordCaveats;
    public IReadOnlyCollection<string>? CodewordCaveats
    {
        get => codewordCaveats;
        init
        {
            TextValidator.Validate(value);
            codewordCaveats = value;
        }
    }

    readonly IReadOnlyCollection<string>? foreignGovernmentCaveats;
    public IReadOnlyCollection<string>? ForeignGovernmentCaveats
    {
        get => foreignGovernmentCaveats;
        init
        {
            TextValidator.Validate(value);
            foreignGovernmentCaveats = value;
        }
    }

    public IReadOnlyCollection<CaveatType>? CaveatTypes { get; init; }

    readonly IReadOnlyCollection<string>? exclusiveForCaveats;
    public IReadOnlyCollection<string>? ExclusiveForCaveats
    {
        get => exclusiveForCaveats;
        init
        {
            TextValidator.Validate(value);
            exclusiveForCaveats = value;
        }
    }

    public IReadOnlyCollection<CountryCode>? CountryCodeCaveats { get; init; }

    readonly Expiry? expiry;
    public Expiry? Expiry
    {
        readonly get => expiry;
        init
        {
            if (value == null)
            {
                return;
            }

            if (value.Value.DownTo >= SecurityClassification)
            {
                throw new($"Expiry DownTo {value.Value.DownTo} must be less than the SecurityClassification or the ProtectiveMarking {SecurityClassification}.");
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

    readonly string? note;

    public string? Note
    {
        get => note;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            note = value;
        }
    }

    readonly string? origin;
    public string? Origin
    {
        get => origin;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            origin = value;
        }
    }
}