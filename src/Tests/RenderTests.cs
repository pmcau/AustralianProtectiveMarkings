[TestFixture]
public class RendererTests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking(SecurityClassification.Secret)
        {
            Event = "the event",
            GenDate = new(new(2020,10,1)),
            InformationManagementMarkers = new [] {InformationManagementMarker.LegalPrivilege},
            Caveats = new Caveats(
                Codeword: new[]
                {
                    "codeword1"
                },
                ForeignGovernment: new[]
                {
                    "usa caveat"
                },
                CaveatTypes: new[]
                {
                    CaveatType.Agao,
                    CaveatType.Cabinet,
                },
                ExclusiveFor: new[]
                {
                    "person"
                },
                CountryCodes: new[]
                {
                    CountryCode.Afghanistan,
                    CountryCode.Algeria
                })
        };
        return Verify(marking.RenderSubject());
    }
}