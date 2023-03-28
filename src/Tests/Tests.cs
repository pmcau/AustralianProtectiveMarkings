[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking(SecurityClassification.Secret)
        {
            Event = "the event",
            GenDate = new(new(2020,10,1)),
            InformationManagementMarkers = new [] {InformationManagementMarker.LegalPrivilege},
            Caveats = new Caveats(
                Codeword: new[]
                {
                    "codeword1"
                },
                ForeignGovernment: new[]
                {
                    "usa caveat"
                },
                CaveatTypes: new[]
                {
                    CaveatType.Agao,
                    CaveatType.Cabinet,
                },
                ExclusiveFor: new[]
                {
                    "person"
                },
                CountryCodes: new[]
                {
                    CountryCode.Afghanistan,
                    CountryCode.Algeria
                })
        };
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        Assert.AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
}