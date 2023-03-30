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
            Classification = Classification.Secret
        };
        return Verify(marking.RenderSubject());
    }

    [Test]
    public Task HeaderMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderHeader());
    }

    static ProtectiveMarking BuildMarking() =>
        new()
        {
            Classification = Classification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new Caveats{
            Codewords = new[]
            {
                "codeword1"
            },
            ForeignGovernments = new[]
            {
                "usa caveat"
            },
            Agao = true,
            Cabinet = true,
            ExclusiveFors = new[]
            {
                "person"
            },
            CountryCodes = new[]
            {
                Country.Afghanistan,
                Country.Algeria
            }}
        };
}