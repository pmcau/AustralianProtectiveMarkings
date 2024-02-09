namespace AustralianProtectiveMarkings;

public static class CountryCodes
{
    public static bool TryGetLettersForCode(
        Country code,
        [NotNullWhen(true)] out string? letters)
    {
        if (codeToLetters.TryGetValue(code, out var value))
        {
            letters = value;
            return true;
        }

        letters = null;
        return false;
    }

    public static string GetLettersForCode(this Country code)
    {
        if (TryGetLettersForCode(code, out var value))
        {
            return value;
        }

        throw new ArgumentException($"Could not find country code letters for '{code}'");
    }

    public static bool TryGetCodeForLetters(
        string letters,
        [NotNullWhen(true)] out Country? codes)
    {
        if (lettersToCode.TryGetValue(letters, out var value))
        {
            codes = value;
            return true;
        }

        codes = null;
        return false;
    }

    public static Country GetCodeForLetters(string letters)
    {
        if (TryGetCodeForLetters(letters, out var value))
        {
            return value.Value;
        }

        throw new ArgumentException($"Could not find CountryCode for '{letters}'");
    }

    static FrozenDictionary<string, Country> lettersToCode = new Dictionary<string, Country>
    {
        {
            "ABW", Country.Aruba
        },
        {
            "AFG", Country.Afghanistan
        },
        {
            "AGO", Country.Angola
        },
        {
            "AIA", Country.Anguilla
        },
        {
            "ALA", Country.ÅlandIslands
        },
        {
            "ALB", Country.Albania
        },
        {
            "AND", Country.Andorra
        },
        {
            "ARE", Country.UnitedArabEmirates
        },
        {
            "ARG", Country.Argentina
        },
        {
            "ARM", Country.Armenia
        },
        {
            "ASM", Country.AmericanSamoa
        },
        {
            "ATA", Country.Antarctica
        },
        {
            "ATF", Country.FrenchSouthernTerritories
        },
        {
            "ATG", Country.AntiguaAndBarbuda
        },
        {
            "AUS", Country.Australia
        },
        {
            "AUT", Country.Austria
        },
        {
            "AZE", Country.Azerbaijan
        },
        {
            "BDI", Country.Burundi
        },
        {
            "BEL", Country.Belgium
        },
        {
            "BEN", Country.Benin
        },
        {
            "BES", Country.CaribbeanNetherlands
        },
        {
            "BFA", Country.BurkinaFaso
        },
        {
            "BGD", Country.Bangladesh
        },
        {
            "BGR", Country.Bulgaria
        },
        {
            "BHR", Country.Bahrain
        },
        {
            "BHS", Country.Bahamas
        },
        {
            "BIH", Country.BosniaAndHerzegovina
        },
        {
            "BLM", Country.SaintBarthélemy
        },
        {
            "BLR", Country.Belarus
        },
        {
            "BLZ", Country.Belize
        },
        {
            "BMU", Country.Bermuda
        },
        {
            "BOL", Country.Bolivia
        },
        {
            "BRA", Country.Brazil
        },
        {
            "BRB", Country.Barbados
        },
        {
            "BRN", Country.Brunei
        },
        {
            "BTN", Country.Bhutan
        },
        {
            "BVT", Country.BouvetIsland
        },
        {
            "BWA", Country.Botswana
        },
        {
            "CAF", Country.CentralAfricanRepublic
        },
        {
            "CAN", Country.Canada
        },
        {
            "CCK", Country.CocosKeelingIslands
        },
        {
            "CHE", Country.Switzerland
        },
        {
            "CHL", Country.Chile
        },
        {
            "CHN", Country.China
        },
        {
            "CIV", Country.IvoryCoast
        },
        {
            "CMR", Country.Cameroon
        },
        {
            "COD", Country.DemocraticRepublicOfTheCongo
        },
        {
            "COG", Country.RepublicOfTheCongo
        },
        {
            "COK", Country.CookIslands
        },
        {
            "COL", Country.Colombia
        },
        {
            "COM", Country.Comoros
        },
        {
            "CPV", Country.CaboVerde
        },
        {
            "CRI", Country.CostaRica
        },
        {
            "CUB", Country.Cuba
        },
        {
            "CUW", Country.Curaçao
        },
        {
            "CXR", Country.ChristmasIsland
        },
        {
            "CYM", Country.CaymanIslands
        },
        {
            "CYP", Country.Cyprus
        },
        {
            "CZE", Country.Czechia
        },
        {
            "DEU", Country.Germany
        },
        {
            "DJI", Country.Djibouti
        },
        {
            "DMA", Country.Dominica
        },
        {
            "DNK", Country.Denmark
        },
        {
            "DOM", Country.DominicanRepublic
        },
        {
            "DZA", Country.Algeria
        },
        {
            "ECU", Country.Ecuador
        },
        {
            "EGY", Country.Egypt
        },
        {
            "ERI", Country.Eritrea
        },
        {
            "ESH", Country.WesternSahara
        },
        {
            "ESP", Country.Spain
        },
        {
            "EST", Country.Estonia
        },
        {
            "ETH", Country.Ethiopia
        },
        {
            "FIN", Country.Finland
        },
        {
            "FJI", Country.Fiji
        },
        {
            "FLK", Country.FalklandIslands
        },
        {
            "FRA", Country.France
        },
        {
            "FRO", Country.FaroeIslands
        },
        {
            "FSM", Country.Micronesia
        },
        {
            "GAB", Country.Gabon
        },
        {
            "GBR", Country.UnitedKingdom
        },
        {
            "GEO", Country.Georgia
        },
        {
            "GGY", Country.Guernsey
        },
        {
            "GHA", Country.Ghana
        },
        {
            "GIB", Country.Gibraltar
        },
        {
            "GIN", Country.Guinea
        },
        {
            "GLP", Country.Guadeloupe
        },
        {
            "GMB", Country.Gambia
        },
        {
            "GNB", Country.GuineaBissau
        },
        {
            "GNQ", Country.EquatorialGuinea
        },
        {
            "GRC", Country.Greece
        },
        {
            "GRD", Country.Grenada
        },
        {
            "GRL", Country.Greenland
        },
        {
            "GTM", Country.Guatemala
        },
        {
            "GUF", Country.FrenchGuiana
        },
        {
            "GUM", Country.Guam
        },
        {
            "GUY", Country.Guyana
        },
        {
            "HKG", Country.HongKong
        },
        {
            "HMD", Country.HeardIslandAndMcDonaldIslands
        },
        {
            "HND", Country.Honduras
        },
        {
            "HRV", Country.Croatia
        },
        {
            "HTI", Country.Haiti
        },
        {
            "HUN", Country.Hungary
        },
        {
            "IDN", Country.Indonesia
        },
        {
            "IMN", Country.IsleOfMan
        },
        {
            "IND", Country.India
        },
        {
            "IOT", Country.BritishIndianOceanTerritory
        },
        {
            "IRL", Country.Ireland
        },
        {
            "IRN", Country.Iran
        },
        {
            "IRQ", Country.Iraq
        },
        {
            "ISL", Country.Iceland
        },
        {
            "ISR", Country.Israel
        },
        {
            "ITA", Country.Italy
        },
        {
            "JAM", Country.Jamaica
        },
        {
            "JEY", Country.Jersey
        },
        {
            "JOR", Country.Jordan
        },
        {
            "JPN", Country.Japan
        },
        {
            "KAZ", Country.Kazakhstan
        },
        {
            "KEN", Country.Kenya
        },
        {
            "KGZ", Country.Kyrgyzstan
        },
        {
            "KHM", Country.Cambodia
        },
        {
            "KIR", Country.Kiribati
        },
        {
            "KNA", Country.SaintKittsAndNevis
        },
        {
            "KOR", Country.SouthKorea
        },
        {
            "KWT", Country.Kuwait
        },
        {
            "LAO", Country.Laos
        },
        {
            "LBN", Country.Lebanon
        },
        {
            "LBR", Country.Liberia
        },
        {
            "LBY", Country.Libya
        },
        {
            "LCA", Country.SaintLucia
        },
        {
            "LIE", Country.Liechtenstein
        },
        {
            "LKA", Country.SriLanka
        },
        {
            "LSO", Country.Lesotho
        },
        {
            "LTU", Country.Lithuania
        },
        {
            "LUX", Country.Luxembourg
        },
        {
            "LVA", Country.Latvia
        },
        {
            "MAC", Country.Macao
        },
        {
            "MAF", Country.CollectivityOfSaintMartin
        },
        {
            "MAR", Country.Morocco
        },
        {
            "MCO", Country.Monaco
        },
        {
            "MDA", Country.Moldova
        },
        {
            "MDG", Country.Madagascar
        },
        {
            "MDV", Country.Maldives
        },
        {
            "MEX", Country.Mexico
        },
        {
            "MHL", Country.MarshallIslands
        },
        {
            "MKD", Country.NorthMacedonia
        },
        {
            "MLI", Country.Mali
        },
        {
            "MLT", Country.Malta
        },
        {
            "MMR", Country.Myanmar
        },
        {
            "MNE", Country.Montenegro
        },
        {
            "MNG", Country.Mongolia
        },
        {
            "MNP", Country.NorthernMarianaIslands
        },
        {
            "MOZ", Country.Mozambique
        },
        {
            "MRT", Country.Mauritania
        },
        {
            "MSR", Country.Montserrat
        },
        {
            "MTQ", Country.Martinique
        },
        {
            "MUS", Country.Mauritius
        },
        {
            "MWI", Country.Malawi
        },
        {
            "MYS", Country.Malaysia
        },
        {
            "MYT", Country.Mayotte
        },
        {
            "NAM", Country.Namibia
        },
        {
            "NCL", Country.NewCaledonia
        },
        {
            "NER", Country.Niger
        },
        {
            "NFK", Country.NorfolkIsland
        },
        {
            "NGA", Country.Nigeria
        },
        {
            "NIC", Country.Nicaragua
        },
        {
            "NIU", Country.Niue
        },
        {
            "NLD", Country.Netherlands
        },
        {
            "NOR", Country.Norway
        },
        {
            "NPL", Country.Nepal
        },
        {
            "NRU", Country.Nauru
        },
        {
            "NZL", Country.NewZealand
        },
        {
            "OMN", Country.Oman
        },
        {
            "PAK", Country.Pakistan
        },
        {
            "PAN", Country.Panama
        },
        {
            "PCN", Country.Pitcairn
        },
        {
            "PER", Country.Peru
        },
        {
            "PHL", Country.Philippines
        },
        {
            "PLW", Country.Palau
        },
        {
            "PNG", Country.PapuaNewGuinea
        },
        {
            "POL", Country.Poland
        },
        {
            "PRI", Country.PuertoRico
        },
        {
            "PRK", Country.NorthKorea
        },
        {
            "PRT", Country.Portugal
        },
        {
            "PRY", Country.Paraguay
        },
        {
            "PSE", Country.Palestine
        },
        {
            "PYF", Country.FrenchPolynesia
        },
        {
            "QAT", Country.Qatar
        },
        {
            "REU", Country.Réunion
        },
        {
            "ROU", Country.Romania
        },
        {
            "RUS", Country.Russia
        },
        {
            "RWA", Country.Rwanda
        },
        {
            "SAU", Country.SaudiArabia
        },
        {
            "SDN", Country.Sudan
        },
        {
            "SEN", Country.Senegal
        },
        {
            "SGP", Country.Singapore
        },
        {
            "SGS", Country.SouthGeorgiaAndTheSouthSandwichIslands
        },
        {
            "SHN", Country.SaintHelenaAscensionAndTristandaCunha
        },
        {
            "SJM", Country.SvalbardAndJanMayen
        },
        {
            "SLB", Country.SolomonIslands
        },
        {
            "SLE", Country.SierraLeone
        },
        {
            "SLV", Country.ElSalvador
        },
        {
            "SMR", Country.SanMarino
        },
        {
            "SOM", Country.Somalia
        },
        {
            "SPM", Country.SaintPierreAndMiquelon
        },
        {
            "SRB", Country.Serbia
        },
        {
            "SSD", Country.SouthSudan
        },
        {
            "STP", Country.SãoToméAndPríncipe
        },
        {
            "SUR", Country.Suriname
        },
        {
            "SVK", Country.Slovakia
        },
        {
            "SVN", Country.Slovenia
        },
        {
            "SWE", Country.Sweden
        },
        {
            "SWZ", Country.Eswatini
        },
        {
            "SXM", Country.SintMaarten
        },
        {
            "SYC", Country.Seychelles
        },
        {
            "SYR", Country.Syria
        },
        {
            "TCA", Country.TurksAndCaicosIslands
        },
        {
            "TCD", Country.Chad
        },
        {
            "TGO", Country.Togo
        },
        {
            "THA", Country.Thailand
        },
        {
            "TJK", Country.Tajikistan
        },
        {
            "TKL", Country.Tokelau
        },
        {
            "TKM", Country.Turkmenistan
        },
        {
            "TLS", Country.TimorLeste
        },
        {
            "TON", Country.Tonga
        },
        {
            "TTO", Country.TrinidadAndTobago
        },
        {
            "TUN", Country.Tunisia
        },
        {
            "TUR", Country.Turkey
        },
        {
            "TUV", Country.Tuvalu
        },
        {
            "TWN", Country.Taiwan
        },
        {
            "TZA", Country.Tanzania
        },
        {
            "UGA", Country.Uganda
        },
        {
            "UKR", Country.Ukraine
        },
        {
            "UMI", Country.UnitedStatesMinorOutlyingIslands
        },
        {
            "URY", Country.Uruguay
        },
        {
            "USA", Country.UnitedStatesOfAmerica
        },
        {
            "UZB", Country.Uzbekistan
        },
        {
            "VAT", Country.VaticanCity
        },
        {
            "VCT", Country.SaintVincentAndTheGrenadines
        },
        {
            "VEN", Country.Venezuela
        },
        {
            "VGB", Country.BritishVirginIslands
        },
        {
            "VIR", Country.UnitedStatesVirginIslands
        },
        {
            "VNM", Country.VietNam
        },
        {
            "VUT", Country.Vanuatu
        },
        {
            "WLF", Country.WallisAndFutuna
        },
        {
            "WSM", Country.Samoa
        },
        {
            "YEM", Country.Yemen
        },
        {
            "ZAF", Country.SouthAfrica
        },
        {
            "ZMB", Country.Zambia
        },
        {
            "ZWE", Country.Zimbabwe
        }
    }.ToFrozenDictionary();

    static FrozenDictionary<Country, string> codeToLetters = new Dictionary<Country, string>
    {
        {
            Country.Aruba, "ABW"
        },
        {
            Country.Afghanistan, "AFG"
        },
        {
            Country.Angola, "AGO"
        },
        {
            Country.Anguilla, "AIA"
        },
        {
            Country.ÅlandIslands, "ALA"
        },
        {
            Country.Albania, "ALB"
        },
        {
            Country.Andorra, "AND"
        },
        {
            Country.UnitedArabEmirates, "ARE"
        },
        {
            Country.Argentina, "ARG"
        },
        {
            Country.Armenia, "ARM"
        },
        {
            Country.AmericanSamoa, "ASM"
        },
        {
            Country.Antarctica, "ATA"
        },
        {
            Country.FrenchSouthernTerritories, "ATF"
        },
        {
            Country.AntiguaAndBarbuda, "ATG"
        },
        {
            Country.Australia, "AUS"
        },
        {
            Country.Austria, "AUT"
        },
        {
            Country.Azerbaijan, "AZE"
        },
        {
            Country.Burundi, "BDI"
        },
        {
            Country.Belgium, "BEL"
        },
        {
            Country.Benin, "BEN"
        },
        {
            Country.CaribbeanNetherlands, "BES"
        },
        {
            Country.BurkinaFaso, "BFA"
        },
        {
            Country.Bangladesh, "BGD"
        },
        {
            Country.Bulgaria, "BGR"
        },
        {
            Country.Bahrain, "BHR"
        },
        {
            Country.Bahamas, "BHS"
        },
        {
            Country.BosniaAndHerzegovina, "BIH"
        },
        {
            Country.SaintBarthélemy, "BLM"
        },
        {
            Country.Belarus, "BLR"
        },
        {
            Country.Belize, "BLZ"
        },
        {
            Country.Bermuda, "BMU"
        },
        {
            Country.Bolivia, "BOL"
        },
        {
            Country.Brazil, "BRA"
        },
        {
            Country.Barbados, "BRB"
        },
        {
            Country.Brunei, "BRN"
        },
        {
            Country.Bhutan, "BTN"
        },
        {
            Country.BouvetIsland, "BVT"
        },
        {
            Country.Botswana, "BWA"
        },
        {
            Country.CentralAfricanRepublic, "CAF"
        },
        {
            Country.Canada, "CAN"
        },
        {
            Country.CocosKeelingIslands, "CCK"
        },
        {
            Country.Switzerland, "CHE"
        },
        {
            Country.Chile, "CHL"
        },
        {
            Country.China, "CHN"
        },
        {
            Country.IvoryCoast, "CIV"
        },
        {
            Country.Cameroon, "CMR"
        },
        {
            Country.DemocraticRepublicOfTheCongo, "COD"
        },
        {
            Country.RepublicOfTheCongo, "COG"
        },
        {
            Country.CookIslands, "COK"
        },
        {
            Country.Colombia, "COL"
        },
        {
            Country.Comoros, "COM"
        },
        {
            Country.CaboVerde, "CPV"
        },
        {
            Country.CostaRica, "CRI"
        },
        {
            Country.Cuba, "CUB"
        },
        {
            Country.Curaçao, "CUW"
        },
        {
            Country.ChristmasIsland, "CXR"
        },
        {
            Country.CaymanIslands, "CYM"
        },
        {
            Country.Cyprus, "CYP"
        },
        {
            Country.Czechia, "CZE"
        },
        {
            Country.Germany, "DEU"
        },
        {
            Country.Djibouti, "DJI"
        },
        {
            Country.Dominica, "DMA"
        },
        {
            Country.Denmark, "DNK"
        },
        {
            Country.DominicanRepublic, "DOM"
        },
        {
            Country.Algeria, "DZA"
        },
        {
            Country.Ecuador, "ECU"
        },
        {
            Country.Egypt, "EGY"
        },
        {
            Country.Eritrea, "ERI"
        },
        {
            Country.WesternSahara, "ESH"
        },
        {
            Country.Spain, "ESP"
        },
        {
            Country.Estonia, "EST"
        },
        {
            Country.Ethiopia, "ETH"
        },
        {
            Country.Finland, "FIN"
        },
        {
            Country.Fiji, "FJI"
        },
        {
            Country.FalklandIslands, "FLK"
        },
        {
            Country.France, "FRA"
        },
        {
            Country.FaroeIslands, "FRO"
        },
        {
            Country.Micronesia, "FSM"
        },
        {
            Country.Gabon, "GAB"
        },
        {
            Country.UnitedKingdom, "GBR"
        },
        {
            Country.Georgia, "GEO"
        },
        {
            Country.Guernsey, "GGY"
        },
        {
            Country.Ghana, "GHA"
        },
        {
            Country.Gibraltar, "GIB"
        },
        {
            Country.Guinea, "GIN"
        },
        {
            Country.Guadeloupe, "GLP"
        },
        {
            Country.Gambia, "GMB"
        },
        {
            Country.GuineaBissau, "GNB"
        },
        {
            Country.EquatorialGuinea, "GNQ"
        },
        {
            Country.Greece, "GRC"
        },
        {
            Country.Grenada, "GRD"
        },
        {
            Country.Greenland, "GRL"
        },
        {
            Country.Guatemala, "GTM"
        },
        {
            Country.FrenchGuiana, "GUF"
        },
        {
            Country.Guam, "GUM"
        },
        {
            Country.Guyana, "GUY"
        },
        {
            Country.HongKong, "HKG"
        },
        {
            Country.HeardIslandAndMcDonaldIslands, "HMD"
        },
        {
            Country.Honduras, "HND"
        },
        {
            Country.Croatia, "HRV"
        },
        {
            Country.Haiti, "HTI"
        },
        {
            Country.Hungary, "HUN"
        },
        {
            Country.Indonesia, "IDN"
        },
        {
            Country.IsleOfMan, "IMN"
        },
        {
            Country.India, "IND"
        },
        {
            Country.BritishIndianOceanTerritory, "IOT"
        },
        {
            Country.Ireland, "IRL"
        },
        {
            Country.Iran, "IRN"
        },
        {
            Country.Iraq, "IRQ"
        },
        {
            Country.Iceland, "ISL"
        },
        {
            Country.Israel, "ISR"
        },
        {
            Country.Italy, "ITA"
        },
        {
            Country.Jamaica, "JAM"
        },
        {
            Country.Jersey, "JEY"
        },
        {
            Country.Jordan, "JOR"
        },
        {
            Country.Japan, "JPN"
        },
        {
            Country.Kazakhstan, "KAZ"
        },
        {
            Country.Kenya, "KEN"
        },
        {
            Country.Kyrgyzstan, "KGZ"
        },
        {
            Country.Cambodia, "KHM"
        },
        {
            Country.Kiribati, "KIR"
        },
        {
            Country.SaintKittsAndNevis, "KNA"
        },
        {
            Country.SouthKorea, "KOR"
        },
        {
            Country.Kuwait, "KWT"
        },
        {
            Country.Laos, "LAO"
        },
        {
            Country.Lebanon, "LBN"
        },
        {
            Country.Liberia, "LBR"
        },
        {
            Country.Libya, "LBY"
        },
        {
            Country.SaintLucia, "LCA"
        },
        {
            Country.Liechtenstein, "LIE"
        },
        {
            Country.SriLanka, "LKA"
        },
        {
            Country.Lesotho, "LSO"
        },
        {
            Country.Lithuania, "LTU"
        },
        {
            Country.Luxembourg, "LUX"
        },
        {
            Country.Latvia, "LVA"
        },
        {
            Country.Macao, "MAC"
        },
        {
            Country.CollectivityOfSaintMartin, "MAF"
        },
        {
            Country.Morocco, "MAR"
        },
        {
            Country.Monaco, "MCO"
        },
        {
            Country.Moldova, "MDA"
        },
        {
            Country.Madagascar, "MDG"
        },
        {
            Country.Maldives, "MDV"
        },
        {
            Country.Mexico, "MEX"
        },
        {
            Country.MarshallIslands, "MHL"
        },
        {
            Country.NorthMacedonia, "MKD"
        },
        {
            Country.Mali, "MLI"
        },
        {
            Country.Malta, "MLT"
        },
        {
            Country.Myanmar, "MMR"
        },
        {
            Country.Montenegro, "MNE"
        },
        {
            Country.Mongolia, "MNG"
        },
        {
            Country.NorthernMarianaIslands, "MNP"
        },
        {
            Country.Mozambique, "MOZ"
        },
        {
            Country.Mauritania, "MRT"
        },
        {
            Country.Montserrat, "MSR"
        },
        {
            Country.Martinique, "MTQ"
        },
        {
            Country.Mauritius, "MUS"
        },
        {
            Country.Malawi, "MWI"
        },
        {
            Country.Malaysia, "MYS"
        },
        {
            Country.Mayotte, "MYT"
        },
        {
            Country.Namibia, "NAM"
        },
        {
            Country.NewCaledonia, "NCL"
        },
        {
            Country.Niger, "NER"
        },
        {
            Country.NorfolkIsland, "NFK"
        },
        {
            Country.Nigeria, "NGA"
        },
        {
            Country.Nicaragua, "NIC"
        },
        {
            Country.Niue, "NIU"
        },
        {
            Country.Netherlands, "NLD"
        },
        {
            Country.Norway, "NOR"
        },
        {
            Country.Nepal, "NPL"
        },
        {
            Country.Nauru, "NRU"
        },
        {
            Country.NewZealand, "NZL"
        },
        {
            Country.Oman, "OMN"
        },
        {
            Country.Pakistan, "PAK"
        },
        {
            Country.Panama, "PAN"
        },
        {
            Country.Pitcairn, "PCN"
        },
        {
            Country.Peru, "PER"
        },
        {
            Country.Philippines, "PHL"
        },
        {
            Country.Palau, "PLW"
        },
        {
            Country.PapuaNewGuinea, "PNG"
        },
        {
            Country.Poland, "POL"
        },
        {
            Country.PuertoRico, "PRI"
        },
        {
            Country.NorthKorea, "PRK"
        },
        {
            Country.Portugal, "PRT"
        },
        {
            Country.Paraguay, "PRY"
        },
        {
            Country.Palestine, "PSE"
        },
        {
            Country.FrenchPolynesia, "PYF"
        },
        {
            Country.Qatar, "QAT"
        },
        {
            Country.Réunion, "REU"
        },
        {
            Country.Romania, "ROU"
        },
        {
            Country.Russia, "RUS"
        },
        {
            Country.Rwanda, "RWA"
        },
        {
            Country.SaudiArabia, "SAU"
        },
        {
            Country.Sudan, "SDN"
        },
        {
            Country.Senegal, "SEN"
        },
        {
            Country.Singapore, "SGP"
        },
        {
            Country.SouthGeorgiaAndTheSouthSandwichIslands, "SGS"
        },
        {
            Country.SaintHelenaAscensionAndTristandaCunha, "SHN"
        },
        {
            Country.SvalbardAndJanMayen, "SJM"
        },
        {
            Country.SolomonIslands, "SLB"
        },
        {
            Country.SierraLeone, "SLE"
        },
        {
            Country.ElSalvador, "SLV"
        },
        {
            Country.SanMarino, "SMR"
        },
        {
            Country.Somalia, "SOM"
        },
        {
            Country.SaintPierreAndMiquelon, "SPM"
        },
        {
            Country.Serbia, "SRB"
        },
        {
            Country.SouthSudan, "SSD"
        },
        {
            Country.SãoToméAndPríncipe, "STP"
        },
        {
            Country.Suriname, "SUR"
        },
        {
            Country.Slovakia, "SVK"
        },
        {
            Country.Slovenia, "SVN"
        },
        {
            Country.Sweden, "SWE"
        },
        {
            Country.Eswatini, "SWZ"
        },
        {
            Country.SintMaarten, "SXM"
        },
        {
            Country.Seychelles, "SYC"
        },
        {
            Country.Syria, "SYR"
        },
        {
            Country.TurksAndCaicosIslands, "TCA"
        },
        {
            Country.Chad, "TCD"
        },
        {
            Country.Togo, "TGO"
        },
        {
            Country.Thailand, "THA"
        },
        {
            Country.Tajikistan, "TJK"
        },
        {
            Country.Tokelau, "TKL"
        },
        {
            Country.Turkmenistan, "TKM"
        },
        {
            Country.TimorLeste, "TLS"
        },
        {
            Country.Tonga, "TON"
        },
        {
            Country.TrinidadAndTobago, "TTO"
        },
        {
            Country.Tunisia, "TUN"
        },
        {
            Country.Turkey, "TUR"
        },
        {
            Country.Tuvalu, "TUV"
        },
        {
            Country.Taiwan, "TWN"
        },
        {
            Country.Tanzania, "TZA"
        },
        {
            Country.Uganda, "UGA"
        },
        {
            Country.Ukraine, "UKR"
        },
        {
            Country.UnitedStatesMinorOutlyingIslands, "UMI"
        },
        {
            Country.Uruguay, "URY"
        },
        {
            Country.UnitedStatesOfAmerica, "USA"
        },
        {
            Country.Uzbekistan, "UZB"
        },
        {
            Country.VaticanCity, "VAT"
        },
        {
            Country.SaintVincentAndTheGrenadines, "VCT"
        },
        {
            Country.Venezuela, "VEN"
        },
        {
            Country.BritishVirginIslands, "VGB"
        },
        {
            Country.UnitedStatesVirginIslands, "VIR"
        },
        {
            Country.VietNam, "VNM"
        },
        {
            Country.Vanuatu, "VUT"
        },
        {
            Country.WallisAndFutuna, "WLF"
        },
        {
            Country.Samoa, "WSM"
        },
        {
            Country.Yemen, "YEM"
        },
        {
            Country.SouthAfrica, "ZAF"
        },
        {
            Country.Zambia, "ZMB"
        },
        {
            Country.Zimbabwe, "ZWE"
        }
    }.ToFrozenDictionary();
}