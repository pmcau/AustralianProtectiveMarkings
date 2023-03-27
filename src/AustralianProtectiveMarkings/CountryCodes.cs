namespace AustralianProtectiveMarkings;

public class CountryCodes
{
    static Dictionary<string, CountryCode> lettersToCode = new()
    {
        {
            "ABW", CountryCode.Aruba
        },
        {
            "AFG", CountryCode.Afghanistan
        },
        {
            "AGO", CountryCode.Angola
        },
        {
            "AIA", CountryCode.Anguilla
        },
        {
            "ALA", CountryCode.ÅlandIslands
        },
        {
            "ALB", CountryCode.Albania
        },
        {
            "AND", CountryCode.Andorra
        },
        {
            "ARE", CountryCode.UnitedArabEmirates
        },
        {
            "ARG", CountryCode.Argentina
        },
        {
            "ARM", CountryCode.Armenia
        },
        {
            "ASM", CountryCode.AmericanSamoa
        },
        {
            "ATA", CountryCode.Antarctica
        },
        {
            "ATF", CountryCode.FrenchSouthernTerritories
        },
        {
            "ATG", CountryCode.AntiguaAndBarbuda
        },
        {
            "AUS", CountryCode.Australia
        },
        {
            "AUT", CountryCode.Austria
        },
        {
            "AZE", CountryCode.Azerbaijan
        },
        {
            "BDI", CountryCode.Burundi
        },
        {
            "BEL", CountryCode.Belgium
        },
        {
            "BEN", CountryCode.Benin
        },
        {
            "BES", CountryCode.CaribbeanNetherlands
        },
        {
            "BFA", CountryCode.BurkinaFaso
        },
        {
            "BGD", CountryCode.Bangladesh
        },
        {
            "BGR", CountryCode.Bulgaria
        },
        {
            "BHR", CountryCode.Bahrain
        },
        {
            "BHS", CountryCode.Bahamas
        },
        {
            "BIH", CountryCode.BosniaAndHerzegovina
        },
        {
            "BLM", CountryCode.SaintBarthélemy
        },
        {
            "BLR", CountryCode.Belarus
        },
        {
            "BLZ", CountryCode.Belize
        },
        {
            "BMU", CountryCode.Bermuda
        },
        {
            "BOL", CountryCode.Bolivia
        },
        {
            "BRA", CountryCode.Brazil
        },
        {
            "BRB", CountryCode.Barbados
        },
        {
            "BRN", CountryCode.Brunei
        },
        {
            "BTN", CountryCode.Bhutan
        },
        {
            "BVT", CountryCode.BouvetIsland
        },
        {
            "BWA", CountryCode.Botswana
        },
        {
            "CAF", CountryCode.CentralAfricanRepublic
        },
        {
            "CAN", CountryCode.Canada
        },
        {
            "CCK", CountryCode.CocosKeelingIslands
        },
        {
            "CHE", CountryCode.Switzerland
        },
        {
            "CHL", CountryCode.Chile
        },
        {
            "CHN", CountryCode.China
        },
        {
            "CIV", CountryCode.IvoryCoast
        },
        {
            "CMR", CountryCode.Cameroon
        },
        {
            "COD", CountryCode.DemocraticRepublicOfTheCongo
        },
        {
            "COG", CountryCode.RepublicOfTheCongo
        },
        {
            "COK", CountryCode.CookIslands
        },
        {
            "COL", CountryCode.Colombia
        },
        {
            "COM", CountryCode.Comoros
        },
        {
            "CPV", CountryCode.CaboVerde
        },
        {
            "CRI", CountryCode.CostaRica
        },
        {
            "CUB", CountryCode.Cuba
        },
        {
            "CUW", CountryCode.Curaçao
        },
        {
            "CXR", CountryCode.ChristmasIsland
        },
        {
            "CYM", CountryCode.CaymanIslands
        },
        {
            "CYP", CountryCode.Cyprus
        },
        {
            "CZE", CountryCode.Czechia
        },
        {
            "DEU", CountryCode.Germany
        },
        {
            "DJI", CountryCode.Djibouti
        },
        {
            "DMA", CountryCode.Dominica
        },
        {
            "DNK", CountryCode.Denmark
        },
        {
            "DOM", CountryCode.DominicanRepublic
        },
        {
            "DZA", CountryCode.Algeria
        },
        {
            "ECU", CountryCode.Ecuador
        },
        {
            "EGY", CountryCode.Egypt
        },
        {
            "ERI", CountryCode.Eritrea
        },
        {
            "ESH", CountryCode.WesternSahara
        },
        {
            "ESP", CountryCode.Spain
        },
        {
            "EST", CountryCode.Estonia
        },
        {
            "ETH", CountryCode.Ethiopia
        },
        {
            "FIN", CountryCode.Finland
        },
        {
            "FJI", CountryCode.Fiji
        },
        {
            "FLK", CountryCode.FalklandIslands
        },
        {
            "FRA", CountryCode.France
        },
        {
            "FRO", CountryCode.FaroeIslands
        },
        {
            "FSM", CountryCode.Micronesia
        },
        {
            "GAB", CountryCode.Gabon
        },
        {
            "GBR", CountryCode.UnitedKingdom
        },
        {
            "GEO", CountryCode.Georgia
        },
        {
            "GGY", CountryCode.Guernsey
        },
        {
            "GHA", CountryCode.Ghana
        },
        {
            "GIB", CountryCode.Gibraltar
        },
        {
            "GIN", CountryCode.Guinea
        },
        {
            "GLP", CountryCode.Guadeloupe
        },
        {
            "GMB", CountryCode.Gambia
        },
        {
            "GNB", CountryCode.GuineaBissau
        },
        {
            "GNQ", CountryCode.EquatorialGuinea
        },
        {
            "GRC", CountryCode.Greece
        },
        {
            "GRD", CountryCode.Grenada
        },
        {
            "GRL", CountryCode.Greenland
        },
        {
            "GTM", CountryCode.Guatemala
        },
        {
            "GUF", CountryCode.FrenchGuiana
        },
        {
            "GUM", CountryCode.Guam
        },
        {
            "GUY", CountryCode.Guyana
        },
        {
            "HKG", CountryCode.HongKong
        },
        {
            "HMD", CountryCode.HeardIslandAndMcDonaldIslands
        },
        {
            "HND", CountryCode.Honduras
        },
        {
            "HRV", CountryCode.Croatia
        },
        {
            "HTI", CountryCode.Haiti
        },
        {
            "HUN", CountryCode.Hungary
        },
        {
            "IDN", CountryCode.Indonesia
        },
        {
            "IMN", CountryCode.IsleOfMan
        },
        {
            "IND", CountryCode.India
        },
        {
            "IOT", CountryCode.BritishIndianOceanTerritory
        },
        {
            "IRL", CountryCode.Ireland
        },
        {
            "IRN", CountryCode.Iran
        },
        {
            "IRQ", CountryCode.Iraq
        },
        {
            "ISL", CountryCode.Iceland
        },
        {
            "ISR", CountryCode.Israel
        },
        {
            "ITA", CountryCode.Italy
        },
        {
            "JAM", CountryCode.Jamaica
        },
        {
            "JEY", CountryCode.Jersey
        },
        {
            "JOR", CountryCode.Jordan
        },
        {
            "JPN", CountryCode.Japan
        },
        {
            "KAZ", CountryCode.Kazakhstan
        },
        {
            "KEN", CountryCode.Kenya
        },
        {
            "KGZ", CountryCode.Kyrgyzstan
        },
        {
            "KHM", CountryCode.Cambodia
        },
        {
            "KIR", CountryCode.Kiribati
        },
        {
            "KNA", CountryCode.SaintKittsAndNevis
        },
        {
            "KOR", CountryCode.SouthKorea
        },
        {
            "KWT", CountryCode.Kuwait
        },
        {
            "LAO", CountryCode.Laos
        },
        {
            "LBN", CountryCode.Lebanon
        },
        {
            "LBR", CountryCode.Liberia
        },
        {
            "LBY", CountryCode.Libya
        },
        {
            "LCA", CountryCode.SaintLucia
        },
        {
            "LIE", CountryCode.Liechtenstein
        },
        {
            "LKA", CountryCode.SriLanka
        },
        {
            "LSO", CountryCode.Lesotho
        },
        {
            "LTU", CountryCode.Lithuania
        },
        {
            "LUX", CountryCode.Luxembourg
        },
        {
            "LVA", CountryCode.Latvia
        },
        {
            "MAC", CountryCode.Macao
        },
        {
            "MAF", CountryCode.CollectivityOfSaintMartin
        },
        {
            "MAR", CountryCode.Morocco
        },
        {
            "MCO", CountryCode.Monaco
        },
        {
            "MDA", CountryCode.Moldova
        },
        {
            "MDG", CountryCode.Madagascar
        },
        {
            "MDV", CountryCode.Maldives
        },
        {
            "MEX", CountryCode.Mexico
        },
        {
            "MHL", CountryCode.MarshallIslands
        },
        {
            "MKD", CountryCode.NorthMacedonia
        },
        {
            "MLI", CountryCode.Mali
        },
        {
            "MLT", CountryCode.Malta
        },
        {
            "MMR", CountryCode.Myanmar
        },
        {
            "MNE", CountryCode.Montenegro
        },
        {
            "MNG", CountryCode.Mongolia
        },
        {
            "MNP", CountryCode.NorthernMarianaIslands
        },
        {
            "MOZ", CountryCode.Mozambique
        },
        {
            "MRT", CountryCode.Mauritania
        },
        {
            "MSR", CountryCode.Montserrat
        },
        {
            "MTQ", CountryCode.Martinique
        },
        {
            "MUS", CountryCode.Mauritius
        },
        {
            "MWI", CountryCode.Malawi
        },
        {
            "MYS", CountryCode.Malaysia
        },
        {
            "MYT", CountryCode.Mayotte
        },
        {
            "NAM", CountryCode.Namibia
        },
        {
            "NCL", CountryCode.NewCaledonia
        },
        {
            "NER", CountryCode.Niger
        },
        {
            "NFK", CountryCode.NorfolkIsland
        },
        {
            "NGA", CountryCode.Nigeria
        },
        {
            "NIC", CountryCode.Nicaragua
        },
        {
            "NIU", CountryCode.Niue
        },
        {
            "NLD", CountryCode.Netherlands
        },
        {
            "NOR", CountryCode.Norway
        },
        {
            "NPL", CountryCode.Nepal
        },
        {
            "NRU", CountryCode.Nauru
        },
        {
            "NZL", CountryCode.NewZealand
        },
        {
            "OMN", CountryCode.Oman
        },
        {
            "PAK", CountryCode.Pakistan
        },
        {
            "PAN", CountryCode.Panama
        },
        {
            "PCN", CountryCode.Pitcairn
        },
        {
            "PER", CountryCode.Peru
        },
        {
            "PHL", CountryCode.Philippines
        },
        {
            "PLW", CountryCode.Palau
        },
        {
            "PNG", CountryCode.PapuaNewGuinea
        },
        {
            "POL", CountryCode.Poland
        },
        {
            "PRI", CountryCode.PuertoRico
        },
        {
            "PRK", CountryCode.NorthKorea
        },
        {
            "PRT", CountryCode.Portugal
        },
        {
            "PRY", CountryCode.Paraguay
        },
        {
            "PSE", CountryCode.Palestine
        },
        {
            "PYF", CountryCode.FrenchPolynesia
        },
        {
            "QAT", CountryCode.Qatar
        },
        {
            "REU", CountryCode.Réunion
        },
        {
            "ROU", CountryCode.Romania
        },
        {
            "RUS", CountryCode.Russia
        },
        {
            "RWA", CountryCode.Rwanda
        },
        {
            "SAU", CountryCode.SaudiArabia
        },
        {
            "SDN", CountryCode.Sudan
        },
        {
            "SEN", CountryCode.Senegal
        },
        {
            "SGP", CountryCode.Singapore
        },
        {
            "SGS", CountryCode.SouthGeorgiaAndTheSouthSandwichIslands
        },
        {
            "SHN", CountryCode.SaintHelenaAscensionAndTristandaCunha
        },
        {
            "SJM", CountryCode.SvalbardAndJanMayen
        },
        {
            "SLB", CountryCode.SolomonIslands
        },
        {
            "SLE", CountryCode.SierraLeone
        },
        {
            "SLV", CountryCode.ElSalvador
        },
        {
            "SMR", CountryCode.SanMarino
        },
        {
            "SOM", CountryCode.Somalia
        },
        {
            "SPM", CountryCode.SaintPierreAndMiquelon
        },
        {
            "SRB", CountryCode.Serbia
        },
        {
            "SSD", CountryCode.SouthSudan
        },
        {
            "STP", CountryCode.SãoToméAndPríncipe
        },
        {
            "SUR", CountryCode.Suriname
        },
        {
            "SVK", CountryCode.Slovakia
        },
        {
            "SVN", CountryCode.Slovenia
        },
        {
            "SWE", CountryCode.Sweden
        },
        {
            "SWZ", CountryCode.Eswatini
        },
        {
            "SXM", CountryCode.SintMaarten
        },
        {
            "SYC", CountryCode.Seychelles
        },
        {
            "SYR", CountryCode.Syria
        },
        {
            "TCA", CountryCode.TurksAndCaicosIslands
        },
        {
            "TCD", CountryCode.Chad
        },
        {
            "TGO", CountryCode.Togo
        },
        {
            "THA", CountryCode.Thailand
        },
        {
            "TJK", CountryCode.Tajikistan
        },
        {
            "TKL", CountryCode.Tokelau
        },
        {
            "TKM", CountryCode.Turkmenistan
        },
        {
            "TLS", CountryCode.TimorLeste
        },
        {
            "TON", CountryCode.Tonga
        },
        {
            "TTO", CountryCode.TrinidadAndTobago
        },
        {
            "TUN", CountryCode.Tunisia
        },
        {
            "TUR", CountryCode.Turkey
        },
        {
            "TUV", CountryCode.Tuvalu
        },
        {
            "TWN", CountryCode.Taiwan
        },
        {
            "TZA", CountryCode.Tanzania
        },
        {
            "UGA", CountryCode.Uganda
        },
        {
            "UKR", CountryCode.Ukraine
        },
        {
            "UMI", CountryCode.UnitedStatesMinorOutlyingIslands
        },
        {
            "URY", CountryCode.Uruguay
        },
        {
            "USA", CountryCode.UnitedStatesOfAmerica
        },
        {
            "UZB", CountryCode.Uzbekistan
        },
        {
            "VAT", CountryCode.VaticanCity
        },
        {
            "VCT", CountryCode.SaintVincentAndTheGrenadines
        },
        {
            "VEN", CountryCode.Venezuela
        },
        {
            "VGB", CountryCode.BritishVirginIslands
        },
        {
            "VIR", CountryCode.UnitedStatesVirginIslands
        },
        {
            "VNM", CountryCode.VietNam
        },
        {
            "VUT", CountryCode.Vanuatu
        },
        {
            "WLF", CountryCode.WallisAndFutuna
        },
        {
            "WSM", CountryCode.Samoa
        },
        {
            "YEM", CountryCode.Yemen
        },
        {
            "ZAF", CountryCode.SouthAfrica
        },
        {
            "ZMB", CountryCode.Zambia
        },
        {
            "ZWE", CountryCode.Zimbabwe
        },

    };

    static Dictionary<CountryCode, string> codeToLetters = new()
    {
        {
            CountryCode.Aruba, "ABW"
        },
        {
            CountryCode.Afghanistan, "AFG"
        },
        {
            CountryCode.Angola, "AGO"
        },
        {
            CountryCode.Anguilla, "AIA"
        },
        {
            CountryCode.ÅlandIslands, "ALA"
        },
        {
            CountryCode.Albania, "ALB"
        },
        {
            CountryCode.Andorra, "AND"
        },
        {
            CountryCode.UnitedArabEmirates, "ARE"
        },
        {
            CountryCode.Argentina, "ARG"
        },
        {
            CountryCode.Armenia, "ARM"
        },
        {
            CountryCode.AmericanSamoa, "ASM"
        },
        {
            CountryCode.Antarctica, "ATA"
        },
        {
            CountryCode.FrenchSouthernTerritories, "ATF"
        },
        {
            CountryCode.AntiguaAndBarbuda, "ATG"
        },
        {
            CountryCode.Australia, "AUS"
        },
        {
            CountryCode.Austria, "AUT"
        },
        {
            CountryCode.Azerbaijan, "AZE"
        },
        {
            CountryCode.Burundi, "BDI"
        },
        {
            CountryCode.Belgium, "BEL"
        },
        {
            CountryCode.Benin, "BEN"
        },
        {
            CountryCode.CaribbeanNetherlands, "BES"
        },
        {
            CountryCode.BurkinaFaso, "BFA"
        },
        {
            CountryCode.Bangladesh, "BGD"
        },
        {
            CountryCode.Bulgaria, "BGR"
        },
        {
            CountryCode.Bahrain, "BHR"
        },
        {
            CountryCode.Bahamas, "BHS"
        },
        {
            CountryCode.BosniaAndHerzegovina, "BIH"
        },
        {
            CountryCode.SaintBarthélemy, "BLM"
        },
        {
            CountryCode.Belarus, "BLR"
        },
        {
            CountryCode.Belize, "BLZ"
        },
        {
            CountryCode.Bermuda, "BMU"
        },
        {
            CountryCode.Bolivia, "BOL"
        },
        {
            CountryCode.Brazil, "BRA"
        },
        {
            CountryCode.Barbados, "BRB"
        },
        {
            CountryCode.Brunei, "BRN"
        },
        {
            CountryCode.Bhutan, "BTN"
        },
        {
            CountryCode.BouvetIsland, "BVT"
        },
        {
            CountryCode.Botswana, "BWA"
        },
        {
            CountryCode.CentralAfricanRepublic, "CAF"
        },
        {
            CountryCode.Canada, "CAN"
        },
        {
            CountryCode.CocosKeelingIslands, "CCK"
        },
        {
            CountryCode.Switzerland, "CHE"
        },
        {
            CountryCode.Chile, "CHL"
        },
        {
            CountryCode.China, "CHN"
        },
        {
            CountryCode.IvoryCoast, "CIV"
        },
        {
            CountryCode.Cameroon, "CMR"
        },
        {
            CountryCode.DemocraticRepublicOfTheCongo, "COD"
        },
        {
            CountryCode.RepublicOfTheCongo, "COG"
        },
        {
            CountryCode.CookIslands, "COK"
        },
        {
            CountryCode.Colombia, "COL"
        },
        {
            CountryCode.Comoros, "COM"
        },
        {
            CountryCode.CaboVerde, "CPV"
        },
        {
            CountryCode.CostaRica, "CRI"
        },
        {
            CountryCode.Cuba, "CUB"
        },
        {
            CountryCode.Curaçao, "CUW"
        },
        {
            CountryCode.ChristmasIsland, "CXR"
        },
        {
            CountryCode.CaymanIslands, "CYM"
        },
        {
            CountryCode.Cyprus, "CYP"
        },
        {
            CountryCode.Czechia, "CZE"
        },
        {
            CountryCode.Germany, "DEU"
        },
        {
            CountryCode.Djibouti, "DJI"
        },
        {
            CountryCode.Dominica, "DMA"
        },
        {
            CountryCode.Denmark, "DNK"
        },
        {
            CountryCode.DominicanRepublic, "DOM"
        },
        {
            CountryCode.Algeria, "DZA"
        },
        {
            CountryCode.Ecuador, "ECU"
        },
        {
            CountryCode.Egypt, "EGY"
        },
        {
            CountryCode.Eritrea, "ERI"
        },
        {
            CountryCode.WesternSahara, "ESH"
        },
        {
            CountryCode.Spain, "ESP"
        },
        {
            CountryCode.Estonia, "EST"
        },
        {
            CountryCode.Ethiopia, "ETH"
        },
        {
            CountryCode.Finland, "FIN"
        },
        {
            CountryCode.Fiji, "FJI"
        },
        {
            CountryCode.FalklandIslands, "FLK"
        },
        {
            CountryCode.France, "FRA"
        },
        {
            CountryCode.FaroeIslands, "FRO"
        },
        {
            CountryCode.Micronesia, "FSM"
        },
        {
            CountryCode.Gabon, "GAB"
        },
        {
            CountryCode.UnitedKingdom, "GBR"
        },
        {
            CountryCode.Georgia, "GEO"
        },
        {
            CountryCode.Guernsey, "GGY"
        },
        {
            CountryCode.Ghana, "GHA"
        },
        {
            CountryCode.Gibraltar, "GIB"
        },
        {
            CountryCode.Guinea, "GIN"
        },
        {
            CountryCode.Guadeloupe, "GLP"
        },
        {
            CountryCode.Gambia, "GMB"
        },
        {
            CountryCode.GuineaBissau, "GNB"
        },
        {
            CountryCode.EquatorialGuinea, "GNQ"
        },
        {
            CountryCode.Greece, "GRC"
        },
        {
            CountryCode.Grenada, "GRD"
        },
        {
            CountryCode.Greenland, "GRL"
        },
        {
            CountryCode.Guatemala, "GTM"
        },
        {
            CountryCode.FrenchGuiana, "GUF"
        },
        {
            CountryCode.Guam, "GUM"
        },
        {
            CountryCode.Guyana, "GUY"
        },
        {
            CountryCode.HongKong, "HKG"
        },
        {
            CountryCode.HeardIslandAndMcDonaldIslands, "HMD"
        },
        {
            CountryCode.Honduras, "HND"
        },
        {
            CountryCode.Croatia, "HRV"
        },
        {
            CountryCode.Haiti, "HTI"
        },
        {
            CountryCode.Hungary, "HUN"
        },
        {
            CountryCode.Indonesia, "IDN"
        },
        {
            CountryCode.IsleOfMan, "IMN"
        },
        {
            CountryCode.India, "IND"
        },
        {
            CountryCode.BritishIndianOceanTerritory, "IOT"
        },
        {
            CountryCode.Ireland, "IRL"
        },
        {
            CountryCode.Iran, "IRN"
        },
        {
            CountryCode.Iraq, "IRQ"
        },
        {
            CountryCode.Iceland, "ISL"
        },
        {
            CountryCode.Israel, "ISR"
        },
        {
            CountryCode.Italy, "ITA"
        },
        {
            CountryCode.Jamaica, "JAM"
        },
        {
            CountryCode.Jersey, "JEY"
        },
        {
            CountryCode.Jordan, "JOR"
        },
        {
            CountryCode.Japan, "JPN"
        },
        {
            CountryCode.Kazakhstan, "KAZ"
        },
        {
            CountryCode.Kenya, "KEN"
        },
        {
            CountryCode.Kyrgyzstan, "KGZ"
        },
        {
            CountryCode.Cambodia, "KHM"
        },
        {
            CountryCode.Kiribati, "KIR"
        },
        {
            CountryCode.SaintKittsAndNevis, "KNA"
        },
        {
            CountryCode.SouthKorea, "KOR"
        },
        {
            CountryCode.Kuwait, "KWT"
        },
        {
            CountryCode.Laos, "LAO"
        },
        {
            CountryCode.Lebanon, "LBN"
        },
        {
            CountryCode.Liberia, "LBR"
        },
        {
            CountryCode.Libya, "LBY"
        },
        {
            CountryCode.SaintLucia, "LCA"
        },
        {
            CountryCode.Liechtenstein, "LIE"
        },
        {
            CountryCode.SriLanka, "LKA"
        },
        {
            CountryCode.Lesotho, "LSO"
        },
        {
            CountryCode.Lithuania, "LTU"
        },
        {
            CountryCode.Luxembourg, "LUX"
        },
        {
            CountryCode.Latvia, "LVA"
        },
        {
            CountryCode.Macao, "MAC"
        },
        {
            CountryCode.CollectivityOfSaintMartin, "MAF"
        },
        {
            CountryCode.Morocco, "MAR"
        },
        {
            CountryCode.Monaco, "MCO"
        },
        {
            CountryCode.Moldova, "MDA"
        },
        {
            CountryCode.Madagascar, "MDG"
        },
        {
            CountryCode.Maldives, "MDV"
        },
        {
            CountryCode.Mexico, "MEX"
        },
        {
            CountryCode.MarshallIslands, "MHL"
        },
        {
            CountryCode.NorthMacedonia, "MKD"
        },
        {
            CountryCode.Mali, "MLI"
        },
        {
            CountryCode.Malta, "MLT"
        },
        {
            CountryCode.Myanmar, "MMR"
        },
        {
            CountryCode.Montenegro, "MNE"
        },
        {
            CountryCode.Mongolia, "MNG"
        },
        {
            CountryCode.NorthernMarianaIslands, "MNP"
        },
        {
            CountryCode.Mozambique, "MOZ"
        },
        {
            CountryCode.Mauritania, "MRT"
        },
        {
            CountryCode.Montserrat, "MSR"
        },
        {
            CountryCode.Martinique, "MTQ"
        },
        {
            CountryCode.Mauritius, "MUS"
        },
        {
            CountryCode.Malawi, "MWI"
        },
        {
            CountryCode.Malaysia, "MYS"
        },
        {
            CountryCode.Mayotte, "MYT"
        },
        {
            CountryCode.Namibia, "NAM"
        },
        {
            CountryCode.NewCaledonia, "NCL"
        },
        {
            CountryCode.Niger, "NER"
        },
        {
            CountryCode.NorfolkIsland, "NFK"
        },
        {
            CountryCode.Nigeria, "NGA"
        },
        {
            CountryCode.Nicaragua, "NIC"
        },
        {
            CountryCode.Niue, "NIU"
        },
        {
            CountryCode.Netherlands, "NLD"
        },
        {
            CountryCode.Norway, "NOR"
        },
        {
            CountryCode.Nepal, "NPL"
        },
        {
            CountryCode.Nauru, "NRU"
        },
        {
            CountryCode.NewZealand, "NZL"
        },
        {
            CountryCode.Oman, "OMN"
        },
        {
            CountryCode.Pakistan, "PAK"
        },
        {
            CountryCode.Panama, "PAN"
        },
        {
            CountryCode.Pitcairn, "PCN"
        },
        {
            CountryCode.Peru, "PER"
        },
        {
            CountryCode.Philippines, "PHL"
        },
        {
            CountryCode.Palau, "PLW"
        },
        {
            CountryCode.PapuaNewGuinea, "PNG"
        },
        {
            CountryCode.Poland, "POL"
        },
        {
            CountryCode.PuertoRico, "PRI"
        },
        {
            CountryCode.NorthKorea, "PRK"
        },
        {
            CountryCode.Portugal, "PRT"
        },
        {
            CountryCode.Paraguay, "PRY"
        },
        {
            CountryCode.Palestine, "PSE"
        },
        {
            CountryCode.FrenchPolynesia, "PYF"
        },
        {
            CountryCode.Qatar, "QAT"
        },
        {
            CountryCode.Réunion, "REU"
        },
        {
            CountryCode.Romania, "ROU"
        },
        {
            CountryCode.Russia, "RUS"
        },
        {
            CountryCode.Rwanda, "RWA"
        },
        {
            CountryCode.SaudiArabia, "SAU"
        },
        {
            CountryCode.Sudan, "SDN"
        },
        {
            CountryCode.Senegal, "SEN"
        },
        {
            CountryCode.Singapore, "SGP"
        },
        {
            CountryCode.SouthGeorgiaAndTheSouthSandwichIslands, "SGS"
        },
        {
            CountryCode.SaintHelenaAscensionAndTristandaCunha, "SHN"
        },
        {
            CountryCode.SvalbardAndJanMayen, "SJM"
        },
        {
            CountryCode.SolomonIslands, "SLB"
        },
        {
            CountryCode.SierraLeone, "SLE"
        },
        {
            CountryCode.ElSalvador, "SLV"
        },
        {
            CountryCode.SanMarino, "SMR"
        },
        {
            CountryCode.Somalia, "SOM"
        },
        {
            CountryCode.SaintPierreAndMiquelon, "SPM"
        },
        {
            CountryCode.Serbia, "SRB"
        },
        {
            CountryCode.SouthSudan, "SSD"
        },
        {
            CountryCode.SãoToméAndPríncipe, "STP"
        },
        {
            CountryCode.Suriname, "SUR"
        },
        {
            CountryCode.Slovakia, "SVK"
        },
        {
            CountryCode.Slovenia, "SVN"
        },
        {
            CountryCode.Sweden, "SWE"
        },
        {
            CountryCode.Eswatini, "SWZ"
        },
        {
            CountryCode.SintMaarten, "SXM"
        },
        {
            CountryCode.Seychelles, "SYC"
        },
        {
            CountryCode.Syria, "SYR"
        },
        {
            CountryCode.TurksAndCaicosIslands, "TCA"
        },
        {
            CountryCode.Chad, "TCD"
        },
        {
            CountryCode.Togo, "TGO"
        },
        {
            CountryCode.Thailand, "THA"
        },
        {
            CountryCode.Tajikistan, "TJK"
        },
        {
            CountryCode.Tokelau, "TKL"
        },
        {
            CountryCode.Turkmenistan, "TKM"
        },
        {
            CountryCode.TimorLeste, "TLS"
        },
        {
            CountryCode.Tonga, "TON"
        },
        {
            CountryCode.TrinidadAndTobago, "TTO"
        },
        {
            CountryCode.Tunisia, "TUN"
        },
        {
            CountryCode.Turkey, "TUR"
        },
        {
            CountryCode.Tuvalu, "TUV"
        },
        {
            CountryCode.Taiwan, "TWN"
        },
        {
            CountryCode.Tanzania, "TZA"
        },
        {
            CountryCode.Uganda, "UGA"
        },
        {
            CountryCode.Ukraine, "UKR"
        },
        {
            CountryCode.UnitedStatesMinorOutlyingIslands, "UMI"
        },
        {
            CountryCode.Uruguay, "URY"
        },
        {
            CountryCode.UnitedStatesOfAmerica, "USA"
        },
        {
            CountryCode.Uzbekistan, "UZB"
        },
        {
            CountryCode.VaticanCity, "VAT"
        },
        {
            CountryCode.SaintVincentAndTheGrenadines, "VCT"
        },
        {
            CountryCode.Venezuela, "VEN"
        },
        {
            CountryCode.BritishVirginIslands, "VGB"
        },
        {
            CountryCode.UnitedStatesVirginIslands, "VIR"
        },
        {
            CountryCode.VietNam, "VNM"
        },
        {
            CountryCode.Vanuatu, "VUT"
        },
        {
            CountryCode.WallisAndFutuna, "WLF"
        },
        {
            CountryCode.Samoa, "WSM"
        },
        {
            CountryCode.Yemen, "YEM"
        },
        {
            CountryCode.SouthAfrica, "ZAF"
        },
        {
            CountryCode.Zambia, "ZMB"
        },
        {
            CountryCode.Zimbabwe, "ZWE"
        },
    };
}