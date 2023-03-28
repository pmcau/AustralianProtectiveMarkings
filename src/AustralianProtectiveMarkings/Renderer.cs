namespace AustralianProtectiveMarkings;

public static class Renderer
{
    public static string RenderSubject(this ProtectiveMarking marking)
    {
        var builder = new StringBuilder();
        builder.Append($"SEC={Render(marking.SecurityClassification)}, ");
        if (marking.Caveats != null)
        {
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

        if (marking is {GenDate: not null, Event: not null})
        {
            builder.Append($"EXPIRES={marking.GenDate} {marking.Event}, ");
        }
        else if (marking.GenDate != null)
        {
            builder.Append($"EXPIRES={marking.GenDate}, ");
        }
        else if (marking.Event != null)
        {
            builder.Append($"EXPIRES={marking.Event}, ");
        }

        builder.Length -= 2;
        return builder.ToString();
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
}