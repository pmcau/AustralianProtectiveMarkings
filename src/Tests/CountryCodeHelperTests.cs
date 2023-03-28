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

    [Test]
    public void GetLettersForCode()
    {
        var letters = CountryCodeHelper.GetLettersForCode(CountryCodes.Aruba);
        Assert.AreEqual("ABW", letters);
    }

    [Test]
    public void TryGetLettersForCode()
    {
        var found = CountryCodeHelper.TryGetLettersForCode(CountryCodes.Aruba, out var letters);
        Assert.IsTrue(found);
        Assert.AreEqual("ABW", letters);
        found = CountryCodeHelper.TryGetLettersForCode((CountryCodes) 999, out letters);
        Assert.IsFalse(found);
        Assert.IsNull(letters);
    }

    [Test]
    public Task GetLettersForCodeMissing() =>
        Throws(() => CountryCodeHelper.GetLettersForCode((CountryCodes) 999));
}