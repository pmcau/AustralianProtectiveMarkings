namespace AustralianProtectiveMarkings;

static class Extensions{

    public static void EditXmlEntry(this ZipArchiveEntry entry, Action<XDocument> func)
    {
        using var stream = entry.Open();
        using var reader = new StreamReader(stream);
        var document = XDocument.Load(reader);
        func(document);
        stream.SetLength(0);
        using var writer = new StreamWriter(stream);
        writer.Write(document.ToString());
    }
}