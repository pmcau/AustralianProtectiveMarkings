//https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf
namespace AustralianProtectiveMarkings;

public record ProtectiveMarking(SecurityClassification SecurityClassification)
{
    public InformationManagementMarker InformationManagementMarkers { get; init; }
    /// <summary>
    /// Permitted characters are limited to those defined for <text> and has maximum length of 128 characters.
    /// </summary>
    public string? Event { get; init; }
    public DateTimeOffset GenDate { get; init; }

    public Caveats? Caveats { get; init; }
}

public record Caveats(
    IReadOnlyCollection<string> CodewordCaveats,
    IReadOnlyCollection<string> ForeignGovernmentCaveats,
    IReadOnlyCollection<SpecialHandlingCaveat> SpecialHandlingCaveats);

/// <summary>
/// Corresponds to the PSPF policy: Sensitive and classified information10 and requires a security classification of PROTECTED or higher (with the exception of
/// the NATIONAL CABINET caveat, which can appear in conjunction with either the OFFICIAL: Sensitive marking or a security classification).
/// </summary>
public enum CaveatType
{
    // C
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    Codeword,
    // FG
    /// <summary>
    ///  Text and has maximum length of 128 characters.
    /// </summary>
    ForeignGovernment,
    // SH
    SpecialHandling,
    // RI
    ReleasabilityIndicator
}
public enum ReleasabilityIndicator
{
    // C
    AGAO,
    // FG
    AUSTEO,
    // SH
    SpecialHandling,
    // RI
    ReleasabilityIndicator
}

public enum CountryCode
{
    /// <summary>
/// Aruba - ABW
/// </summary>
Aruba,

/// <summary>
/// Afghanistan - AFG
/// </summary>
Afghanistan,

/// <summary>
/// Angola - AGO
/// </summary>
Angola,

/// <summary>
/// Anguilla - AIA
/// </summary>
Anguilla,

/// <summary>
/// Åland Islands - ALA
/// </summary>
ÅlandIslands,

/// <summary>
/// Albania - ALB
/// </summary>
Albania,

/// <summary>
/// Andorra - AND
/// </summary>
Andorra,

/// <summary>
/// United Arab Emirates - ARE
/// </summary>
UnitedArabEmirates,

/// <summary>
/// Argentina - ARG
/// </summary>
Argentina,

/// <summary>
/// Armenia - ARM
/// </summary>
Armenia,

/// <summary>
/// American Samoa - ASM
/// </summary>
AmericanSamoa,

/// <summary>
/// Antarctica - ATA
/// </summary>
Antarctica,

/// <summary>
/// French Southern Territories - ATF
/// </summary>
FrenchSouthernTerritories,

/// <summary>
/// Antigua and Barbuda - ATG
/// </summary>
AntiguaAndBarbuda,

/// <summary>
/// Australia - AUS
/// </summary>
Australia,

/// <summary>
/// Austria - AUT
/// </summary>
Austria,

/// <summary>
/// Azerbaijan - AZE
/// </summary>
Azerbaijan,

/// <summary>
/// Burundi - BDI
/// </summary>
Burundi,

/// <summary>
/// Belgium - BEL
/// </summary>
Belgium,

/// <summary>
/// Benin - BEN
/// </summary>
Benin,

/// <summary>
/// Caribbean Netherlands - BES
/// </summary>
CaribbeanNetherlands,

/// <summary>
/// Burkina Faso - BFA
/// </summary>
BurkinaFaso,

/// <summary>
/// Bangladesh - BGD
/// </summary>
Bangladesh,

/// <summary>
/// Bulgaria - BGR
/// </summary>
Bulgaria,

/// <summary>
/// Bahrain - BHR
/// </summary>
Bahrain,

/// <summary>
/// Bahamas - BHS
/// </summary>
Bahamas,

/// <summary>
/// Bosnia and Herzegovina - BIH
/// </summary>
BosniaAndHerzegovina,

/// <summary>
/// Saint Barthélemy - BLM
/// </summary>
SaintBarthélemy,

/// <summary>
/// Belarus - BLR
/// </summary>
Belarus,

/// <summary>
/// Belize - BLZ
/// </summary>
Belize,

/// <summary>
/// Bermuda - BMU
/// </summary>
Bermuda,

/// <summary>
/// Bolivia - BOL
/// </summary>
Bolivia,

/// <summary>
/// Brazil - BRA
/// </summary>
Brazil,

/// <summary>
/// Barbados - BRB
/// </summary>
Barbados,

/// <summary>
/// Brunei - BRN
/// </summary>
Brunei,

/// <summary>
/// Bhutan - BTN
/// </summary>
Bhutan,

/// <summary>
/// Bouvet Island - BVT
/// </summary>
BouvetIsland,

/// <summary>
/// Botswana - BWA
/// </summary>
Botswana,

/// <summary>
/// Central African Republic - CAF
/// </summary>
CentralAfricanRepublic,

/// <summary>
/// Canada - CAN
/// </summary>
Canada,

/// <summary>
/// CocosKeelingIslands - CCK
/// </summary>
CocosKeelingIslands,

/// <summary>
/// Switzerland - CHE
/// </summary>
Switzerland,

/// <summary>
/// Chile - CHL
/// </summary>
Chile,

/// <summary>
/// China - CHN
/// </summary>
China,

/// <summary>
/// Ivory Coast - CIV
/// </summary>
IvoryCoast,

/// <summary>
/// Cameroon - CMR
/// </summary>
Cameroon,

/// <summary>
/// Democratic Republic of the Congo - COD
/// </summary>
DemocraticRepublicOftheCongo,

/// <summary>
/// Republic of the Congo - COG
/// </summary>
RepublicOftheCongo,

/// <summary>
/// Cook Islands - COK
/// </summary>
CookIslands,

/// <summary>
/// Colombia - COL
/// </summary>
Colombia,

/// <summary>
/// Comoros - COM
/// </summary>
Comoros,

/// <summary>
/// Cabo Verde - CPV
/// </summary>
CaboVerde,

/// <summary>
/// Costa Rica - CRI
/// </summary>
CostaRica,

/// <summary>
/// Cuba - CUB
/// </summary>
Cuba,

/// <summary>
/// Curaçao - CUW
/// </summary>
Curaçao,

/// <summary>
/// Christmas Island - CXR
/// </summary>
ChristmasIsland,

/// <summary>
/// Cayman Islands - CYM
/// </summary>
CaymanIslands,

/// <summary>
/// Cyprus - CYP
/// </summary>
Cyprus,

/// <summary>
/// Czechia - CZE
/// </summary>
Czechia,

/// <summary>
/// Germany - DEU
/// </summary>
Germany,

/// <summary>
/// Djibouti - DJI
/// </summary>
Djibouti,

/// <summary>
/// Dominica - DMA
/// </summary>
Dominica,

/// <summary>
/// Denmark - DNK
/// </summary>
Denmark,

/// <summary>
/// Dominican Republic - DOM
/// </summary>
DominicanRepublic,

/// <summary>
/// Algeria - DZA
/// </summary>
Algeria,

/// <summary>
/// Ecuador - ECU
/// </summary>
Ecuador,

/// <summary>
/// Egypt - EGY
/// </summary>
Egypt,

/// <summary>
/// Eritrea - ERI
/// </summary>
Eritrea,

/// <summary>
/// Western Sahara - ESH
/// </summary>
WesternSahara,

/// <summary>
/// Spain - ESP
/// </summary>
Spain,

/// <summary>
/// Estonia - EST
/// </summary>
Estonia,

/// <summary>
/// Ethiopia - ETH
/// </summary>
Ethiopia,

/// <summary>
/// Finland - FIN
/// </summary>
Finland,

/// <summary>
/// Fiji - FJI
/// </summary>
Fiji,

/// <summary>
/// Falkland Islands - FLK
/// </summary>
FalklandIslands,

/// <summary>
/// France - FRA
/// </summary>
France,

/// <summary>
/// Faroe Islands - FRO
/// </summary>
FaroeIslands,

/// <summary>
/// Micronesia - FSM
/// </summary>
Micronesia,

/// <summary>
/// Gabon - GAB
/// </summary>
Gabon,

/// <summary>
/// United Kingdom - GBR
/// </summary>
UnitedKingdom,

/// <summary>
/// Georgia - GEO
/// </summary>
Georgia,

/// <summary>
/// Guernsey - GGY
/// </summary>
Guernsey,

/// <summary>
/// Ghana - GHA
/// </summary>
Ghana,

/// <summary>
/// Gibraltar - GIB
/// </summary>
Gibraltar,

/// <summary>
/// Guinea - GIN
/// </summary>
Guinea,

/// <summary>
/// Guadeloupe - GLP
/// </summary>
Guadeloupe,

/// <summary>
/// Gambia - GMB
/// </summary>
Gambia,

/// <summary>
/// Guinea-Bissau - GNB
/// </summary>
GuineaBissau,

/// <summary>
/// Equatorial Guinea - GNQ
/// </summary>
EquatorialGuinea,

/// <summary>
/// Greece - GRC
/// </summary>
Greece,

/// <summary>
/// Grenada - GRD
/// </summary>
Grenada,

/// <summary>
/// Greenland - GRL
/// </summary>
Greenland,

/// <summary>
/// Guatemala - GTM
/// </summary>
Guatemala,

/// <summary>
/// French Guiana - GUF
/// </summary>
FrenchGuiana,

/// <summary>
/// Guam - GUM
/// </summary>
Guam,

/// <summary>
/// Guyana - GUY
/// </summary>
Guyana,

/// <summary>
/// Hong Kong - HKG
/// </summary>
HongKong,

/// <summary>
/// Heard Island and McDonald Islands - HMD
/// </summary>
HeardIslandAndMcDonaldIslands,

/// <summary>
/// Honduras - HND
/// </summary>
Honduras,

/// <summary>
/// Croatia - HRV
/// </summary>
Croatia,

/// <summary>
/// Haiti - HTI
/// </summary>
Haiti,

/// <summary>
/// Hungary - HUN
/// </summary>
Hungary,

/// <summary>
/// Indonesia - IDN
/// </summary>
Indonesia,

/// <summary>
/// Isle of Man - IMN
/// </summary>
IsleOfMan,

/// <summary>
/// India - IND
/// </summary>
India,

/// <summary>
/// British Indian Ocean Territory - IOT
/// </summary>
BritishIndianOceanTerritory,

/// <summary>
/// Ireland - IRL
/// </summary>
Ireland,

/// <summary>
/// Iran) - IRN
/// </summary>
Iran,

/// <summary>
/// Iraq - IRQ
/// </summary>
Iraq,

/// <summary>
/// Iceland - ISL
/// </summary>
Iceland,

/// <summary>
/// Israel - ISR
/// </summary>
Israel,

/// <summary>
/// Italy - ITA
/// </summary>
Italy,

/// <summary>
/// Jamaica - JAM
/// </summary>
Jamaica,

/// <summary>
/// Jersey - JEY
/// </summary>
Jersey,

/// <summary>
/// Jordan - JOR
/// </summary>
Jordan,

/// <summary>
/// Japan - JPN
/// </summary>
Japan,

/// <summary>
/// Kazakhstan - KAZ
/// </summary>
Kazakhstan,

/// <summary>
/// Kenya - KEN
/// </summary>
Kenya,

/// <summary>
/// Kyrgyzstan - KGZ
/// </summary>
Kyrgyzstan,

/// <summary>
/// Cambodia - KHM
/// </summary>
Cambodia,

/// <summary>
/// Kiribati - KIR
/// </summary>
Kiribati,

/// <summary>
/// Saint Kitts and Nevis - KNA
/// </summary>
SaintKittsAndNevis,

/// <summary>
/// South Korea - KOR
/// </summary>
SouthKorea,

/// <summary>
/// Kuwait - KWT
/// </summary>
Kuwait,

/// <summary>
/// Laos - LAO
/// </summary>
Laos,

/// <summary>
/// Lebanon - LBN
/// </summary>
Lebanon,

/// <summary>
/// Liberia - LBR
/// </summary>
Liberia,

/// <summary>
/// Libya - LBY
/// </summary>
Libya,

/// <summary>
/// Saint Lucia - LCA
/// </summary>
SaintLucia,

/// <summary>
/// Liechtenstein - LIE
/// </summary>
Liechtenstein,

/// <summary>
/// Sri Lanka - LKA
/// </summary>
SriLanka,

/// <summary>
/// Lesotho - LSO
/// </summary>
Lesotho,

/// <summary>
/// Lithuania - LTU
/// </summary>
Lithuania,

/// <summary>
/// Luxembourg - LUX
/// </summary>
Luxembourg,

/// <summary>
/// Latvia - LVA
/// </summary>
Latvia,

/// <summary>
/// Macao - MAC
/// </summary>
Macao,

/// <summary>
/// Collectivity of Saint Martin - MAF
/// </summary>
CollectivityOfSaintMartin,

/// <summary>
/// Morocco - MAR
/// </summary>
Morocco,

/// <summary>
/// Monaco - MCO
/// </summary>
Monaco,

/// <summary>
/// Moldova - MDA
/// </summary>
Moldova,

/// <summary>
/// Madagascar - MDG
/// </summary>
Madagascar,

/// <summary>
/// Maldives - MDV
/// </summary>
Maldives,

/// <summary>
/// Mexico - MEX
/// </summary>
Mexico,

/// <summary>
/// Marshall Islands - MHL
/// </summary>
MarshallIslands,

/// <summary>
/// North Macedonia - MKD
/// </summary>
NorthMacedonia,

/// <summary>
/// Mali - MLI
/// </summary>
Mali,

/// <summary>
/// Malta - MLT
/// </summary>
Malta,

/// <summary>
/// Myanmar - MMR
/// </summary>
Myanmar,

/// <summary>
/// Montenegro - MNE
/// </summary>
Montenegro,

/// <summary>
/// Mongolia - MNG
/// </summary>
Mongolia,

/// <summary>
/// Northern Mariana Islands - MNP
/// </summary>
NorthernMarianaIslands,

/// <summary>
/// Mozambique - MOZ
/// </summary>
Mozambique,

/// <summary>
/// Mauritania - MRT
/// </summary>
Mauritania,

/// <summary>
/// Montserrat - MSR
/// </summary>
Montserrat,

/// <summary>
/// Martinique - MTQ
/// </summary>
Martinique,

/// <summary>
/// Mauritius - MUS
/// </summary>
Mauritius,

/// <summary>
/// Malawi - MWI
/// </summary>
Malawi,

/// <summary>
/// Malaysia - MYS
/// </summary>
Malaysia,

/// <summary>
/// Mayotte - MYT
/// </summary>
Mayotte,

/// <summary>
/// Namibia - NAM
/// </summary>
Namibia,

/// <summary>
/// New Caledonia - NCL
/// </summary>
NewCaledonia,

/// <summary>
/// Niger - NER
/// </summary>
Niger,

/// <summary>
/// Norfolk Island - NFK
/// </summary>
NorfolkIsland,

/// <summary>
/// Nigeria - NGA
/// </summary>
Nigeria,

/// <summary>
/// Nicaragua - NIC
/// </summary>
Nicaragua,

/// <summary>
/// Niue - NIU
/// </summary>
Niue,

/// <summary>
/// Netherlands - NLD
/// </summary>
Netherlands,

/// <summary>
/// Norway - NOR
/// </summary>
Norway,

/// <summary>
/// Nepal - NPL
/// </summary>
Nepal,

/// <summary>
/// Nauru - NRU
/// </summary>
Nauru,

/// <summary>
/// New Zealand - NZL
/// </summary>
NewZealand,

/// <summary>
/// Oman - OMN
/// </summary>
Oman,

/// <summary>
/// Pakistan - PAK
/// </summary>
Pakistan,

/// <summary>
/// Panama - PAN
/// </summary>
Panama,

/// <summary>
/// Pitcairn - PCN
/// </summary>
Pitcairn,

/// <summary>
/// Peru - PER
/// </summary>
Peru,

/// <summary>
/// Philippines - PHL
/// </summary>
Philippines,

/// <summary>
/// Palau - PLW
/// </summary>
Palau,

/// <summary>
/// Papua New Guinea - PNG
/// </summary>
PapuaNewGuinea,

/// <summary>
/// Poland - POL
/// </summary>
Poland,

/// <summary>
/// Puerto Rico - PRI
/// </summary>
PuertoRico,

/// <summary>
/// North Korea - PRK
/// </summary>
NorthKorea,

/// <summary>
/// Portugal - PRT
/// </summary>
Portugal,

/// <summary>
/// Paraguay - PRY
/// </summary>
Paraguay,

/// <summary>
/// Palestine - PSE
/// </summary>
Palestine,

/// <summary>
/// French Polynesia - PYF
/// </summary>
FrenchPolynesia,

/// <summary>
/// Qatar - QAT
/// </summary>
Qatar,

/// <summary>
/// Réunion - REU
/// </summary>
Réunion,

/// <summary>
/// Romania - ROU
/// </summary>
Romania,

/// <summary>
/// Russia - RUS
/// </summary>
Russia,

/// <summary>
/// Rwanda - RWA
/// </summary>
Rwanda,

/// <summary>
/// Saudi Arabia - SAU
/// </summary>
SaudiArabia,

/// <summary>
/// Sudan - SDN
/// </summary>
Sudan,

/// <summary>
/// Senegal - SEN
/// </summary>
Senegal,

/// <summary>
/// Singapore - SGP
/// </summary>
Singapore,

/// <summary>
/// South Georgia and the South Sandwich Islands - SGS
/// </summary>
SouthGeorgiaAndtheSouthSandwichIslands,

/// <summary>
/// Saint Helena, Ascension and Tristan da Cunha - SHN
/// </summary>
SaintHelena,AscensionAndTristandaCunha,

/// <summary>
/// Svalbard and Jan Mayen - SJM
/// </summary>
SvalbardAndJanMayen,

/// <summary>
/// Solomon Islands - SLB
/// </summary>
SolomonIslands,

/// <summary>
/// Sierra Leone - SLE
/// </summary>
SierraLeone,

/// <summary>
/// El Salvador - SLV
/// </summary>
ElSalvador,

/// <summary>
/// San Marino - SMR
/// </summary>
SanMarino,

/// <summary>
/// Somalia - SOM
/// </summary>
Somalia,

/// <summary>
/// Saint Pierre and Miquelon - SPM
/// </summary>
SaintPierreAndMiquelon,

/// <summary>
/// Serbia - SRB
/// </summary>
Serbia,

/// <summary>
/// South Sudan - SSD
/// </summary>
SouthSudan,

/// <summary>
/// São Tomé and Príncipe - STP
/// </summary>
SãoToméAndPríncipe,

/// <summary>
/// Suriname - SUR
/// </summary>
Suriname,

/// <summary>
/// Slovakia - SVK
/// </summary>
Slovakia,

/// <summary>
/// Slovenia - SVN
/// </summary>
Slovenia,

/// <summary>
/// Sweden - SWE
/// </summary>
Sweden,

/// <summary>
/// Eswatini - SWZ
/// </summary>
Eswatini,

/// <summary>
/// Sint Maarten - SXM
/// </summary>
SintMaarten,

/// <summary>
/// Seychelles - SYC
/// </summary>
Seychelles,

/// <summary>
/// Syria - SYR
/// </summary>
Syria,

/// <summary>
/// Turks and Caicos Islands - TCA
/// </summary>
TurksAndCaicosIslands,

/// <summary>
/// Chad - TCD
/// </summary>
Chad,

/// <summary>
/// Togo - TGO
/// </summary>
Togo,

/// <summary>
/// Thailand - THA
/// </summary>
Thailand,

/// <summary>
/// Tajikistan - TJK
/// </summary>
Tajikistan,

/// <summary>
/// Tokelau - TKL
/// </summary>
Tokelau,

/// <summary>
/// Turkmenistan - TKM
/// </summary>
Turkmenistan,

/// <summary>
/// Timor-Leste - TLS
/// </summary>
TimorLeste,

/// <summary>
/// Tonga - TON
/// </summary>
Tonga,

/// <summary>
/// Trinidad and Tobago - TTO
/// </summary>
TrinidadAndTobago,

/// <summary>
/// Tunisia - TUN
/// </summary>
Tunisia,

/// <summary>
/// Turkey - TUR
/// </summary>
Turkey,

/// <summary>
/// Tuvalu - TUV
/// </summary>
Tuvalu,

/// <summary>
/// Taiwan - TWN
/// </summary>
Taiwan,

/// <summary>
/// Tanzania - TZA
/// </summary>
Tanzania,

/// <summary>
/// Uganda - UGA
/// </summary>
Uganda,

/// <summary>
/// Ukraine - UKR
/// </summary>
Ukraine,

/// <summary>
/// United States Minor Outlying Islands - UMI
/// </summary>
UnitedStatesMinorOutlyingIslands,

/// <summary>
/// Uruguay - URY
/// </summary>
Uruguay,

/// <summary>
/// United States of America - USA
/// </summary>
UnitedStatesOfAmerica,

/// <summary>
/// Uzbekistan - UZB
/// </summary>
Uzbekistan,

/// <summary>
/// Vatican City - VAT
/// </summary>
VaticanCity,

/// <summary>
/// Saint Vincent and the Grenadines - VCT
/// </summary>
SaintVincentAndtheGrenadines,

/// <summary>
/// Venezuela - VEN
/// </summary>
Venezuela,

/// <summary>
/// British Virgin Islands - VGB
/// </summary>
BritishVirginIslands,

/// <summary>
/// United States Virgin Islands - VIR
/// </summary>
UnitedStatesVirginIslands,

/// <summary>
/// Viet Nam - VNM
/// </summary>
VietNam,

/// <summary>
/// Vanuatu - VUT
/// </summary>
Vanuatu,

/// <summary>
/// Wallis and Futuna - WLF
/// </summary>
WallisAndFutuna,

/// <summary>
/// Samoa - WSM
/// </summary>
Samoa,

/// <summary>
/// Yemen - YEM
/// </summary>
Yemen,

/// <summary>
/// South Africa - ZAF
/// </summary>
SouthAfrica,

/// <summary>
/// Zambia - ZMB
/// </summary>
Zambia,

/// <summary>
/// Zimbabwe - ZWE
/// </summary>
Zimbabwe,

}