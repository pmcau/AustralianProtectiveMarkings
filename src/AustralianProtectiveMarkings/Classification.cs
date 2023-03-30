namespace AustralianProtectiveMarkings;

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// 
/// https://www.protectivesecurity.gov.au/system/files/2023-01/pspf-policy-08-sensitive-and-classified-information.pdf#C.2
/// </summary>
public enum Classification
{
    Unofficial,
    Official,
    OfficialSensitive,
    Protected,
    Secret,
    TopSecret,
}