namespace AustralianProtectiveMarkings;

public static class Renderer
{
    public static string RenderSubject(this ProtectiveMarking marking)
    {
        var builder = new StringBuilder("[");
        RenderClassification(marking, builder);
        RenderCaveats(marking, builder);
        RenderExpiry(marking, builder);
        RenderInformationManagementMarkers(marking, builder);
        builder.Length -= 2;
        builder.Append(']');
        return builder.ToString();
    }

    public static string RenderHeader(this ProtectiveMarking marking)
    {
        var builder = new StringBuilder("VER=2018.4, NS=gov.au, ");
        RenderClassification(marking, builder);
        RenderCaveats(marking, builder);
        RenderExpiry(marking, builder);
        RenderInformationManagementMarkers(marking, builder);
        RenderNote(marking, builder);
        RenderOrigin(marking, builder);
        builder.Length -= 2;
        return builder.ToString();
    }

    static void RenderClassification(ProtectiveMarking marking, StringBuilder builder) =>
        builder.Append($"SEC={Render(marking.SecurityClassification)}, ");

    static void RenderInformationManagementMarkers(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.InformationManagementMarkers == null)
        {
            return;
        }

        foreach (var marker in marking.InformationManagementMarkers)
        {
            builder.Append($"ACCESS={Render(marker)}, ");
        }
    }

    static void RenderExpiry(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Expiry == null)
        {
            return;
        }

        var expiry = marking.Expiry.Value;
        if (expiry is {GenDate: null, Event: null})
        {
            throw new("Either Expires or Event must exist");
        }

        if (expiry.GenDate == null)
        {
            builder.Append($"EXPIRES={expiry.Event}, ");
        }
        else
        {
            builder.Append($"EXPIRES={expiry.GenDate.Value.Render()}, ");
        }

        builder.Append($"DOWNTO={Render(expiry.DownTo)}, ");
    }

    static void RenderNote(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Note != null)
        {
            builder.Append($"NOTE={marking.Note}, ");
        }
    }

    static void RenderOrigin(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Origin != null)
        {
            builder.Append($"ORIGIN={marking.Origin}, ");
        }
    }

    static void RenderCaveats(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Caveats == null)
        {
            return;
        }

        var (codewords, foreignGovernment, caveatTypes, exclusiveFor, countryCodes) = marking.Caveats.Value;

        foreach (var caveat in codewords)
        {
            builder.Append($"CAVEAT=C:{caveat}, ");
        }

        foreach (var caveat in foreignGovernment)
        {
            builder.Append($"CAVEAT=FG:{caveat}, ");
        }

        foreach (var caveat in caveatTypes)
        {
            builder.Append($"CAVEAT={caveat.Render()}, ");
        }

        foreach (var personOrIndicator in exclusiveFor)
        {
            builder.Append($"CAVEAT=SH:EXCLUSIVE-FOR {personOrIndicator}, ");
        }

        foreach (var countryCode in countryCodes)
        {
            builder.Append($"CAVEAT=SH:EXCLUSIVE-FOR {countryCode.GetLettersForCode()}, ");
        }
    }

    public static string Render(this SecurityClassification classification) =>
        classification switch
        {
            SecurityClassification.Protected => "PROTECTED",
            SecurityClassification.Secret => "SECRET",
            SecurityClassification.TopSecret => "TOP-SECRET",
            SecurityClassification.Unofficial => "UNOFFICIAL",
            SecurityClassification.Official => "OFFICIAL",
            SecurityClassification.OfficialSensitive => "OFFICIAL:Sensitive",
            _ => throw new ArgumentOutOfRangeException(nameof(classification), classification, null)
        };

    public static string Render(this CaveatType type) =>
        type switch
        {
            CaveatType.Agao => "RI:AGAO",
            CaveatType.Austeo => "RI:AUSTEO",
            CaveatType.DelicateSource => "SH:DELICATE SOURCE",
            CaveatType.Orcon => "SH:ORCON",
            CaveatType.Cabinet => "SH:CABINET",
            CaveatType.NationalCabinet => "SH:NATIONAL-CABINET1",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

    public static string Render(this InformationManagementMarker marker) =>
        marker switch
        {
            InformationManagementMarker.PersonalPrivacy => "Personal-Privacy",
            InformationManagementMarker.LegalPrivilege => "Legal-Privilege",
            InformationManagementMarker.LegislativeSecrecy => "Legislative-Secrecy",
            _ => throw new ArgumentOutOfRangeException(nameof(marker), marker, null)
        };
}