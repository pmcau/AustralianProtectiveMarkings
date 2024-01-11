namespace AustralianProtectiveMarkings;

public static class OfficeDocHelper
{
    const string customPropsFileName = "docProps/custom.xml";

    public static bool TryReadProtectiveMarkings(
        string file,
        [NotNullWhen(true)] out ProtectiveMarking? marking)
    {
        using var stream = File.OpenRead(file);
        return TryReadProtectiveMarkings(stream, out marking);
    }

    public static bool TryReadProtectiveMarkings(
        Stream stream,
        [NotNullWhen(true)] out ProtectiveMarking? marking)
    {
        marking = null;
        using var zip = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: false);

        var entry = zip.GetEntry(customPropsFileName);
        if (entry == null)
        {
            return false;
        }

        using var docStream = entry.Open();
        using var reader = new StreamReader(docStream);
        var document = XDocument.Load(reader);
        var root = document.Root!;
        var propertyName = root.GetDefaultNamespace() + "property";
        var properties = root
            .Elements(propertyName)
            .ToList();
        var property = properties.SingleOrDefault(
            _ => _.Attribute("name")
                ?.Value == "X-Protective-Marking");

        if (property == null)
        {
            return false;
        }

        var element = property
            .Elements()
            .Single(_ => _.Name.LocalName == "lpwstr");
        marking = Parser.ParseProtectiveMarking(element.Value);
        return true;
    }

    public static async Task Patch(string file, ProtectiveMarking marking)
    {
        using var stream = File.OpenRead(file);
        await Patch(stream, marking);
    }

    public static async Task Patch(Stream stream, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        using var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true);
        await EnsureCustomPropertyEntry(zip, header);
        await EnsureCustomXmlInContentTypes(zip);
        await EnsureCustomXmlInRels(zip);
    }

    static Task EnsureCustomXmlInContentTypes(ZipArchive zip)
    {
        var entry = zip.GetEntry("[Content_Types].xml")!;
        return entry.EditXmlEntry(EnsureCustomXmlInContentTypes);
    }

    internal static void EnsureCustomXmlInContentTypes(XDocument document)
    {
        var root = document.Root!;
        var overrideName = root.GetDefaultNamespace() + "Override";
        var overrides = root
            .Elements(overrideName)
            .ToList();

        var overrideElement = overrides
            .SingleOrDefault(_ => _.Attribute("PartName")
                ?.Value == "/docProps/custom.xml");

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

    static Task EnsureCustomXmlInRels(ZipArchive zip)
    {
        var entry = zip.GetEntry("_rels/.rels")!;
        return entry.EditXmlEntry(EnsureCustomXmlInRels);
    }

    internal static void EnsureCustomXmlInRels(XDocument document)
    {
        var root = document.Root!;
        var relationshipName = root.GetDefaultNamespace() + "Relationship";
        var relationships = root
            .Elements(relationshipName)
            .ToList();
        var overrideElement = relationships
            .SingleOrDefault(_ => _.Attribute("Target")
                ?.Value == "docProps/custom.xml");

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

    static async Task EnsureCustomPropertyEntry(ZipArchive zip, string header)
    {
        var entry = zip.GetEntry(customPropsFileName);
        if (entry == null)
        {
            entry = zip.CreateEntry(customPropsFileName);
            using var stream = entry.Open();
            using var writer = new StreamWriter(stream);
            await writer.WriteAsync(
                $$"""
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
            await entry.EditXmlEntry(_ => SetHeader(_, header));
        }
    }

    static XNamespace vtNamespace = "vt";

    internal static void SetHeader(XDocument document, string marking)
    {
        var root = document.Root!;
        var propertyName = root.GetDefaultNamespace() + "property";
        var properties = root
            .Elements(propertyName)
            .ToList();
        var property = properties.SingleOrDefault(_ => _.Attribute("name")
            ?.Value == "X-Protective-Marking");
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