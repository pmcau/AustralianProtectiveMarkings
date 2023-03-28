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

    [Test]
    public Task SubjectMin()
    {
        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.Secret
        };
        return Verify(marking.RenderSubject());
    }

    [Test]
    public Task HeaderMin()
    {
        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.Secret
        };
        return Verify(marking.RenderHeader());
    }

    static ProtectiveMarking BuildMarking() =>
        new()
        {
            SecurityClassification = SecurityClassification.Secret,
            DownTo = SecurityClassification.Official,
            Event = "the event",
            Note = "the notes",
            Origin = "the origin",
            Expires = new DateTimeOffset(new(2020, 10, 1)),
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
}