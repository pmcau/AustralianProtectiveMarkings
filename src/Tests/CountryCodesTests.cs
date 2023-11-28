[TestFixture]
public class CountryCodesTests
{
    [Test]
    public void GetCodeForLetters()
    {
        var code = CountryCodes.GetCodeForLetters("ABW");
        AreEqual(Country.Aruba, code);
    }

    [Test]
    public void TryGetCodeForLetters()
    {
        var found = CountryCodes.TryGetCodeForLetters("ABW", out var code);
        IsTrue(found);
        AreEqual(Country.Aruba, code);
        found = CountryCodes.TryGetCodeForLetters("AAA", out code);
        IsFalse(found);
        IsNull(code);
    }

    [Test]
    public Task GetCodeForLettersMissing() =>
        Throws(() => CountryCodes.GetCodeForLetters("AAAA"));

    [Test]
    public void GetLettersForCode()
    {
        var letters = Country.Aruba.GetLettersForCode();
        AreEqual("ABW", letters);
    }

    [Test]
    public void TryGetLettersForCode()
    {
        var found = CountryCodes.TryGetLettersForCode(Country.Aruba, out var letters);
        IsTrue(found);
        AreEqual("ABW", letters);
        found = CountryCodes.TryGetLettersForCode((Country) 999, out letters);
        IsFalse(found);
        IsNull(letters);
    }

    [Test]
    public Task GetLettersForCodeMissing()
    {
        var countryCode = (Country) 999;
        return Throws(() => countryCode.GetLettersForCode());
    }
}