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
            Caveats = new Caveats{
            Codewords = new[]
            {
                "codeword1"
            },
            ForeignGovernments = new[]
            {
                "usa caveat"
            },
            IsAgao = true,
            IsCabinet = true,
            ExclusiveFors = new[]
            {
                "person"
            },
            CountryCodes = new[]
            {
                CountryCode.Afghanistan,
                CountryCode.Algeria
            }}
        };
}