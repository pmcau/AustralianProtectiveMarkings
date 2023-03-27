public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Setup() =>
        VerifierSettings.AddExtraSettings(_ =>
            _.DefaultValueHandling = DefaultValueHandling.Include);
}