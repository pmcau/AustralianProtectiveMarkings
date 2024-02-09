namespace AustralianProtectiveMarkings;

public static partial class Renderer
{
    public static (string header, string footer) RenderDocumentHeaderAndFooter(this ProtectiveMarking marking)
    {
        var secondary = RenderOther(marking);
        var primary = RenderClassificationAndCaveats(marking);
        if (secondary == null)
        {
            return (primary, primary);
        }

        return (
            $"""
             {primary}
             {secondary}
             """,
            $"""
             {secondary}
             {primary}
             """);
    }

    static string? RenderOther(ProtectiveMarking marking)
    {
        var builder = new StringBuilder();

        if (marking.PersonalPrivacy)
        {
            builder.Append("Personal-Privacy//");
        }

        if (marking.LegalPrivilege)
        {
            builder.Append("Legal-Privilege//");
        }

        if (marking.LegislativeSecrecy)
        {
            builder.Append("Legislative-Secrecy//");
        }

        if (builder.Length == 0)
        {
            return null;
        }

        builder.Length -= 2;
        return builder.ToString();
    }

    public static string RenderClassificationAndCaveats(this ProtectiveMarking marking)
    {
        var classification = Render(marking.Classification);
        var builder = new StringBuilder(classification);
        if (!marking.Caveats.HasValue)
        {
            return builder.ToString();
        }

        var caveats = marking.Caveats.Value;

        if (caveats.Codeword != null)
        {
            builder.Append($"//C {caveats.Codeword}");
        }

        if (caveats.ForeignGovernment != null)
        {
            builder.Append($"//FG {caveats.ForeignGovernment}");
        }

        if (caveats.Agao)
        {
            builder.Append("//AGAO");
        }

        if (caveats.Austeo)
        {
            builder.Append("//AUSTEO");
        }

        if (caveats.DelicateSource)
        {
            builder.Append("//DELICATE SOURCE");
        }

        if (caveats.Cabinet)
        {
            builder.Append("//CABINET");
        }

        if (caveats.Orcon)
        {
            builder.Append("//ORCON");
        }

        if (caveats.NationalCabinet)
        {
            builder.Append("//NATIONAL-CABINET");
        }

        if (caveats.ExclusiveFor != null)
        {
            builder.Append($"//EXCLUSIVE-FOR {caveats.ExclusiveFor}");
        }

        var countryCodes = caveats.CountryCodes;
        if (countryCodes != null)
        {
            builder.Append("//REL ");
            AppendCountryCodes(builder, countryCodes);
        }

        return builder.ToString();
    }
}