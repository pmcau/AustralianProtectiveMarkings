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
            SecurityClassification = SecurityClassification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = SecurityClassification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            InformationManagementMarkers = new[]
            {
                InformationManagementMarker.LegalPrivilege
            },
            CodewordCaveats = new[]
            {
                "codeword1"
            },
            ForeignGovernmentCaveats = new[]
            {
                "usa caveat"
            },
            CaveatTypes = new[]
            {
                CaveatType.Agao,
                CaveatType.Cabinet,
            },
            ExclusiveForCaveats = new[]
            {
                "person"
            },
            CountryCodeCaveats = new[]
            {
                CountryCode.Afghanistan,
                CountryCode.Algeria
            }
        };
}