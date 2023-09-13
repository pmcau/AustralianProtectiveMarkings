namespace VerifyTests;

public static class VerifyAustralianProtectiveMarkings
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;

        InnerVerifier.ThrowIfVerifyHasBeenRun();
        CounterContext.Init();
        VerifierSettings
            .AddExtraSettings(_ =>
            {
                var converters = _.Converters;
                converters.Add(new ProtectiveMarkingConverter());
                converters.Add(new CaveatsConverter());
            });
    }
}