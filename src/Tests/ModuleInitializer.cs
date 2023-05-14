public static class ModuleInit
{
    [ModuleInitializer]
    public static void Setup()
    {
        VerifyMailMessage.Initialize();
        VerifyAustralianProtectiveMarkings.Initialize();
        VerifierSettings.IgnoreStackTrace();
    }
}