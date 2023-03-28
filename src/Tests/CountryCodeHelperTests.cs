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
        var found = CountryCodeHelper.TryGetLettersForCode(CountryCodes.Aruba, out var letter);
        Assert.IsTrue(found);
        Assert.AreEqual(CountryCodes.Aruba, letter);
        found = CountryCodeHelper.TryGetLettersForCode((CountryCodes) 999, out letter);
        Assert.IsFalse(found);
        Assert.IsNull(letter);
    }

    [Test]
    public Task GetLettersForCodeMissing() =>
        Throws(() => CountryCodeHelper.GetLettersForCode((CountryCodes) 999));
}