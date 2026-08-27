public static class ModuleInit
{
    [ModuleInitializer]
    public static void Setup()
    {
        VerifierSettings.Inline(maxLines: 10, applyMaxLinesToExisting: true);
        VerifyMailMessage.Initialize();
        VerifyAustralianProtectiveMarkings.Initialize();
        VerifierSettings.IgnoreStackTrace();
    }
}