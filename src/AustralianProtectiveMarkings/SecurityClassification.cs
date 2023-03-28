namespace AustralianProtectiveMarkings;

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information
/// </summary>
public enum SecurityClassification
{
    Unofficial,
    Official,
    OfficialSensitive,
    Protected,
    Secret,
    TopSecret,
}