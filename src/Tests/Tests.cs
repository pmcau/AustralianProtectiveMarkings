[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking(SecurityClassification.Secret)
        {
            Caveats = new Caveats(
                Codeword: new[]
                {
                    "codeword1"
                },
                ForeignGovernment: new[]
                {
                    "usa caveat"
                },
                ReleasabilityIndicator: new[]
                {
                    ReleasabilityIndicatorCaveat.Agao(),
                    ReleasabilityIndicatorCaveat.Rel(CountryCode.Afghanistan, CountryCode.Algeria),
                },
                SpecialHandling: new[]
                {
                    SpecialHandlingCaveat.Cabinet(),
                    SpecialHandlingCaveat.ExclusiveFor("person"),
                })
        };
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        Assert.AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
}