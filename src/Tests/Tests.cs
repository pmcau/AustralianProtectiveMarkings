[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret,
            Expiry = new Expiry
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(new(2020, 10, 1)),
            },
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "usa caveat",
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
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
}