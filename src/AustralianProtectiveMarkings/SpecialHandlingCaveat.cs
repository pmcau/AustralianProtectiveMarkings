namespace AustralianProtectiveMarkings;

public record SpecialHandlingCaveat(
    SpecialHandlingCaveat.Types Type,
    string? Value)
{
}
    public enum SpecialHandlingCaveatType
    {
        DelicateSource,
        // Originator control marking
        Orcon,
        ExclusiveFor,
        Cabinet,
        NationalCabinet,
    }

public record ReleasabilityIndicatorCaveat(
    ReleasabilityIndicatorCaveatType Type,
    string? Value = null)
{
    public ReleasabilityIndicatorCaveat Agao() => new(ReleasabilityIndicatorCaveatType.Agao);
    public ReleasabilityIndicatorCaveat Austeo() => new(ReleasabilityIndicatorCaveatType.Austeo);
    public ReleasabilityIndicatorCaveat Rel(string countryCode) => new(ReleasabilityIndicatorCaveatType.Rel, countryCode);
    public ReleasabilityIndicatorCaveat Rel(params string[] countryCodes) => new(ReleasabilityIndicatorCaveatType.Rel, MegeCountryCodes(countryCodes));
    public ReleasabilityIndicatorCaveat Rel(IEnumerable<string> countryCodes) => new(ReleasabilityIndicatorCaveatType.Rel, MegeCountryCodes(countryCodes));

    static string MegeCountryCodes(IEnumerable<string> countryCodes)
    {
        foreach (var countryCode in countryCodes)
        {
            ValidateCountryCode(countryCodes);
        }
        return string.Join('/', countryCodes);
    }
}
    public enum ReleasabilityIndicatorCaveatType
    {
        Agao,
        Austeo,
        Rel
    }
https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3
public enum CountryCode
{
ABW
Aruba
AFG
Afghanistan
AGO
Angola
AIA
Anguilla
ALA
Åland Islands
ALB
Albania
AND
Andorra
ARE
United Arab Emirates
ARG
Argentina
ARM
Armenia
ASM
American Samoa
ATA
Antarctica]]
ATF
French Southern and Antarctic Lands|French Southern Territories
ATG
Antigua and Barbuda
AUS
Australia
AUT
Austria]]
AZE
Azerbaijan]]
BDI
Burundi]]
BEL
Belgium]]
BEN
Benin]]
BES
Caribbean Netherlands|Bonaire, Sint Eustatius and Saba]]
BFA
Burkina Faso]]
BGD
Bangladesh]]
BGR
Bulgaria]]
BHR
Bahrain]]
BHS
The Bahamas|Bahamas]]
BIH
Bosnia and Herzegovina]]
BLM
Saint Barthélemy]]
BLR
Belarus]]
BLZ
Belize]]
BMU
Bermuda]]
BOL
Bolivia|Bolivia (Plurinational State of)]]
BRA
Brazil]]
BRB
Barbados]]
BRN
Brunei|Brunei Darussalam]]
BTN
Bhutan]]
BVT
Bouvet Island]]
BWA
Botswana]]
CAF
Central African Republic]]
CAN
Canada]]
CCK
Cocos (Keeling) Islands]]
CHE
Switzerland]]
CHL
Chile]]
CHN
China]]
CIV
Ivory Coast|Côte d'Ivoire]]
CMR
Cameroon]]
COD
Democratic Republic of the Congo|Congo, Democratic Republic of the]]
COG
Republic of the Congo|Congo]]
COK
Cook Islands]]
COL
Colombia]]
COM
Comoros]]
CPV
Cabo Verde]]
CRI
Costa Rica]]
CUB
Cuba]]
CUW
Curaçao]]
CXR
Christmas Island]]
CYM
Cayman Islands]]
CYP
Cyprus]]
CZE
Czechia]]
DEU
Germany]]
DJI
Djibouti]]
DMA
Dominica]]
DNK
Denmark]]
DOM
Dominican Republic]]
DZA
Algeria]]
ECU
Ecuador]]
EGY
Egypt]]
ERI
Eritrea]]
ESH
Western Sahara]]
ESP
Spain]]
EST
Estonia]]
ETH
Ethiopia]]
FIN
Finland]]
FJI
Fiji]]
FLK
Falkland Islands|Falkland Islands (Malvinas)]]
FRA
France]]
FRO
Faroe Islands]]
FSM
Federated States of Micronesia|Micronesia (Federated States of)]]
GAB
Gabon]]
GBR
United Kingdom|United Kingdom of Great Britain and Northern Ireland]]
GEO
Georgia (country)|Georgia]]
GGY
Bailiwick of Guernsey|Guernsey]]
GHA
Ghana]]
GIB
Gibraltar]]
GIN
Guinea]]
GLP
Guadeloupe]]
GMB
The Gambia|Gambia]]
GNB
Guinea-Bissau]]
GNQ
Equatorial Guinea]]
GRC
Greece]]
GRD
Grenada]]
GRL
Greenland]]
GTM
Guatemala]]
GUF
French Guiana]]
GUM
Guam]]
GUY
Guyana]]
HKG
Hong Kong]]
HMD
Heard Island and McDonald Islands]]
HND
Honduras]]
HRV
Croatia]]
HTI
Haiti]]
HUN
Hungary]]
IDN
Indonesia]]
IMN
Isle of Man]]
IND
India]]
IOT
British Indian Ocean Territory]]
IRL
Republic of Ireland|Ireland]]
IRN
Iran|Iran (Islamic Republic of)]]
IRQ
Iraq]]
ISL
Iceland]]
ISR
Israel]]
ITA
Italy]]
JAM
Jamaica]]
JEY
Jersey]]
JOR
Jordan]]
JPN
Japan]]
KAZ
Kazakhstan]]
KEN
Kenya]]
KGZ
Kyrgyzstan]]
KHM
Cambodia]]
KIR
Kiribati]]
KNA
Saint Kitts and Nevis]]
KOR
South Korea|Korea, Republic of]]
KWT
Kuwait]]
LAO
Laos|Lao People's Democratic Republic]]
LBN
Lebanon]]
LBR
Liberia]]
LBY
Libya]]
LCA
Saint Lucia]]
LIE
Liechtenstein]]
LKA
Sri Lanka]]
LSO
Lesotho]]
LTU
Lithuania]]
LUX
Luxembourg]]
LVA
Latvia]]
MAC
Macau|Macao]]
MAF
Collectivity of Saint Martin|Saint Martin (French part)]]
MAR
Morocco]]
MCO
Monaco]]
MDA
Moldova|Moldova, Republic of]]
MDG
Madagascar]]
MDV
Maldives]]
MEX
Mexico]]
MHL
Marshall Islands]]
MKD
North Macedonia]]
MLI
Mali]]
MLT
Malta]]
MMR
Myanmar]]
MNE
Montenegro]]
MNG
Mongolia]]
MNP
Northern Mariana Islands]]
MOZ
Mozambique]]
MRT
Mauritania]]
MSR
Montserrat]]
MTQ
Martinique]]
MUS
Mauritius]]
MWI
Malawi]]
MYS
Malaysia]]
MYT
Mayotte]]
NAM
Namibia]]
NCL
New Caledonia]]
NER
Niger]]
NFK
Norfolk Island]]
NGA
Nigeria]]
NIC
Nicaragua]]
NIU
Niue]]
NLD
Netherlands]]
NOR
Norway]]
NPL
Nepal]]
NRU
Nauru]]
NZL
New Zealand]]
OMN
Oman]]
PAK
Pakistan]]
PAN
Panama]]
PCN
Pitcairn Islands|Pitcairn]]
PER
Peru]]
PHL
Philippines]]
PLW
Palau]]
PNG
Papua New Guinea]]
POL
Poland]]
PRI
Puerto Rico]]
PRK
North Korea|Korea (Democratic People's Republic of)]]
PRT
Portugal]]
PRY
Paraguay]]
PSE
State of Palestine|Palestine, State of]]
PYF
French Polynesia]]
QAT
Qatar]]
REU
Réunion]]
ROU
Romania]]
RUS
Russia|Russian Federation]]
RWA
Rwanda]]
SAU
Saudi Arabia]]
SDN
Sudan]]
SEN
Senegal]]
SGP
Singapore]]
SGS
South Georgia and the South Sandwich Islands]]
SHN
Saint Helena, Ascension and Tristan da Cunha]]
SJM
Svalbard and Jan Mayen]]
SLB
Solomon Islands]]
SLE
Sierra Leone]]
SLV
El Salvador]]
SMR
San Marino]]
SOM
Somalia]]
SPM
Saint Pierre and Miquelon]]
SRB
Serbia]]
SSD
South Sudan]]
STP
São Tomé and Príncipe|{{sic|Sao Tome and Principe|hide=y}}]]
SUR
Suriname]]
SVK
Slovakia]]
SVN
Slovenia]]
SWE
Sweden]]
SWZ
Eswatini]]
SXM
Sint Maarten|Sint Maarten (Dutch part)]]
SYC
Seychelles]]
SYR
Syria|Syrian Arab Republic]]
TCA
Turks and Caicos Islands]]
TCD
Chad]]
TGO
Togo]]
THA
Thailand]]
TJK
Tajikistan]]
TKL
Tokelau]]
TKM
Turkmenistan]]
TLS
East Timor|Timor-Leste]]
TON
Tonga]]
TTO
Trinidad and Tobago]]
TUN
Tunisia]]
TUR
Turkey|Türkiye]]
TUV
Tuvalu]]
TWN
Taiwan]], [[Taiwan, Province of China|<!--DO NOT CHANGE-->Province of China<!--The United Nations considers Taiwan as part of the People's Republic of China, so "Taiwan, Province of China" is the country name used in ISO 3166: https://www.iso.org/obp/ui/#iso:code:3166:TW -->]]
TZA
Tanzania|Tanzania, United Republic of]]
UGA
Uganda]]
UKR
Ukraine]]
UMI
United States Minor Outlying Islands]]
URY
Uruguay]]
USA
United States|United States of America]]
UZB
Uzbekistan]]
VAT
Vatican City|Holy See]]
VCT
Saint Vincent and the Grenadines]]
VEN
Venezuela|Venezuela (Bolivarian Republic of)]]
VGB
British Virgin Islands|Virgin Islands (British)]]
VIR
United States Virgin Islands|Virgin Islands (U.S.)]]
VNM
Vietnam|<!--DO NOT CHANGE-->Viet Nam<!--"Viet Nam" is the country name used in ISO 3166: https://www.iso.org/obp/ui/#iso:code:3166:VN -->]]
VUT
Vanuatu]]
WLF
Wallis and Futuna]]
WSM
Samoa]]
YEM
Yemen]]
ZAF
South Africa]]
ZMB
Zambia]]
ZWE
Zimbabwe]]
}