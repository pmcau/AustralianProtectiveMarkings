namespace AustralianProtectiveMarkings;

public static partial class Renderer
{
    public static (string header, string footer) RenderDocumentHeaderAndFooter(this ProtectiveMarking marking)
    {
        var classification = Render(marking.Classification);

        var primaryBuilder = new StringBuilder(classification);
        var secondaryBuilder = new StringBuilder(classification);
        RenderDocCaveats(marking, primaryBuilder);

        var primary = primaryBuilder.ToString();
        var secondary = secondaryBuilder.ToString();
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

    static void RenderDocCaveats(ProtectiveMarking marking, StringBuilder builder)
    {
        if (!marking.Caveats.HasValue)
        {
            return;
        }

        var caveats = marking.Caveats.Value;

        if (caveats.Codeword != null)
        {
            builder.Append($"//CAVEAT=C:{caveats.Codeword}, ");
        }

        if (caveats.ForeignGovernment != null)
        {
            builder.Append($"CAVEAT=FG:{caveats.ForeignGovernment}, ");
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
            builder.Append($"//EXCLUSIVE-FOR {caveats.ExclusiveFor}, ");
        }

        if (caveats.CountryCodes != null)
        {
            var joined = string.Join("/", caveats.CountryCodes.Select(_ => _.GetLettersForCode()));
            builder.Append($"//REL {joined}");
        }
    }
}