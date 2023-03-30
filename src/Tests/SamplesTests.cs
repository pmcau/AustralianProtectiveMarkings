[TestFixture]
public class Samples
{
    [Test]
    public Task RenderSubjectMinimum()
    {
        #region RenderSubjectMinimum

        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.TopSecret,
        };
        var result = marking.RenderSubject();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderSubjectFull()
    {
        #region RenderSubjectFull

        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = SecurityClassification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "CodeWord",
                ForeignGovernment = "USA caveat",
                Cabinet = true,
                ExclusiveFor = "person",
                CountryCode = CountryCode.Afghanistan
            }
        };
        var result = marking.RenderSubject();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderHeaderMinimum()
    {
        #region RenderHeaderMinimum

        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.TopSecret,
        };
        var result = marking.RenderHeader();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task RenderHeaderFull()
    {
        #region RenderHeaderFull

        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = SecurityClassification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "CodeWord",
                ForeignGovernment = "USA caveat",
                Agao = true,
                ExclusiveFor = "person",
                CountryCode = CountryCode.Afghanistan
            }
        };
        var result = marking.RenderHeader();

        #endregion

        return Verify(result);
    }

    [Test]
    public Task ParseMinimumOmit()
    {
        #region ParseMinimumOmit

        var protectiveMarking = Parser.Parse("SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task ParseMinimum()
    {
        #region ParseMinimum

        var protectiveMarking = Parser.Parse("VER=2018.4, NS=gov.au, SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task ParseFull()
    {
        #region ParseFull

        var protectiveMarking = Parser.Parse("VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, CAVEAT=SH:EXCLUSIVE-FOR DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");

        #endregion

        return Verify(protectiveMarking);
    }

    [Test]
    public Task ParseFullNewlines()
    {
        #region ParseFullNewlines

        var protectiveMarking = Parser.Parse("""
            VER=2018.4,
            NS=gov.au,
            SEC=TOP-SECRET,
            CAVEAT=C:CodeWord,
            CAVEAT=FG:USA caveat,
            CAVEAT=RI:AGAO,
            CAVEAT=SH:CABINET,
            CAVEAT=SH:EXCLUSIVE-FOR person,
            CAVEAT=SH:EXCLUSIVE-FOR AFG,
            CAVEAT=SH:EXCLUSIVE-FOR DZA,
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
            SecurityClassification = SecurityClassification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = SecurityClassification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codewords = new[]
                {
                    "CodeWord"
                },
                ForeignGovernments = new[]
                {
                    "USA caveat"
                },
                Agao = true,
                Cabinet = true,
                ExclusiveFors = new[]
                {
                    "person"
                },
                CountryCodes = new[]
                {
                    CountryCode.Afghanistan,
                    CountryCode.Algeria
                }
            }
        };

        #endregion

        return Verify(marking);
    }
}