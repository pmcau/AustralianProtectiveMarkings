[TestFixture]
public class OfficeDocTests
{
    [Test]
    public async Task Parse()
    {
        var memoryStream = new MemoryStream();
        await Resourcer.Resource.AsStream("doc.docx").CopyToAsync(memoryStream);
        await OfficeDoc.PatchWord(memoryStream);
    }
}