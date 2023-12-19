namespace AustralianProtectiveMarkings;

/// <summary>
/// Caveats are a warning that the information has special protections in addition to those indicated by the security
/// classification (or in the case of the NATIONAL CABINET caveat, a security classification or the OFFICIAL: Sensitive
/// marking).
/// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pdf#C.3
/// </summary>
public readonly record struct Caveats
{
    readonly string? codeword;

    /// <summary>
    /// Sensitive compartmented information.
    /// Maps to: CAVEAT=C code-word
    /// Use of codewords is primarily within the national security community. A codeword indicates that the information
    /// is of sufficient sensitivity that it requires protection in addition to that offered by a security
    /// classification.
    /// Each codeword identifies a special need-to-know compartment. A compartment is a mechanism for restricting
    /// access to information by defined individuals who have been ‘briefed’ on the particular sensitivities of that
    /// information and any special rules that may apply. The codeword is chosen so that its ordinary meaning is
    /// unrelated to the subject of the information.
    /// </summary>
    public string? Codeword
    {
        get => codeword;
        init
        {
            if (value != null)
            {
                TextValidator.Validate(value);
            }

            codeword = value;
        }
    }

    readonly string? foreignGovernment;

    /// <summary>
    /// Foreign government markings are applied to information created by Australian agencies from foreign source
    /// information.
    /// Maps to: CAVEAT=FG caveat-name
    /// https://www.protectivesecurity.gov.au/publications-library/policy-7-security-governance-international-sharing
    /// </summary>
    public string? ForeignGovernment
    {
        get => foreignGovernment;
        init
        {
            if (value != null)
            {
                TextValidator.Validate(value);
            }

            foreignGovernment = value;
        }
    }

    readonly string? exclusiveFor;

    /// <summary>
    /// Identifies information intended for access by a named recipient only.
    /// Maps to: CAVEAT=SH:EXCLUSIVE-FOR named-person>|indicator
    /// Access to EXCLUSIVE FOR information is limited to a named person, position title or designation.
    /// </summary>
    public string? ExclusiveFor
    {
        get => exclusiveFor;
        init
        {
            if (value != null)
            {
                TextValidator.Validate(value);
            }

            exclusiveFor = value;
        }
    }

    /// <summary>
    /// Releasability (REL) caveats
    /// Maps to: CAVEAT=RI:REL Code1/Code2...
    /// For example, REL AUS/CAN/GBR/NZL/USA means that the information may be passed to citizens of Australia, Canada,
    /// United Kingdom, New Zealand and the United States of America only
    /// </summary>
    public IReadOnlyCollection<Country>? CountryCodes { get; init; }

    public Country Country
    {
        init
        {
            GuardDuplicateCountryCodeUse();
            CountryCodes = [value];
        }
    }

    void GuardDuplicateCountryCodeUse()
    {
        if (CountryCodes != null)
        {
            throw new($"Use only {nameof(Country)} or {nameof(CountryCodes)}. Not both.");
        }
    }

    /// <summary>
    /// Indicates information that can only be accessed by appropriately cleared Australian citizens
    /// and appropriately cleared representatives of Five-Eyes Governments on exchange, secondment, long-term posting
    /// or attachment within the National Intelligence Community and the Department of Defence.
    /// Maps to: CAVEAT=RI:AGAO
    /// AGAO information must not be distributed to the Five Eyes foreign representative’s parent agency or government.
    /// AGAO information may not be shared with any other foreign nationals.
    /// Where appropriate, all entities may apply the AGAO caveat to classified information. However, entities other
    /// than members of the National Intelligence Community and the Department of Defence must handle AGAO material as
    /// if it were marked AUSTEO.
    /// </summary>
    public bool Agao { get; init; }

    /// <summary>
    /// Indicates only appropriately cleared Australian citizens can access the information.
    /// Additional citizenships do not preclude access.
    /// Maps to: CAVEAT=RI:AUSTEO
    /// Information marked AUSTEO is only passed to, or accessed by, Australian citizens. While a person who has dual
    /// Australian citizenship may be given AUSTEO-marked information, in no circumstance may the Australian citizenship
    /// requirement be waived.
    /// </summary>
    public bool Austeo { get; init; }

    /// <summary>
    /// Maps to: CAVEAT=SH:DELICATE SOURCE
    /// </summary>
    public bool DelicateSource { get; init; }

    /// <summary>
    /// Originator controlled.
    /// Maps to: CAVEAT=SH:ORCON
    /// </summary>
    public bool Orcon { get; init; }

    /// <summary>
    /// Identifies any information that:
    /// Maps to: CAVEAT=SH:CABINET
    /// a. is prepared for the purpose of informing the Cabinet
    /// b. reveals the decision and/or deliberations of the Cabinet
    /// c. is prepared by departments to brief their ministers on matters proposed for Cabinet consideration
    /// d. has been created for the purpose of informing a proposal to be considered by the Cabinet.
    /// The Cabinet Handbook specifies handling requirements for Cabinet documents. This includes applying a security
    /// classification of at least PROTECTED to all Cabinet documents and associated records.
    /// </summary>
    public bool Cabinet { get; init; }

    /// <summary>
    /// The NATIONAL CABINET caveat identifies any information that which has been specifically prepared for National
    /// Cabinet or its subcommittees.
    /// Maps to: CAVEAT=SH:NATIONAL-CABINET
    /// </summary>
    public bool NationalCabinet { get; init; }
}