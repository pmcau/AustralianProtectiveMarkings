[TestFixture]
public class ParserTests
{
    [Test]
    public Task Simple()
    {
        var list = new List<string>
        {
            "VER=2018.4",
            "VER=2018.4, NS=gov.au",
            "VER=2018.4, NS=gov.au, SEC=TOP-SECRET",
            "SEC=TOP-SECRET",
            "SEC=OFFICIAL:Sensitive",
        };

        var dictionary = new Dictionary<string, object>();
        foreach (var item in list)
        {
            try
            {
                var protectiveMarking = Parser.Parse(item);
                dictionary.Add(item, protectiveMarking);
            }
            catch (Exception exception)
            {
                dictionary.Add(item, exception);
            }
        }

        return Verify(dictionary);
    }
}