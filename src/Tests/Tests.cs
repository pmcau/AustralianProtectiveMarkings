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
                }}
        };
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        Assert.AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
}