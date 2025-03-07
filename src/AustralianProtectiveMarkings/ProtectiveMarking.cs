﻿namespace AustralianProtectiveMarkings;

/// <summary>
/// Represents an Australian Protective Markings.
/// Designed to be serializer friendly.
/// </summary>
/// <param name="Classification">
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information
/// </param>
public readonly record struct ProtectiveMarking(Classification Classification)
{
    /// <summary>
    /// Caveats are a warning that the information has special protections in addition to those indicated by the security
    /// classification (or in the case of the NATIONAL CABINET caveat, a security classification or the OFFICIAL: Sensitive
    /// marking).
    /// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.3
    /// </summary>
    public Caveats? Caveats { get; init; }

    public Expiry? Expiry
    {
        get;
        init
        {
            if (value == null)
            {
                return;
            }

            var inner = value.Value;
            if (inner.DownTo >= Classification)
            {
                throw new($"Expiry DownTo `{inner.DownTo}` must be less than the Classification of the ProtectiveMarking `{Classification}`.");
            }

            var @event = inner.Event;
            var genDate = inner.GenDate;

            if (genDate == null && @event == null)
            {
                throw new("Either GenDate or Event must be defined");
            }

            if (genDate != null && @event != null)
            {
                throw new("GenDate and Event cannot be both defined");
            }

            field = value;
        }
    }

    /// <summary>
    /// The information is subject to legal professional privilege.
    /// Maps to: ACCESS=Personal-Privacy
    /// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.3
    /// </summary>
    public bool PersonalPrivacy { get; init; }

    /// <summary>
    /// The information is subject to one or more legislative secrecy provisions.
    /// Maps to: ACCESS=Legal-Privilege
    /// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.3
    /// </summary>
    public bool LegalPrivilege { get; init; }

    /// <summary>
    /// The information is personal information as defined in the Privacy Act 1988
    /// Maps to: ACCESS=Legislative-Secrecy
    /// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.3
    /// </summary>
    public bool LegislativeSecrecy { get; init; }

    /// <summary>
    /// Is a free-text field where the sender can specify some free-form information to include additional security
    /// classification information; the permitted characters are limited to those defined for `text` and has maximum
    /// length of 128 characters.
    /// Maps to: NOTE=The comment
    /// </summary>
    public string? Comment
    {
        get;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            field = value;
        }
    }

    /// <summary>
    /// Captures the author’s email address so that the person who originally classified the email message is always
    /// known. This is not necessarily the same as that in the RFC5322 From field.
    /// Maps to: ORIGIN=author-email
    /// </summary>
    public string? AuthorEmail
    {
        get;
        init
        {
            if (value == null)
            {
                return;
            }

            TextValidator.Validate(value);
            field = value;
        }
    }
}