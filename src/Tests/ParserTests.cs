[TestFixture]
public class ParserTests
{
    [Test]
    public Task Simple() =>
        Verify(Parser.Parse("SEC=TOP-SECRET"));
}