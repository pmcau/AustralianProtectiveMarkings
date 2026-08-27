[TestFixture]
public class RendererTests
{
    [Test]
    public Task RenderEmailSubject()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderEmailSubjectSuffix())
            .Snapshot("[SEC=TOP-SECRET, CAVEAT=C:LOBSTER, CAVEAT=FG:usa caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG/DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege]");
    }

    [Test]
    public Task RenderEmailHeader()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderEmailHeader())
            .Snapshot("VER=2025.1, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:LOBSTER, CAVEAT=FG:usa caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG/DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");
    }

    [Test]
    public Task RenderClassificationAndCaveats()
    {
        var marking = BuildMarking();
        return Verify(marking.RenderClassificationAndCaveats())
            .Snapshot("TOP-SECRET//C LOBSTER//FG usa caveat//AGAO//CABINET//EXCLUSIVE-FOR person//REL AFG/DZA");
    }

    [Test]
    public Task RenderClassificationAndCaveatsMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderClassificationAndCaveats())
            .Snapshot("SECRET");
    }

    [Test]
    public Task RenderDocumentHeaderAndFooter()
    {
        var marking = BuildMarking();
        return VerifyTuple(() => marking.RenderDocumentHeaderAndFooter())
            .Snapshot(
                """
                {
                  footer:
                Legal-Privilege
                TOP-SECRET//C LOBSTER//FG usa caveat//AGAO//CABINET//EXCLUSIVE-FOR person//REL AFG/DZA,
                  header:
                TOP-SECRET//C LOBSTER//FG usa caveat//AGAO//CABINET//EXCLUSIVE-FOR person//REL AFG/DZA
                Legal-Privilege
                }
                """);
    }

    [Test]
    public Task RenderDocumentHeaderAndFooterMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return VerifyTuple(() => marking.RenderDocumentHeaderAndFooter())
            .Snapshot(
                """
                {
                  footer: SECRET,
                  header: SECRET
                }
                """);
    }

    [Test]
    public Task RenderEmailSubjectMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderEmailSubjectSuffix())
            .Snapshot("[SEC=SECRET]");
    }

    [Test]
    public Task RenderEmailHeaderMin()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret
        };
        return Verify(marking.RenderEmailHeader())
            .Snapshot("VER=2025.1, NS=gov.au, SEC=SECRET");
    }

    [Test]
    public Task RenderEmailHeaderGenDateWithTicks()
    {
        var date = new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc).AddTicks(1);
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret,
            Expiry = new Expiry
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(date, TimeSpan.Zero)
            }
        };
        return Verify(marking.RenderEmailHeader())
            .Snapshot("VER=2025.1, NS=gov.au, SEC=SECRET, EXPIRES=2020-10-01T00:00:00.0000001, DOWNTO=OFFICIAL");
    }

    static ProtectiveMarking BuildMarking() =>
        new()
        {
            Classification = Classification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero)
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "usa caveat",
                Agao = true,
                Cabinet = true,
                ExclusiveFor = "person",
                CountryCodes =
                [
                    Country.Afghanistan,
                    Country.Algeria
                ]
            }
        };
}