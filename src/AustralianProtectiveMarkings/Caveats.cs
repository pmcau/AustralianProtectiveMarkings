namespace AustralianProtectiveMarkings;

/// <summary>
/// 
/// </summary>
/// <param name="SecurityClassification">
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information
/// </param>
public readonly record struct Caveats
{
    readonly IReadOnlyCollection<string>? codewords;
    public IReadOnlyCollection<string>? Codewords
    {
        get => codewords;
        init
        {
            TextValidator.Validate(value);
            codewords = value;
        }
    }

    public string Codeword
    {
        init
        {
            GuardDuplicateCodewordUse();
            Codewords = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateCodewordUse()
    {
        if (Codewords != null)
        {
            throw new($"Use only {nameof(Codeword)} or {nameof(Codewords)}. Not both.");
        }
    }

    readonly IReadOnlyCollection<string>? foreignGovernments;
    public IReadOnlyCollection<string>? ForeignGovernments
    {
        get => foreignGovernments;
        init
        {
            TextValidator.Validate(value);
            foreignGovernments = value;
        }
    }

    public string ForeignGovernment
    {
        init
        {
            GuardDuplicateForeignGovernmentUse();
            ForeignGovernments = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateForeignGovernmentUse()
    {
        if (ForeignGovernments != null)
        {
            throw new($"Use only {nameof(ForeignGovernment)} or {nameof(ForeignGovernments)}. Not both.");
        }
    }

    readonly IReadOnlyCollection<string>? exclusiveFors;
    public IReadOnlyCollection<string>? ExclusiveFors
    {
        get => exclusiveFors;
        init
        {
            TextValidator.Validate(value);
            exclusiveFors = value;
        }
    }

    public string ExclusiveFor
    {
        init
        {
            GuardDuplicateExclusiveForUse();
            ExclusiveFors = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateExclusiveForUse()
    {
        if (ExclusiveFors != null)
        {
            throw new($"Use only {nameof(ExclusiveFor)} or {nameof(ExclusiveFors)}. Not both.");
        }
    }

    public IReadOnlyCollection<Country>? CountryCodes { get; init; }

    public Country Country
    {
        init
        {
            GuardDuplicateCountryCodeUse();
            CountryCodes = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateCountryCodeUse()
    {
        if (CountryCodes != null)
        {
            throw new($"Use only {nameof(Country)} or {nameof(CountryCodes)}. Not both.");
        }
    }

    public bool Agao { get; init; }
    public bool Austeo { get; init; }
    public bool DelicateSource { get; init; }
    public bool Orcon { get; init; }
    public bool Cabinet { get; init; }
    public bool NationalCabinet { get; init; }
}