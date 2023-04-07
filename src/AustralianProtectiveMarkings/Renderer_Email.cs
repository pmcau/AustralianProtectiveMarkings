namespace AustralianProtectiveMarkings;

public static partial class Renderer
{
    public static string RenderEmailSubjectSuffix(this ProtectiveMarking marking)
    {
        var builder = new StringBuilder("[");
        RenderMailClassification(marking, builder);
        RenderMailCaveats(marking, builder);
        RenderMailExpiry(marking, builder);
        RenderMailInformationManagementMarkers(marking, builder);
        builder.Length -= 2;
        builder.Append(']');
        return builder.ToString();
    }

    public static string RenderEmailHeader(this ProtectiveMarking marking)
    {
        var builder = new StringBuilder("VER=2018.4, NS=gov.au, ");
        RenderMailClassification(marking, builder);
        RenderMailCaveats(marking, builder);
        RenderMailExpiry(marking, builder);
        RenderMailInformationManagementMarkers(marking, builder);
        RenderMailNote(marking, builder);
        RenderMailAuthorEmail(marking, builder);
        builder.Length -= 2;
        return builder.ToString();
    }

    static void RenderMailClassification(ProtectiveMarking marking, StringBuilder builder) =>
        builder.Append($"SEC={Render(marking.Classification)}, ");

    static void RenderMailInformationManagementMarkers(ProtectiveMarking marking, StringBuilder builder)
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

    static void RenderMailExpiry(ProtectiveMarking marking, StringBuilder builder)
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

    static void RenderMailNote(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Comment != null)
        {
            builder.Append($"NOTE={marking.Comment}, ");
        }
    }

    static void RenderMailAuthorEmail(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.AuthorEmail != null)
        {
            builder.Append($"ORIGIN={marking.AuthorEmail}, ");
        }
    }

    static void RenderMailCaveats(ProtectiveMarking marking, StringBuilder builder)
    {
        if (marking.Caveats == null)
        {
            return;
        }

        var caveats = marking.Caveats.Value;
        if (caveats.Codeword != null)
        {
            builder.Append($"CAVEAT=C:{caveats.Codeword}, ");
        }

        if (caveats.ForeignGovernment != null)
        {
            builder.Append($"CAVEAT=FG:{caveats.ForeignGovernment}, ");
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

        if (caveats.ExclusiveFor != null)
        {
            builder.Append($"CAVEAT=SH:EXCLUSIVE-FOR {caveats.ExclusiveFor}, ");
        }

        if (caveats.CountryCodes != null)
        {
            var joined = string.Join("/", caveats.CountryCodes.Select(_ => _.GetLettersForCode()));
            builder.Append($"CAVEAT=RI:REL {joined}, ");
        }
    }

}