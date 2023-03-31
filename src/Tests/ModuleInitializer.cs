public static class ModuleInit
{
    [ModuleInitializer]
    public static void Setup()
    {
        VerifyMailMessage.Initialize();
        VerifierSettings.IgnoreStackTrace();
    }
}