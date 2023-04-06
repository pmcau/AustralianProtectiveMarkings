namespace AustralianProtectiveMarkings;

public static class OfficeDoc
{
    const string customPropsFileName = @"docProps/custom.xml";

    public static void PatchWord(Stream stream, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        using var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true);
        var zipEntry = zip.Entries.SingleOrDefault(_ => _.FullName == customPropsFileName);
        if (zipEntry == null)
        {
            zipEntry = zip.CreateEntry(customPropsFileName);
            using var entryStream = zipEntry.Open();
            using var writer = new StreamWriter(entryStream);
            writer.Write($$"""
                        <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                        <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                            <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}" pid="2" name="X-Protective-Marking">
                                <vt:lpwstr>{{header}}</vt:lpwstr>
                            </property>
                        </Properties>
                        """);
        }
        else
        {
            using var entryStream = zipEntry.Open();
            using var reader = new StreamReader(entryStream);
            var xDocument = new XDocument(reader.ReadToEnd());
            AddHeader(xDocument, header);
        }
    }

    static XNamespace vtNamespace = "vt";

    internal static void AddHeader(XDocument document, string marking)
    {
        var property = document
            .Descendants()
            .SingleOrDefault(_ => _.Name.LocalName == "property" &&
                                  _.Attribute("name")?.Value == "X-Protective-Marking");
        if (property == null)
        {
            var element = XElement.Parse("""
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="2"
                              name="X-Protective-Marking" />
                    """);
            element.Add(new XElement(vtNamespace + "lpwstr", marking));
            document.Root!.Add(element);
        }
        else
        {
            var element = property
                .Elements()
                .Single(_ => _.Name.LocalName == "lpwstr");
            element.Value = marking;
        }
    }
}