namespace AustralianProtectiveMarkings;

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information’s classifications.
/// https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.2
/// </summary>
public enum Classification
{
    Unofficial,
    Official,
    OfficialSensitive,
    Protected,
    Secret,
    TopSecret
}