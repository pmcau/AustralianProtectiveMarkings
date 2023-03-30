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
        RenderAuthorEmail(marking, builder);
        builder.Length -= 2;
        return builder.ToString();
    }

    static void RenderClassification(ProtectiveMarking marking, StringBuilder builder) =>
        builder.Append($"SEC={Render(marking.SecurityClassification)}, ");

    static void RenderInformationManagementMarkers(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.PersonalPrivacy)
        {
            builder.Append("ACCESS=Personal-Privacy, ");
        }
        if (marking.LegalPrivilege)
        {
            builder.Append("ACCESS=Legal-Privilege, ");
        }
        if (marking.LegislativeSecrecy)
        {
            builder.Append("ACCESS=Legislative-Secrecy, ");
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
        if (marking.Comment != null)
        {
            builder.Append($"NOTE={marking.Comment}, ");
        }
    }

    static void RenderAuthorEmail(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.AuthorEmail != null)
        {
            builder.Append($"ORIGIN={marking.AuthorEmail}, ");
        }
    }

    static void RenderCaveats(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Caveats == null)
        {
            return;
        }

        var caveats = marking.Caveats.Value;
        if (caveats.Codewords != null)
        {
            foreach (var caveat in caveats.Codewords)
            {
                builder.Append($"CAVEAT=C:{caveat}, ");
            }
        }

        if (caveats.ForeignGovernments != null)
        {
            foreach (var caveat in caveats.ForeignGovernments)
            {
                builder.Append($"CAVEAT=FG:{caveat}, ");
            }
        }

        if (caveats.Agao)
        {
            builder.Append("CAVEAT=RI:AGAO, ");
        }
        if (caveats.Austeo)
        {
            builder.Append("CAVEAT=RI:AUSTEO, ");
        }
        if (caveats.DelicateSource)
        {
            builder.Append("CAVEAT=RI:SH:DELICATE SOURCE, ");
        }
        if (caveats.Orcon)
        {
            builder.Append("CAVEAT=SH:ORCON, ");
        }
        if (caveats.Cabinet)
        {
            builder.Append("CAVEAT=SH:CABINET, ");
        }
        if (caveats.NationalCabinet)
        {
            builder.Append("CAVEAT=SH:NATIONAL-CABINET, ");
        }

        if (caveats.ExclusiveFors != null)
        {
            foreach (var personOrIndicator in caveats.ExclusiveFors)
            {
                builder.Append($"CAVEAT=SH:EXCLUSIVE-FOR {personOrIndicator}, ");
            }
        }

        if (caveats.CountryCodes != null)
        {
            foreach (var countryCode in caveats.CountryCodes)
            {
                builder.Append($"CAVEAT=SH:EXCLUSIVE-FOR {countryCode.GetLettersForCode()}, ");
            }
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
}