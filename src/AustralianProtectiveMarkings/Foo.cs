//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public enum SecurityClassification
{
    Protected,
    Secret,
    TopSecret
}

public enum EmailSecurityClassification
{
    Protected,
    Secret,
    TopSecret,
    Unofficial,
    Official,
    OfficialSensitive
}