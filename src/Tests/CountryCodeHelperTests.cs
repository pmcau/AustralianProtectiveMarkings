[TestFixture]
public class CountryCodeHelperTests
{
    [Test]
    public void GetCodeForLetters()
    {
        var code = CountryCodeHelper.GetCodeForLetters("ABW");
        Assert.AreEqual(CountryCodes.Aruba, code);
    }

    [Test]
    public void TryGetCodeForLetters()
    {
        var found = CountryCodeHelper.TryGetCodeForLetters("ABW", out var code);
        Assert.IsTrue(found);
        Assert.AreEqual(CountryCodes.Aruba, code);
        found = CountryCodeHelper.TryGetCodeForLetters("AAA", out code);
        Assert.IsFalse(found);
        Assert.IsNull(code);
    }

    [Test]
    public Task GetCodeForLettersMissing() =>
        Throws(() => CountryCodeHelper.GetCodeForLetters("AAAA"));
}