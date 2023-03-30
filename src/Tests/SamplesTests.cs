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
}
