using Argon;
using AustralianProtectiveMarkings;

[TestFixture]
public class Tests
{
    [Test]
    public void Serialization()
    {
        var protectiveMarking = new ProtectiveMarking(SecurityClassification.Secret);
        var serialized = JsonConvert.SerializeObject(protectiveMarking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized);
        Assert.AreEqual(protectiveMarking, deserialized);
    }
}