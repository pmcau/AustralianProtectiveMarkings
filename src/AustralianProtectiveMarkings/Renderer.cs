﻿namespace AustralianProtectiveMarkings;

public static partial class Renderer
{
    public static string Render(this Classification classification) =>
        classification switch
        {
            Classification.Protected => "PROTECTED",
            Classification.Secret => "SECRET",
            Classification.TopSecret => "TOP-SECRET",
            Classification.Unofficial => "UNOFFICIAL",
            Classification.Official => "OFFICIAL",
            Classification.OfficialSensitive => "OFFICIAL:Sensitive",
            _ => throw new ArgumentOutOfRangeException(nameof(classification), classification, null)
        };

    static void AppendCountryCodes(StringBuilder builder, IEnumerable<Country> codes)
    {
        foreach (var code in codes)
        {
            builder.Append(code.GetLettersForCode());
            builder.Append('/');
        }

        builder.Length--;
    }
}