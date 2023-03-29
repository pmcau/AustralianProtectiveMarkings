[TestFixture]
public class ParserTests
{
    [Test]
    public Task Simple()
    {
        var list = new List<string>
        {
            "SEC=TOP-SECRET",
            "SEC=OFFICIAL:Sensitive"
        };

        var dictionary = new Dictionary<string, ProtectiveMarking>();
        foreach (var item in list)
        {
            dictionary.Add(item, Parser.Parse(item));
        }

        return Verify(dictionary);
    }
}