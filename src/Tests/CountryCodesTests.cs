public class CountryCodesTests
{
    [Test]
    public async Task GetCodeForLetters()
    {
        var code = CountryCodes.GetCodeForLetters("ABW");
        await Assert.That(code).IsEqualTo(Country.Aruba);
    }

    [Test]
    public async Task TryGetCodeForLetters()
    {
        var found = CountryCodes.TryGetCodeForLetters("ABW", out var code);
        await Assert.That(found).IsTrue();
        await Assert.That(code).IsEqualTo(Country.Aruba);
        found = CountryCodes.TryGetCodeForLetters("AAA", out code);
        await Assert.That(found).IsFalse();
        await Assert.That(code).IsNull();
    }

    [Test]
    public Task GetCodeForLettersMissing() =>
        Throws(() => CountryCodes.GetCodeForLetters("AAAA"))
            .Snapshot(
                """
                {
                  Type: ArgumentException,
                  Message: Could not find CountryCode for 'AAAA'
                }
                """);

    [Test]
    public async Task GetLettersForCode()
    {
        var letters = Country.Aruba.GetLettersForCode();
        await Assert.That(letters).IsEqualTo("ABW");
    }

    [Test]
    public async Task TryGetLettersForCode()
    {
        var found = CountryCodes.TryGetLettersForCode(Country.Aruba, out var letters);
        await Assert.That(found).IsTrue();
        await Assert.That(letters).IsEqualTo("ABW");
        found = CountryCodes.TryGetLettersForCode((Country) 999, out letters);
        await Assert.That(found).IsFalse();
        await Assert.That(letters).IsNull();
    }

    [Test]
    public Task GetLettersForCodeMissing()
    {
        var countryCode = (Country) 999;
        return Throws(() => countryCode.GetLettersForCode())
            .Snapshot(
                """
                {
                  Type: ArgumentException,
                  Message: Could not find country code letters for '999'
                }
                """);
    }
}