[TestFixture]
public class CountryCodesTests
{
    [Test]
    public void GetCodeForLetters()
    {
        var code = CountryCodes.GetCodeForLetters("ABW");
        Assert.AreEqual(Country.Aruba, code);
    }

    [Test]
    public void TryGetCodeForLetters()
    {
        var found = CountryCodes.TryGetCodeForLetters("ABW", out var code);
        Assert.IsTrue(found);
        Assert.AreEqual(Country.Aruba, code);
        found = CountryCodes.TryGetCodeForLetters("AAA", out code);
        Assert.IsFalse(found);
        Assert.IsNull(code);
    }

    [Test]
    public Task GetCodeForLettersMissing() =>
        Throws(() => CountryCodes.GetCodeForLetters("AAAA"));

    [Test]
    public void GetLettersForCode()
    {
        var letters = Country.Aruba.GetLettersForCode();
        Assert.AreEqual("ABW", letters);
    }

    [Test]
    public void TryGetLettersForCode()
    {
        var found = CountryCodes.TryGetLettersForCode(Country.Aruba, out var letters);
        Assert.IsTrue(found);
        Assert.AreEqual("ABW", letters);
        found = CountryCodes.TryGetLettersForCode((Country) 999, out letters);
        Assert.IsFalse(found);
        Assert.IsNull(letters);
    }

    [Test]
    public Task GetLettersForCodeMissing()
    {
        var countryCode = (Country) 999;
        return Throws(() => countryCode.GetLettersForCode());
    }
}