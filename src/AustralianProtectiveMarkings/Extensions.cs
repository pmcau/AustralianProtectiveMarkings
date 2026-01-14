namespace AustralianProtectiveMarkings;

static class Extensions
{
    public static async Task EditXmlEntry(this ZipArchiveEntry entry, Action<XDocument> func)
    {
        using var stream = await entry.OpenAsync();
        using var reader = new StreamReader(stream);
        var document = XDocument.Load(reader);
        func(document);
        stream.SetLength(0);
        using var writer = new StreamWriter(stream);
        await writer.WriteAsync(document.ToString());
    }
}