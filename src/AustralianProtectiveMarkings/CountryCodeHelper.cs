namespace AustralianProtectiveMarkings;

public class CountryCodeHelper
{
    static Dictionary<string, CountryCodes> lettersToCode = new()
    {
        {
            "ABW", CountryCodes.Aruba
        },
        {
            "AFG", CountryCodes.Afghanistan
        },
        {
            "AGO", CountryCodes.Angola
        },
        {
            "AIA", CountryCodes.Anguilla
        },
        {
            "ALA", CountryCodes.ÅlandIslands
        },
        {
            "ALB", CountryCodes.Albania
        },
        {
            "AND", CountryCodes.Andorra
        },
        {
            "ARE", CountryCodes.UnitedArabEmirates
        },
        {
            "ARG", CountryCodes.Argentina
        },
        {
            "ARM", CountryCodes.Armenia
        },
        {
            "ASM", CountryCodes.AmericanSamoa
        },
        {
            "ATA", CountryCodes.Antarctica
        },
        {
            "ATF", CountryCodes.FrenchSouthernTerritories
        },
        {
            "ATG", CountryCodes.AntiguaAndBarbuda
        },
        {
            "AUS", CountryCodes.Australia
        },
        {
            "AUT", CountryCodes.Austria
        },
        {
            "AZE", CountryCodes.Azerbaijan
        },
        {
            "BDI", CountryCodes.Burundi
        },
        {
            "BEL", CountryCodes.Belgium
        },
        {
            "BEN", CountryCodes.Benin
        },
        {
            "BES", CountryCodes.CaribbeanNetherlands
        },
        {
            "BFA", CountryCodes.BurkinaFaso
        },
        {
            "BGD", CountryCodes.Bangladesh
        },
        {
            "BGR", CountryCodes.Bulgaria
        },
        {
            "BHR", CountryCodes.Bahrain
        },
        {
            "BHS", CountryCodes.Bahamas
        },
        {
            "BIH", CountryCodes.BosniaAndHerzegovina
        },
        {
            "BLM", CountryCodes.SaintBarthélemy
        },
        {
            "BLR", CountryCodes.Belarus
        },
        {
            "BLZ", CountryCodes.Belize
        },
        {
            "BMU", CountryCodes.Bermuda
        },
        {
            "BOL", CountryCodes.Bolivia
        },
        {
            "BRA", CountryCodes.Brazil
        },
        {
            "BRB", CountryCodes.Barbados
        },
        {
            "BRN", CountryCodes.Brunei
        },
        {
            "BTN", CountryCodes.Bhutan
        },
        {
            "BVT", CountryCodes.BouvetIsland
        },
        {
            "BWA", CountryCodes.Botswana
        },
        {
            "CAF", CountryCodes.CentralAfricanRepublic
        },
        {
            "CAN", CountryCodes.Canada
        },
        {
            "CCK", CountryCodes.CocosKeelingIslands
        },
        {
            "CHE", CountryCodes.Switzerland
        },
        {
            "CHL", CountryCodes.Chile
        },
        {
            "CHN", CountryCodes.China
        },
        {
            "CIV", CountryCodes.IvoryCoast
        },
        {
            "CMR", CountryCodes.Cameroon
        },
        {
            "COD", CountryCodes.DemocraticRepublicOfTheCongo
        },
        {
            "COG", CountryCodes.RepublicOfTheCongo
        },
        {
            "COK", CountryCodes.CookIslands
        },
        {
            "COL", CountryCodes.Colombia
        },
        {
            "COM", CountryCodes.Comoros
        },
        {
            "CPV", CountryCodes.CaboVerde
        },
        {
            "CRI", CountryCodes.CostaRica
        },
        {
            "CUB", CountryCodes.Cuba
        },
        {
            "CUW", CountryCodes.Curaçao
        },
        {
            "CXR", CountryCodes.ChristmasIsland
        },
        {
            "CYM", CountryCodes.CaymanIslands
        },
        {
            "CYP", CountryCodes.Cyprus
        },
        {
            "CZE", CountryCodes.Czechia
        },
        {
            "DEU", CountryCodes.Germany
        },
        {
            "DJI", CountryCodes.Djibouti
        },
        {
            "DMA", CountryCodes.Dominica
        },
        {
            "DNK", CountryCodes.Denmark
        },
        {
            "DOM", CountryCodes.DominicanRepublic
        },
        {
            "DZA", CountryCodes.Algeria
        },
        {
            "ECU", CountryCodes.Ecuador
        },
        {
            "EGY", CountryCodes.Egypt
        },
        {
            "ERI", CountryCodes.Eritrea
        },
        {
            "ESH", CountryCodes.WesternSahara
        },
        {
            "ESP", CountryCodes.Spain
        },
        {
            "EST", CountryCodes.Estonia
        },
        {
            "ETH", CountryCodes.Ethiopia
        },
        {
            "FIN", CountryCodes.Finland
        },
        {
            "FJI", CountryCodes.Fiji
        },
        {
            "FLK", CountryCodes.FalklandIslands
        },
        {
            "FRA", CountryCodes.France
        },
        {
            "FRO", CountryCodes.FaroeIslands
        },
        {
            "FSM", CountryCodes.Micronesia
        },
        {
            "GAB", CountryCodes.Gabon
        },
        {
            "GBR", CountryCodes.UnitedKingdom
        },
        {
            "GEO", CountryCodes.Georgia
        },
        {
            "GGY", CountryCodes.Guernsey
        },
        {
            "GHA", CountryCodes.Ghana
        },
        {
            "GIB", CountryCodes.Gibraltar
        },
        {
            "GIN", CountryCodes.Guinea
        },
        {
            "GLP", CountryCodes.Guadeloupe
        },
        {
            "GMB", CountryCodes.Gambia
        },
        {
            "GNB", CountryCodes.GuineaBissau
        },
        {
            "GNQ", CountryCodes.EquatorialGuinea
        },
        {
            "GRC", CountryCodes.Greece
        },
        {
            "GRD", CountryCodes.Grenada
        },
        {
            "GRL", CountryCodes.Greenland
        },
        {
            "GTM", CountryCodes.Guatemala
        },
        {
            "GUF", CountryCodes.FrenchGuiana
        },
        {
            "GUM", CountryCodes.Guam
        },
        {
            "GUY", CountryCodes.Guyana
        },
        {
            "HKG", CountryCodes.HongKong
        },
        {
            "HMD", CountryCodes.HeardIslandAndMcDonaldIslands
        },
        {
            "HND", CountryCodes.Honduras
        },
        {
            "HRV", CountryCodes.Croatia
        },
        {
            "HTI", CountryCodes.Haiti
        },
        {
            "HUN", CountryCodes.Hungary
        },
        {
            "IDN", CountryCodes.Indonesia
        },
        {
            "IMN", CountryCodes.IsleOfMan
        },
        {
            "IND", CountryCodes.India
        },
        {
            "IOT", CountryCodes.BritishIndianOceanTerritory
        },
        {
            "IRL", CountryCodes.Ireland
        },
        {
            "IRN", CountryCodes.Iran
        },
        {
            "IRQ", CountryCodes.Iraq
        },
        {
            "ISL", CountryCodes.Iceland
        },
        {
            "ISR", CountryCodes.Israel
        },
        {
            "ITA", CountryCodes.Italy
        },
        {
            "JAM", CountryCodes.Jamaica
        },
        {
            "JEY", CountryCodes.Jersey
        },
        {
            "JOR", CountryCodes.Jordan
        },
        {
            "JPN", CountryCodes.Japan
        },
        {
            "KAZ", CountryCodes.Kazakhstan
        },
        {
            "KEN", CountryCodes.Kenya
        },
        {
            "KGZ", CountryCodes.Kyrgyzstan
        },
        {
            "KHM", CountryCodes.Cambodia
        },
        {
            "KIR", CountryCodes.Kiribati
        },
        {
            "KNA", CountryCodes.SaintKittsAndNevis
        },
        {
            "KOR", CountryCodes.SouthKorea
        },
        {
            "KWT", CountryCodes.Kuwait
        },
        {
            "LAO", CountryCodes.Laos
        },
        {
            "LBN", CountryCodes.Lebanon
        },
        {
            "LBR", CountryCodes.Liberia
        },
        {
            "LBY", CountryCodes.Libya
        },
        {
            "LCA", CountryCodes.SaintLucia
        },
        {
            "LIE", CountryCodes.Liechtenstein
        },
        {
            "LKA", CountryCodes.SriLanka
        },
        {
            "LSO", CountryCodes.Lesotho
        },
        {
            "LTU", CountryCodes.Lithuania
        },
        {
            "LUX", CountryCodes.Luxembourg
        },
        {
            "LVA", CountryCodes.Latvia
        },
        {
            "MAC", CountryCodes.Macao
        },
        {
            "MAF", CountryCodes.CollectivityOfSaintMartin
        },
        {
            "MAR", CountryCodes.Morocco
        },
        {
            "MCO", CountryCodes.Monaco
        },
        {
            "MDA", CountryCodes.Moldova
        },
        {
            "MDG", CountryCodes.Madagascar
        },
        {
            "MDV", CountryCodes.Maldives
        },
        {
            "MEX", CountryCodes.Mexico
        },
        {
            "MHL", CountryCodes.MarshallIslands
        },
        {
            "MKD", CountryCodes.NorthMacedonia
        },
        {
            "MLI", CountryCodes.Mali
        },
        {
            "MLT", CountryCodes.Malta
        },
        {
            "MMR", CountryCodes.Myanmar
        },
        {
            "MNE", CountryCodes.Montenegro
        },
        {
            "MNG", CountryCodes.Mongolia
        },
        {
            "MNP", CountryCodes.NorthernMarianaIslands
        },
        {
            "MOZ", CountryCodes.Mozambique
        },
        {
            "MRT", CountryCodes.Mauritania
        },
        {
            "MSR", CountryCodes.Montserrat
        },
        {
            "MTQ", CountryCodes.Martinique
        },
        {
            "MUS", CountryCodes.Mauritius
        },
        {
            "MWI", CountryCodes.Malawi
        },
        {
            "MYS", CountryCodes.Malaysia
        },
        {
            "MYT", CountryCodes.Mayotte
        },
        {
            "NAM", CountryCodes.Namibia
        },
        {
            "NCL", CountryCodes.NewCaledonia
        },
        {
            "NER", CountryCodes.Niger
        },
        {
            "NFK", CountryCodes.NorfolkIsland
        },
        {
            "NGA", CountryCodes.Nigeria
        },
        {
            "NIC", CountryCodes.Nicaragua
        },
        {
            "NIU", CountryCodes.Niue
        },
        {
            "NLD", CountryCodes.Netherlands
        },
        {
            "NOR", CountryCodes.Norway
        },
        {
            "NPL", CountryCodes.Nepal
        },
        {
            "NRU", CountryCodes.Nauru
        },
        {
            "NZL", CountryCodes.NewZealand
        },
        {
            "OMN", CountryCodes.Oman
        },
        {
            "PAK", CountryCodes.Pakistan
        },
        {
            "PAN", CountryCodes.Panama
        },
        {
            "PCN", CountryCodes.Pitcairn
        },
        {
            "PER", CountryCodes.Peru
        },
        {
            "PHL", CountryCodes.Philippines
        },
        {
            "PLW", CountryCodes.Palau
        },
        {
            "PNG", CountryCodes.PapuaNewGuinea
        },
        {
            "POL", CountryCodes.Poland
        },
        {
            "PRI", CountryCodes.PuertoRico
        },
        {
            "PRK", CountryCodes.NorthKorea
        },
        {
            "PRT", CountryCodes.Portugal
        },
        {
            "PRY", CountryCodes.Paraguay
        },
        {
            "PSE", CountryCodes.Palestine
        },
        {
            "PYF", CountryCodes.FrenchPolynesia
        },
        {
            "QAT", CountryCodes.Qatar
        },
        {
            "REU", CountryCodes.Réunion
        },
        {
            "ROU", CountryCodes.Romania
        },
        {
            "RUS", CountryCodes.Russia
        },
        {
            "RWA", CountryCodes.Rwanda
        },
        {
            "SAU", CountryCodes.SaudiArabia
        },
        {
            "SDN", CountryCodes.Sudan
        },
        {
            "SEN", CountryCodes.Senegal
        },
        {
            "SGP", CountryCodes.Singapore
        },
        {
            "SGS", CountryCodes.SouthGeorgiaAndTheSouthSandwichIslands
        },
        {
            "SHN", CountryCodes.SaintHelenaAscensionAndTristandaCunha
        },
        {
            "SJM", CountryCodes.SvalbardAndJanMayen
        },
        {
            "SLB", CountryCodes.SolomonIslands
        },
        {
            "SLE", CountryCodes.SierraLeone
        },
        {
            "SLV", CountryCodes.ElSalvador
        },
        {
            "SMR", CountryCodes.SanMarino
        },
        {
            "SOM", CountryCodes.Somalia
        },
        {
            "SPM", CountryCodes.SaintPierreAndMiquelon
        },
        {
            "SRB", CountryCodes.Serbia
        },
        {
            "SSD", CountryCodes.SouthSudan
        },
        {
            "STP", CountryCodes.SãoToméAndPríncipe
        },
        {
            "SUR", CountryCodes.Suriname
        },
        {
            "SVK", CountryCodes.Slovakia
        },
        {
            "SVN", CountryCodes.Slovenia
        },
        {
            "SWE", CountryCodes.Sweden
        },
        {
            "SWZ", CountryCodes.Eswatini
        },
        {
            "SXM", CountryCodes.SintMaarten
        },
        {
            "SYC", CountryCodes.Seychelles
        },
        {
            "SYR", CountryCodes.Syria
        },
        {
            "TCA", CountryCodes.TurksAndCaicosIslands
        },
        {
            "TCD", CountryCodes.Chad
        },
        {
            "TGO", CountryCodes.Togo
        },
        {
            "THA", CountryCodes.Thailand
        },
        {
            "TJK", CountryCodes.Tajikistan
        },
        {
            "TKL", CountryCodes.Tokelau
        },
        {
            "TKM", CountryCodes.Turkmenistan
        },
        {
            "TLS", CountryCodes.TimorLeste
        },
        {
            "TON", CountryCodes.Tonga
        },
        {
            "TTO", CountryCodes.TrinidadAndTobago
        },
        {
            "TUN", CountryCodes.Tunisia
        },
        {
            "TUR", CountryCodes.Turkey
        },
        {
            "TUV", CountryCodes.Tuvalu
        },
        {
            "TWN", CountryCodes.Taiwan
        },
        {
            "TZA", CountryCodes.Tanzania
        },
        {
            "UGA", CountryCodes.Uganda
        },
        {
            "UKR", CountryCodes.Ukraine
        },
        {
            "UMI", CountryCodes.UnitedStatesMinorOutlyingIslands
        },
        {
            "URY", CountryCodes.Uruguay
        },
        {
            "USA", CountryCodes.UnitedStatesOfAmerica
        },
        {
            "UZB", CountryCodes.Uzbekistan
        },
        {
            "VAT", CountryCodes.VaticanCity
        },
        {
            "VCT", CountryCodes.SaintVincentAndTheGrenadines
        },
        {
            "VEN", CountryCodes.Venezuela
        },
        {
            "VGB", CountryCodes.BritishVirginIslands
        },
        {
            "VIR", CountryCodes.UnitedStatesVirginIslands
        },
        {
            "VNM", CountryCodes.VietNam
        },
        {
            "VUT", CountryCodes.Vanuatu
        },
        {
            "WLF", CountryCodes.WallisAndFutuna
        },
        {
            "WSM", CountryCodes.Samoa
        },
        {
            "YEM", CountryCodes.Yemen
        },
        {
            "ZAF", CountryCodes.SouthAfrica
        },
        {
            "ZMB", CountryCodes.Zambia
        },
        {
            "ZWE", CountryCodes.Zimbabwe
        },

    };

    static Dictionary<CountryCodes, string> codeToLetters = new()
    {
        {
            CountryCodes.Aruba, "ABW"
        },
        {
            CountryCodes.Afghanistan, "AFG"
        },
        {
            CountryCodes.Angola, "AGO"
        },
        {
            CountryCodes.Anguilla, "AIA"
        },
        {
            CountryCodes.ÅlandIslands, "ALA"
        },
        {
            CountryCodes.Albania, "ALB"
        },
        {
            CountryCodes.Andorra, "AND"
        },
        {
            CountryCodes.UnitedArabEmirates, "ARE"
        },
        {
            CountryCodes.Argentina, "ARG"
        },
        {
            CountryCodes.Armenia, "ARM"
        },
        {
            CountryCodes.AmericanSamoa, "ASM"
        },
        {
            CountryCodes.Antarctica, "ATA"
        },
        {
            CountryCodes.FrenchSouthernTerritories, "ATF"
        },
        {
            CountryCodes.AntiguaAndBarbuda, "ATG"
        },
        {
            CountryCodes.Australia, "AUS"
        },
        {
            CountryCodes.Austria, "AUT"
        },
        {
            CountryCodes.Azerbaijan, "AZE"
        },
        {
            CountryCodes.Burundi, "BDI"
        },
        {
            CountryCodes.Belgium, "BEL"
        },
        {
            CountryCodes.Benin, "BEN"
        },
        {
            CountryCodes.CaribbeanNetherlands, "BES"
        },
        {
            CountryCodes.BurkinaFaso, "BFA"
        },
        {
            CountryCodes.Bangladesh, "BGD"
        },
        {
            CountryCodes.Bulgaria, "BGR"
        },
        {
            CountryCodes.Bahrain, "BHR"
        },
        {
            CountryCodes.Bahamas, "BHS"
        },
        {
            CountryCodes.BosniaAndHerzegovina, "BIH"
        },
        {
            CountryCodes.SaintBarthélemy, "BLM"
        },
        {
            CountryCodes.Belarus, "BLR"
        },
        {
            CountryCodes.Belize, "BLZ"
        },
        {
            CountryCodes.Bermuda, "BMU"
        },
        {
            CountryCodes.Bolivia, "BOL"
        },
        {
            CountryCodes.Brazil, "BRA"
        },
        {
            CountryCodes.Barbados, "BRB"
        },
        {
            CountryCodes.Brunei, "BRN"
        },
        {
            CountryCodes.Bhutan, "BTN"
        },
        {
            CountryCodes.BouvetIsland, "BVT"
        },
        {
            CountryCodes.Botswana, "BWA"
        },
        {
            CountryCodes.CentralAfricanRepublic, "CAF"
        },
        {
            CountryCodes.Canada, "CAN"
        },
        {
            CountryCodes.CocosKeelingIslands, "CCK"
        },
        {
            CountryCodes.Switzerland, "CHE"
        },
        {
            CountryCodes.Chile, "CHL"
        },
        {
            CountryCodes.China, "CHN"
        },
        {
            CountryCodes.IvoryCoast, "CIV"
        },
        {
            CountryCodes.Cameroon, "CMR"
        },
        {
            CountryCodes.DemocraticRepublicOfTheCongo, "COD"
        },
        {
            CountryCodes.RepublicOfTheCongo, "COG"
        },
        {
            CountryCodes.CookIslands, "COK"
        },
        {
            CountryCodes.Colombia, "COL"
        },
        {
            CountryCodes.Comoros, "COM"
        },
        {
            CountryCodes.CaboVerde, "CPV"
        },
        {
            CountryCodes.CostaRica, "CRI"
        },
        {
            CountryCodes.Cuba, "CUB"
        },
        {
            CountryCodes.Curaçao, "CUW"
        },
        {
            CountryCodes.ChristmasIsland, "CXR"
        },
        {
            CountryCodes.CaymanIslands, "CYM"
        },
        {
            CountryCodes.Cyprus, "CYP"
        },
        {
            CountryCodes.Czechia, "CZE"
        },
        {
            CountryCodes.Germany, "DEU"
        },
        {
            CountryCodes.Djibouti, "DJI"
        },
        {
            CountryCodes.Dominica, "DMA"
        },
        {
            CountryCodes.Denmark, "DNK"
        },
        {
            CountryCodes.DominicanRepublic, "DOM"
        },
        {
            CountryCodes.Algeria, "DZA"
        },
        {
            CountryCodes.Ecuador, "ECU"
        },
        {
            CountryCodes.Egypt, "EGY"
        },
        {
            CountryCodes.Eritrea, "ERI"
        },
        {
            CountryCodes.WesternSahara, "ESH"
        },
        {
            CountryCodes.Spain, "ESP"
        },
        {
            CountryCodes.Estonia, "EST"
        },
        {
            CountryCodes.Ethiopia, "ETH"
        },
        {
            CountryCodes.Finland, "FIN"
        },
        {
            CountryCodes.Fiji, "FJI"
        },
        {
            CountryCodes.FalklandIslands, "FLK"
        },
        {
            CountryCodes.France, "FRA"
        },
        {
            CountryCodes.FaroeIslands, "FRO"
        },
        {
            CountryCodes.Micronesia, "FSM"
        },
        {
            CountryCodes.Gabon, "GAB"
        },
        {
            CountryCodes.UnitedKingdom, "GBR"
        },
        {
            CountryCodes.Georgia, "GEO"
        },
        {
            CountryCodes.Guernsey, "GGY"
        },
        {
            CountryCodes.Ghana, "GHA"
        },
        {
            CountryCodes.Gibraltar, "GIB"
        },
        {
            CountryCodes.Guinea, "GIN"
        },
        {
            CountryCodes.Guadeloupe, "GLP"
        },
        {
            CountryCodes.Gambia, "GMB"
        },
        {
            CountryCodes.GuineaBissau, "GNB"
        },
        {
            CountryCodes.EquatorialGuinea, "GNQ"
        },
        {
            CountryCodes.Greece, "GRC"
        },
        {
            CountryCodes.Grenada, "GRD"
        },
        {
            CountryCodes.Greenland, "GRL"
        },
        {
            CountryCodes.Guatemala, "GTM"
        },
        {
            CountryCodes.FrenchGuiana, "GUF"
        },
        {
            CountryCodes.Guam, "GUM"
        },
        {
            CountryCodes.Guyana, "GUY"
        },
        {
            CountryCodes.HongKong, "HKG"
        },
        {
            CountryCodes.HeardIslandAndMcDonaldIslands, "HMD"
        },
        {
            CountryCodes.Honduras, "HND"
        },
        {
            CountryCodes.Croatia, "HRV"
        },
        {
            CountryCodes.Haiti, "HTI"
        },
        {
            CountryCodes.Hungary, "HUN"
        },
        {
            CountryCodes.Indonesia, "IDN"
        },
        {
            CountryCodes.IsleOfMan, "IMN"
        },
        {
            CountryCodes.India, "IND"
        },
        {
            CountryCodes.BritishIndianOceanTerritory, "IOT"
        },
        {
            CountryCodes.Ireland, "IRL"
        },
        {
            CountryCodes.Iran, "IRN"
        },
        {
            CountryCodes.Iraq, "IRQ"
        },
        {
            CountryCodes.Iceland, "ISL"
        },
        {
            CountryCodes.Israel, "ISR"
        },
        {
            CountryCodes.Italy, "ITA"
        },
        {
            CountryCodes.Jamaica, "JAM"
        },
        {
            CountryCodes.Jersey, "JEY"
        },
        {
            CountryCodes.Jordan, "JOR"
        },
        {
            CountryCodes.Japan, "JPN"
        },
        {
            CountryCodes.Kazakhstan, "KAZ"
        },
        {
            CountryCodes.Kenya, "KEN"
        },
        {
            CountryCodes.Kyrgyzstan, "KGZ"
        },
        {
            CountryCodes.Cambodia, "KHM"
        },
        {
            CountryCodes.Kiribati, "KIR"
        },
        {
            CountryCodes.SaintKittsAndNevis, "KNA"
        },
        {
            CountryCodes.SouthKorea, "KOR"
        },
        {
            CountryCodes.Kuwait, "KWT"
        },
        {
            CountryCodes.Laos, "LAO"
        },
        {
            CountryCodes.Lebanon, "LBN"
        },
        {
            CountryCodes.Liberia, "LBR"
        },
        {
            CountryCodes.Libya, "LBY"
        },
        {
            CountryCodes.SaintLucia, "LCA"
        },
        {
            CountryCodes.Liechtenstein, "LIE"
        },
        {
            CountryCodes.SriLanka, "LKA"
        },
        {
            CountryCodes.Lesotho, "LSO"
        },
        {
            CountryCodes.Lithuania, "LTU"
        },
        {
            CountryCodes.Luxembourg, "LUX"
        },
        {
            CountryCodes.Latvia, "LVA"
        },
        {
            CountryCodes.Macao, "MAC"
        },
        {
            CountryCodes.CollectivityOfSaintMartin, "MAF"
        },
        {
            CountryCodes.Morocco, "MAR"
        },
        {
            CountryCodes.Monaco, "MCO"
        },
        {
            CountryCodes.Moldova, "MDA"
        },
        {
            CountryCodes.Madagascar, "MDG"
        },
        {
            CountryCodes.Maldives, "MDV"
        },
        {
            CountryCodes.Mexico, "MEX"
        },
        {
            CountryCodes.MarshallIslands, "MHL"
        },
        {
            CountryCodes.NorthMacedonia, "MKD"
        },
        {
            CountryCodes.Mali, "MLI"
        },
        {
            CountryCodes.Malta, "MLT"
        },
        {
            CountryCodes.Myanmar, "MMR"
        },
        {
            CountryCodes.Montenegro, "MNE"
        },
        {
            CountryCodes.Mongolia, "MNG"
        },
        {
            CountryCodes.NorthernMarianaIslands, "MNP"
        },
        {
            CountryCodes.Mozambique, "MOZ"
        },
        {
            CountryCodes.Mauritania, "MRT"
        },
        {
            CountryCodes.Montserrat, "MSR"
        },
        {
            CountryCodes.Martinique, "MTQ"
        },
        {
            CountryCodes.Mauritius, "MUS"
        },
        {
            CountryCodes.Malawi, "MWI"
        },
        {
            CountryCodes.Malaysia, "MYS"
        },
        {
            CountryCodes.Mayotte, "MYT"
        },
        {
            CountryCodes.Namibia, "NAM"
        },
        {
            CountryCodes.NewCaledonia, "NCL"
        },
        {
            CountryCodes.Niger, "NER"
        },
        {
            CountryCodes.NorfolkIsland, "NFK"
        },
        {
            CountryCodes.Nigeria, "NGA"
        },
        {
            CountryCodes.Nicaragua, "NIC"
        },
        {
            CountryCodes.Niue, "NIU"
        },
        {
            CountryCodes.Netherlands, "NLD"
        },
        {
            CountryCodes.Norway, "NOR"
        },
        {
            CountryCodes.Nepal, "NPL"
        },
        {
            CountryCodes.Nauru, "NRU"
        },
        {
            CountryCodes.NewZealand, "NZL"
        },
        {
            CountryCodes.Oman, "OMN"
        },
        {
            CountryCodes.Pakistan, "PAK"
        },
        {
            CountryCodes.Panama, "PAN"
        },
        {
            CountryCodes.Pitcairn, "PCN"
        },
        {
            CountryCodes.Peru, "PER"
        },
        {
            CountryCodes.Philippines, "PHL"
        },
        {
            CountryCodes.Palau, "PLW"
        },
        {
            CountryCodes.PapuaNewGuinea, "PNG"
        },
        {
            CountryCodes.Poland, "POL"
        },
        {
            CountryCodes.PuertoRico, "PRI"
        },
        {
            CountryCodes.NorthKorea, "PRK"
        },
        {
            CountryCodes.Portugal, "PRT"
        },
        {
            CountryCodes.Paraguay, "PRY"
        },
        {
            CountryCodes.Palestine, "PSE"
        },
        {
            CountryCodes.FrenchPolynesia, "PYF"
        },
        {
            CountryCodes.Qatar, "QAT"
        },
        {
            CountryCodes.Réunion, "REU"
        },
        {
            CountryCodes.Romania, "ROU"
        },
        {
            CountryCodes.Russia, "RUS"
        },
        {
            CountryCodes.Rwanda, "RWA"
        },
        {
            CountryCodes.SaudiArabia, "SAU"
        },
        {
            CountryCodes.Sudan, "SDN"
        },
        {
            CountryCodes.Senegal, "SEN"
        },
        {
            CountryCodes.Singapore, "SGP"
        },
        {
            CountryCodes.SouthGeorgiaAndTheSouthSandwichIslands, "SGS"
        },
        {
            CountryCodes.SaintHelenaAscensionAndTristandaCunha, "SHN"
        },
        {
            CountryCodes.SvalbardAndJanMayen, "SJM"
        },
        {
            CountryCodes.SolomonIslands, "SLB"
        },
        {
            CountryCodes.SierraLeone, "SLE"
        },
        {
            CountryCodes.ElSalvador, "SLV"
        },
        {
            CountryCodes.SanMarino, "SMR"
        },
        {
            CountryCodes.Somalia, "SOM"
        },
        {
            CountryCodes.SaintPierreAndMiquelon, "SPM"
        },
        {
            CountryCodes.Serbia, "SRB"
        },
        {
            CountryCodes.SouthSudan, "SSD"
        },
        {
            CountryCodes.SãoToméAndPríncipe, "STP"
        },
        {
            CountryCodes.Suriname, "SUR"
        },
        {
            CountryCodes.Slovakia, "SVK"
        },
        {
            CountryCodes.Slovenia, "SVN"
        },
        {
            CountryCodes.Sweden, "SWE"
        },
        {
            CountryCodes.Eswatini, "SWZ"
        },
        {
            CountryCodes.SintMaarten, "SXM"
        },
        {
            CountryCodes.Seychelles, "SYC"
        },
        {
            CountryCodes.Syria, "SYR"
        },
        {
            CountryCodes.TurksAndCaicosIslands, "TCA"
        },
        {
            CountryCodes.Chad, "TCD"
        },
        {
            CountryCodes.Togo, "TGO"
        },
        {
            CountryCodes.Thailand, "THA"
        },
        {
            CountryCodes.Tajikistan, "TJK"
        },
        {
            CountryCodes.Tokelau, "TKL"
        },
        {
            CountryCodes.Turkmenistan, "TKM"
        },
        {
            CountryCodes.TimorLeste, "TLS"
        },
        {
            CountryCodes.Tonga, "TON"
        },
        {
            CountryCodes.TrinidadAndTobago, "TTO"
        },
        {
            CountryCodes.Tunisia, "TUN"
        },
        {
            CountryCodes.Turkey, "TUR"
        },
        {
            CountryCodes.Tuvalu, "TUV"
        },
        {
            CountryCodes.Taiwan, "TWN"
        },
        {
            CountryCodes.Tanzania, "TZA"
        },
        {
            CountryCodes.Uganda, "UGA"
        },
        {
            CountryCodes.Ukraine, "UKR"
        },
        {
            CountryCodes.UnitedStatesMinorOutlyingIslands, "UMI"
        },
        {
            CountryCodes.Uruguay, "URY"
        },
        {
            CountryCodes.UnitedStatesOfAmerica, "USA"
        },
        {
            CountryCodes.Uzbekistan, "UZB"
        },
        {
            CountryCodes.VaticanCity, "VAT"
        },
        {
            CountryCodes.SaintVincentAndTheGrenadines, "VCT"
        },
        {
            CountryCodes.Venezuela, "VEN"
        },
        {
            CountryCodes.BritishVirginIslands, "VGB"
        },
        {
            CountryCodes.UnitedStatesVirginIslands, "VIR"
        },
        {
            CountryCodes.VietNam, "VNM"
        },
        {
            CountryCodes.Vanuatu, "VUT"
        },
        {
            CountryCodes.WallisAndFutuna, "WLF"
        },
        {
            CountryCodes.Samoa, "WSM"
        },
        {
            CountryCodes.Yemen, "YEM"
        },
        {
            CountryCodes.SouthAfrica, "ZAF"
        },
        {
            CountryCodes.Zambia, "ZMB"
        },
        {
            CountryCodes.Zimbabwe, "ZWE"
        },
    };
}