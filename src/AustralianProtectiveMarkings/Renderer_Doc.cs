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

        if (caveats.Codewords != null)
        {
            foreach (var caveat in caveats.Codewords)
            {
                builder.Append($"//CAVEAT=C:{caveat}, ");
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

        if (caveats.ExclusiveFors != null)
        {
            foreach (var personOrIndicator in caveats.ExclusiveFors)
            {
                builder.Append($"//EXCLUSIVE-FOR {personOrIndicator}, ");
            }
        }
        if (caveats.CountryCodes != null)
        {
            var joined = string.Join("/", caveats.CountryCodes.Select(_ => _.GetLettersForCode()));
            builder.Append($"//REL {joined}");
        }
    }
}