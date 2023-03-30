[TestFixture]
public class RendererTests
{
    [Test]
    public Task RenderEmailSubject()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderEmailSubjectSuffix());
    }

    [Test]
    public Task RenderEmailHeader()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderEmailHeader());
    }

    [Test]
    public Task RenderEmailSubjectMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderEmailSubjectSuffix());
    }

    [Test]
    public Task RenderEmailHeaderMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderEmailHeader());
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
            Caveats = new Caveats
            {
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
                }
            }
        };
}