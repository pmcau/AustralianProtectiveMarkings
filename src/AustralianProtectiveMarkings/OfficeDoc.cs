namespace AustralianProtectiveMarkings;

public static class OfficeDoc
{
    const string customPropsFileName = @"docProps/custom.xml";

    public static void PatchWord(Stream stream, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        using var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true);
        EnsureCustomPropertyEntry(zip, header);
        EnsureCustomXmlInContentTypes(zip);
    }

    static void EnsureCustomXmlInContentTypes(ZipArchive zip)
    {
        var entry = zip.Entries.Single(_ => _.FullName == "[Content_Types].xml");

        using var stream = entry.Open();

        using var streamReader = new StreamReader(stream);
        var document = XDocument.Load(streamReader);
        EnsureCustomXmlInContentTypes(document);
        stream.SetLength(0);
        using var writer = new StreamWriter(stream);
        writer.Write(document.ToString());
    }

    internal static void EnsureCustomXmlInContentTypes(XDocument document)
    {
        var overrideElement = document
            .Descendants()
            .SingleOrDefault(_ => _.Name.LocalName == "Override" &&
                                  _.Attribute("PartName")?.Value == "/docProps/custom.xml");

        if (overrideElement != null)
        {
            return;
        }
        document.Root!.Add(
            new XElement(document.Root.GetDefaultNamespace()+"Override",
                new XAttribute("PartName", "/docProps/custom.xml"),
                new XAttribute("ContentType", "application/vnd.openxmlformats-officedocument.custom-properties+xml")));
    }

    internal static void EnsureCustomXmlInRels(XDocument document)
    {
        var overrideElement = document
            .Descendants()
            .SingleOrDefault(_ => _.Name.LocalName == "Relationship" &&
                                  _.Attribute("Target")?.Value == "docProps/custom.xml");

        if (overrideElement != null)
        {
            return;
        }

        var root = document.Root!;
        var ns = root.GetDefaultNamespace();
        var maxId = root.Elements(ns + "Relationship")
            .Select(_ =>
            {
                var id = _.Attribute("Id")!.Value;
                return int.Parse(id[3..]);
            })
            .OrderBy(_ => _)
            .LastOrDefault();

        if (maxId is 0)
        {
            maxId = 1;
        }

        var newid = maxId + 1;
        root.Add(
            new XElement(ns+"Relationship",
                new XAttribute("Id", $"rId{newid}"),
                new XAttribute("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties"),
                new XAttribute("Target", "docProps/custom.xml")));
    }

    static void EnsureCustomPropertyEntry(ZipArchive zip, string header)
    {
        var entry = zip.Entries.SingleOrDefault(_ => _.FullName == customPropsFileName);
        if (entry == null)
        {
            entry = zip.CreateEntry(customPropsFileName);
            using var stream = entry.Open();
            using var writer = new StreamWriter(stream);
            writer.Write($$"""
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties"
                            xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="2"
                              name="X-Protective-Marking">
                        <vt:lpwstr>{{header}}</vt:lpwstr>
                    </property>
                </Properties>
                """);
        }
        else
        {
            using var stream = entry.Open();
            using var reader = new StreamReader(stream);
            var document = XDocument.Load(reader);
            SetHeader(document, header);
            stream.SetLength(0);
            using var writer = new StreamWriter(stream);
            writer.Write(document.ToString());
        }
    }

    static XNamespace vtNamespace = "vt";

    internal static void SetHeader(XDocument document, string marking)
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