using System.Net.Mail;

[TestFixture]
public class Samples
{
    [Test]
    public Task RenderEmailSubjectSuffixMinimum()
    {
        #region RenderEmailSubjectSuffixMinimum

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        var result = marking.RenderEmailSubjectSuffix();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderEmailSubjectSuffixFull()
    {
        #region RenderEmailSubjectSuffixFull

        var marking = new ProtectiveMarking
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
                ForeignGovernment = "USA caveat",
                Cabinet = true,
                ExclusiveFor = "person",
                Country = Country.Afghanistan
            }
        };
        var result = marking.RenderEmailSubjectSuffix();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderEmailHeaderMinimum()
    {
        #region RenderEmailHeaderMinimum

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        var result = marking.RenderEmailHeader();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderEmailHeaderFull()
    {
        #region RenderEmailHeaderFull

        var marking = new ProtectiveMarking
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
                ForeignGovernment = "USA caveat",
                Agao = true,
                ExclusiveFor = "person",
                Country = Country.Afghanistan
            }
        };
        var result = marking.RenderEmailHeader();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task ParseEmailHeaderMinimumOmit()
    {
        #region ParseEmailHeaderMinimumOmit

        var protectiveMarking = Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task ParseEmailHeaderMinimum()
    {
        #region ParseEmailHeaderMinimum

        var protectiveMarking = Parser.ParseProtectiveMarking("VER=2018.4, NS=gov.au, SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task ApplyProtectiveMarkings()
    {
        #region ApplyProtectiveMarkings

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Cabinet = true,
                Country = Country.Afghanistan
            }
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);

        #endregion

        return Verify(mail);
    }

    [Test]
    public Task ParseEmailHeaderFull()
    {
        #region ParseEmailHeaderFull

        var protectiveMarking = Parser.ParseProtectiveMarking("VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG/DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task RenderDocumentHeaderAndFooter()
    {
        #region RenderDocumentHeaderAndFooter

        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret,
            LegislativeSecrecy = true,
            Caveats = new()
            {
                Cabinet = true,
                Austeo = true
            }
        };
        var (header, footer) = marking.RenderDocumentHeaderAndFooter();

        #endregion

        return Verify(new
        {
            header,
            footer
        });
    }

    [Test]
    public Task ParseEmailHeaderFullNewlines()
    {
        #region ParseEmailHeaderFullNewlines

        var protectiveMarking = Parser.ParseProtectiveMarking("""
            VER=2018.4,
            NS=gov.au,
            SEC=TOP-SECRET,
            CAVEAT=C:CodeWord,
            CAVEAT=FG:USA caveat,
            CAVEAT=RI:AGAO,
            CAVEAT=SH:CABINET,
            CAVEAT=SH:EXCLUSIVE-FOR person,
            CAVEAT=RI:REL AFG/DZA,
            EXPIRES=2020-10-01,
            DOWNTO=OFFICIAL,
            ACCESS=Legal-Privilege,
            NOTE=the comments,
            ORIGIN=a@b.com
            """);

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task DefineMultiple()
    {
        #region DefineMultiple

        var marking = new ProtectiveMarking
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
                ForeignGovernment = "USA caveat",
                Agao = true,
                Cabinet = true,
                ExclusiveFor = "person",
                CountryCodes = new[]
                {
                    Country.Afghanistan,
                    Country.Algeria
                }
            }
        };

        #endregion

        return Verify(marking);
    }

    async Task OfficeDocHelperSample(Stream stream)
    {
        #region OfficeDocHelperStream

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        await OfficeDocHelper.Patch(stream, marking);

        #endregion
    }

    async Task OfficeDocHelperSample(string filePath)
    {
        #region OfficeDocHelperFile

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        await OfficeDocHelper.Patch(filePath, marking);

        #endregion
    }
}