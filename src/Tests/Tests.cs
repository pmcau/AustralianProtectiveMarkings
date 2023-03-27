using Argon;
using AustralianProtectiveMarkings;

[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var protectiveMarking = new ProtectiveMarking(SecurityClassification.Secret)
        {
            Caveats = new Caveats(
                CodewordCaveats: new[]
                {
                    "codeword1"
                },
                ForeignGovernmentCaveats: new[]
                {
                    "usa caveat"
                },
                SpecialHandlingCaveats: new[]
                {
                    new SpecialHandlingCaveat(SpecialHandlingCaveatType.Cabinet)
                })
        };
        var serialized1 = JsonConvert.SerializeObject(protectiveMarking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        Assert.AreEqual(serialized1, serialized2);
        return Verify(protectiveMarking);
    }
}