namespace AustralianProtectiveMarkings;

public static class CommonMarkings
{
    public static ProtectiveMarking Unofficial { get; } = new(Classification.Unofficial);
    public static string UnofficialEmailHeader { get; } = Unofficial.RenderEmailHeader();
    public static string UnofficialEmailSubjectSuffix { get; } = Unofficial.RenderEmailSubjectSuffix();
    public static string UnofficialClassificationAndCaveats { get; } = Unofficial.RenderClassificationAndCaveats();

    public static ProtectiveMarking Official { get; } = new(Classification.Official);
    public static string OfficialEmailHeader { get; } = Official.RenderEmailHeader();
    public static string OfficialEmailSubjectSuffix { get; } = Official.RenderEmailSubjectSuffix();
    public static string OfficialClassificationAndCaveats { get; } = Official.RenderClassificationAndCaveats();

    public static ProtectiveMarking OfficialSensitive { get; } = new(Classification.OfficialSensitive);
    public static string OfficialSensitiveEmailHeader { get; } = OfficialSensitive.RenderEmailHeader();
    public static string OfficialSensitiveEmailSubjectSuffix { get; } = OfficialSensitive.RenderEmailSubjectSuffix();
    public static string OfficialSensitiveClassificationAndCaveats { get; } = OfficialSensitive.RenderClassificationAndCaveats();

    public static ProtectiveMarking Protected { get; } = new(Classification.Protected);
    public static string ProtectedEmailHeader { get; } = Protected.RenderEmailHeader();
    public static string ProtectedEmailSubjectSuffix { get; } = Protected.RenderEmailSubjectSuffix();
    public static string ProtectedClassificationAndCaveats { get; } = Protected.RenderClassificationAndCaveats();

    public static ProtectiveMarking ProtectedCabinet { get; } = new(Classification.Protected)
    {
        Caveats = new Caveats
        {
            Cabinet = true
        }
    };

    public static string ProtectedCabinetEmailHeader { get; } = ProtectedCabinet.RenderEmailHeader();
    public static string ProtectedCabinetEmailSubjectSuffix { get; } = ProtectedCabinet.RenderEmailSubjectSuffix();
    public static string ProtectedCabinetClassificationAndCaveats { get; } = ProtectedCabinet.RenderClassificationAndCaveats();
}