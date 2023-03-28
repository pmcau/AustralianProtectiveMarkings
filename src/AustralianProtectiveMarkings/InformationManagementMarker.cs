namespace AustralianProtectiveMarkings;

/// <summary>
/// Is based on the Recordkeeping Metadata Standard's 'Rights' property.
/// https://www.naa.gov.au/information-management/standards/australian-government-recordkeeping-metadata-standard
/// While categorising information content by non-security sensitives is not mandated as a security requirement, the
/// 'Rights' property provides an optional set of terms ensuring common understanding, consistency and interoperability
/// across systems and government entities.
/// </summary>
public enum InformationManagementMarker
{
    PersonalPrivacy,
    LegalPrivilege,
    LegislativeSecrecy
}