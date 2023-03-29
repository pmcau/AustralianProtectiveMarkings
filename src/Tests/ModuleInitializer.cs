public static class ModuleInit
{
    [ModuleInitializer]
    public static void Setup() =>
        VerifierSettings.IgnoreStackTrace();
}