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

        using var reader = new StreamReader(stream);
        var document = XDocument.Load(reader);
        EnsureCustomXmlInContentTypes(document);
        stream.SetLength(0);
        using var writer = new StreamWriter(stream);
        writer.Write(document.ToString());
    }

    internal static void EnsureCustomXmlInContentTypes(XDocument document)
    {
        var root = document.Root!;
        var overrideName = root.GetDefaultNamespace() + "Override";
        var overrides = root.Elements(overrideName).ToList();

        var overrideElement = overrides
            .SingleOrDefault(_ => _.Attribute("PartName")?.Value == "/docProps/custom.xml");

        if (overrideElement != null)
        {
            return;
        }

        root.Add(
            new XElement(
                overrideName,
                new XAttribute("PartName", "/docProps/custom.xml"),
                new XAttribute("ContentType", "application/vnd.openxmlformats-officedocument.custom-properties+xml")));
    }

    static void EnsureCustomXmlInRels(ZipArchive zip)
    {
        var entry = zip.Entries.Single(_ => _.FullName == @"_rels\.rels");

        using var stream = entry.Open();

        using var reader = new StreamReader(stream);
        var document = XDocument.Load(reader);
        EnsureCustomXmlInRels(document);
        stream.SetLength(0);
        using var writer = new StreamWriter(stream);
        writer.Write(document.ToString());
    }
    internal static void EnsureCustomXmlInRels(XDocument document)
    {
        var root = document.Root!;
        var relationshipName = root.GetDefaultNamespace() + "Relationship";
        var relationships = root.Elements(relationshipName).ToList();
        var overrideElement = relationships
            .SingleOrDefault(_ => _.Attribute("Target")?.Value == "docProps/custom.xml");

        if (overrideElement != null)
        {
            return;
        }

        var maxId = relationships
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
            new XElement(
                relationshipName,
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
        var root = document.Root!;
        var propertyName = root.GetDefaultNamespace() + "property";
        var properties = root.Elements(propertyName).ToList();
        var property = properties.SingleOrDefault(_ => _.Attribute("name")?.Value == "X-Protective-Marking");
        if (property == null)
        {
            var maxId = properties
                .Select(_ =>
                {
                    var id = _.Attribute("pid")!.Value;
                    return int.Parse(id);
                })
                .OrderBy(_ => _)
                .LastOrDefault();

            if (maxId is 0)
            {
                maxId = 1;
            }

            var newid = maxId + 1;

            root.Add(
                new XElement(
                    propertyName,
                    new XAttribute("fmtid", "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"),
                    new XAttribute("pid", newid),
                    new XAttribute("name", "X-Protective-Marking"),
                    new XElement(vtNamespace + "lpwstr", marking)));
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