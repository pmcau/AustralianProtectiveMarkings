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
            GuardDuplicateCodewords();
            Codewords = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateCodewords()
    {
        if (Codewords != null)
        {
            throw new($"Use only {nameof(Codeword)} or {nameof(Codewords)}. Not both.");
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

    public string ForeignGovernmentCaveat
    {
        init
        {
            GuardDuplicateForeignGovernmentCaveats();
            ForeignGovernmentCaveats = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateForeignGovernmentCaveats()
    {
        if (ForeignGovernmentCaveats != null)
        {
            throw new($"Use only {nameof(ForeignGovernmentCaveat)} or {nameof(ForeignGovernmentCaveats)}. Not both.");
        }
    }

    public IReadOnlyCollection<CaveatType>? CaveatTypes { get; init; }


    public CaveatType CaveatType
    {
        init
        {
            GuardDuplicateCaveatTypes();
            CaveatTypes = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateCaveatTypes()
    {
        if (CaveatTypes != null)
        {
            throw new($"Use only {nameof(CaveatType)} or {nameof(CaveatTypes)}. Not both.");
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
            GuardDuplicateExclusiveFor();
            ExclusiveFors = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateExclusiveFor()
    {
        if (ExclusiveFors != null)
        {
            throw new($"Use only {nameof(ExclusiveFor)} or {nameof(ExclusiveFors)}. Not both.");
        }
    }

    public IReadOnlyCollection<CountryCode>? CountryCodeCaveats { get; init; }

    public CountryCode CountryCodeCaveat
    {
        init
        {
            GuardDuplicateCountryCodeCaveats();
            CountryCodeCaveats = new[]
            {
                value
            };
        }
    }

    void GuardDuplicateCountryCodeCaveats()
    {
        if (CountryCodeCaveats != null)
        {
            throw new($"Use only {nameof(CountryCodeCaveat)} or {nameof(CountryCodeCaveats)}. Not both.");
        }
    }
}