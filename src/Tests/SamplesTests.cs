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
            InformationManagementMarkers = new[]
            {
                InformationManagementMarker.LegalPrivilege
            },
            CodewordCaveats = new[]
            {
                "CodeWord"
            },
            ForeignGovernmentCaveats = new[]
            {
                "USA caveat"
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
            InformationManagementMarkers = new[]
            {
                InformationManagementMarker.LegalPrivilege
            },
            CodewordCaveats = new[]
            {
                "CodeWord"
            },
            ForeignGovernmentCaveats = new[]
            {
                "USA caveat"
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
        var result = marking.RenderHeader();

        #endregion

        return Verify(result);
    }
    [Test]
    public Task ParseMinimum()
    {
        #region ParseMinimum

        var protectiveMarking = Parser.Parse("SEC=OFFICIAL:Sensitive");

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
}