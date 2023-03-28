[TestFixture]
public class RendererTests
{
    [Test]
    public Task Subject()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderSubject());
    }

    [Test]
    public Task Header()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderHeader());
    }

    static ProtectiveMarking BuildMarking()
    {
        var marking = new ProtectiveMarking(SecurityClassification.Secret)
        {
            DownTo = SecurityClassification.Official,
            Event = "the event",
            Note = "the notes",
            Origin = "the origin",
            GenDate = new(new(2020, 10, 1)),
            InformationManagementMarkers = new[] {InformationManagementMarker.LegalPrivilege},
            Caveats = new Caveats(
                Codeword: new[]
                {
                    "codeword1"
                },
                ForeignGovernment: new[]
                {
                    "usa caveat"
                },
                CaveatTypes: new[]
                {
                    CaveatType.Agao,
                    CaveatType.Cabinet,
                },
                ExclusiveFor: new[]
                {
                    "person"
                },
                CountryCodes: new[]
                {
                    CountryCode.Afghanistan,
                    CountryCode.Algeria
                })
        };
        return marking;
    }
}