[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking
        {
            SecurityClassification = SecurityClassification.Secret,
            Expiry = new Expiry
            {
                DownTo = SecurityClassification.Official,
                GenDate = new DateTimeOffset(new(2020, 10, 1)),
            },
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
                CaveatTypes = new[]
                {
                    CaveatType.Agao,
                    CaveatType.Cabinet,
                },
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
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        Assert.AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
}