public static class ModuleInit
{
    [ModuleInitializer]
    public static void Setup() =>
        VerifierSettings.AddExtraSettings(_ =>
            _.DefaultValueHandling = DefaultValueHandling.Include);
}