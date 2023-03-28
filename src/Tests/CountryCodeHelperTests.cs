[TestFixture]
public class CountryCodesTests
{
    [Test]
    public void GetCodeForLetters()
    {
        var code = CountryCodes.GetCodeForLetters("ABW");
        Assert.AreEqual(CountryCode.Aruba, code);
    }

    [Test]
    public void TryGetCodeForLetters()
    {
        var found = CountryCodes.TryGetCodeForLetters("ABW", out var code);
        Assert.IsTrue(found);
        Assert.AreEqual(CountryCode.Aruba, code);
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
        var letters = CountryCodes.GetLettersForCode(CountryCode.Aruba);
        Assert.AreEqual("ABW", letters);
    }

    [Test]
    public void TryGetLettersForCode()
    {
        var found = CountryCodes.TryGetLettersForCode(CountryCode.Aruba, out var letters);
        Assert.IsTrue(found);
        Assert.AreEqual("ABW", letters);
        found = CountryCodes.TryGetLettersForCode((CountryCode) 999, out letters);
        Assert.IsFalse(found);
        Assert.IsNull(letters);
    }

    [Test]
    public Task GetLettersForCodeMissing() =>
        Throws(() => CountryCodes.GetLettersForCode((CountryCode) 999));
}