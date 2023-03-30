//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

/// <summary>
/// 
/// </summary>
/// <param name="SecurityClassification">
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information
/// </param>
public readonly record struct ProtectiveMarking(SecurityClassification SecurityClassification)
{
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
        get => expiry;
        init
        {
            if (value == null)
            {
                return;
            }

            if (value.Value.DownTo >= SecurityClassification)
            {
                throw new($"Expiry DownTo `{value.Value.DownTo}` must be less than the SecurityClassification of the ProtectiveMarking `{SecurityClassification}`.");
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

    /// <summary>
    /// Is based on the Recordkeeping Metadata Standard's 'Rights' property.
    /// https://www.naa.gov.au/information-management/standards/australian-government-recordkeeping-metadata-standard
    /// While categorising information content by non-security sensitives is not mandated as a security requirement, the
    /// 'Rights' property provides an optional set of terms ensuring common understanding, consistency and interoperability
    /// across systems and government entities.
    /// </summary>
    /// <remarks>Maps to ACCESS</remarks>
    public IReadOnlyCollection<InformationManagementMarker>? InformationManagementMarkers { get; init; }

    readonly string? comment;
    /// <summary>
    /// Is a free-text field where the sender can specify some free-form information to include additional security
    /// classification information; the permitted characters are limited to those defined for `text` and has maximum
    /// length of 128 characters.
    /// </summary>
    /// <remarks>Maps to NOTE</remarks>
    public string? Comment
    {
        get => comment;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            comment = value;
        }
    }

    readonly string? authorEmail;
    /// <summary>
    /// Captures the author’s email address so that the person who originally classified the email message is always
    /// known. This is not necessarily the same as that in the RFC5322 From field.
    /// </summary>
    /// <remarks>Maps to ORIGIN</remarks>
    public string? AuthorEmail
    {
        get => authorEmail;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            authorEmail = value;
        }
    }
}