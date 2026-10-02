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
        var propertyName = root.Name.Namespace + "property";
        var property = root
            .Elements(propertyName)
            .SingleOrDefault(
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
        // ZipArchiveMode.Update requires read, write, and seek
        // ReSharper disable once UseAwaitUsing
        using var stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
        await Patch(stream, marking);
    }

    public static async Task Patch(Stream stream, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        // ReSharper disable once UseAwaitUsing
        using var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true);
        // Both looked up before anything is written, so a zip that is not an Office document is
        // refused whole rather than left with a custom properties part and nothing pointing at it.
        var contentTypes = GetPackageEntry(zip, "[Content_Types].xml", nameof(stream));
        var relationships = GetPackageEntry(zip, "_rels/.rels", nameof(stream));
        await EnsureCustomPropertyEntry(zip, header);
        await contentTypes.EditXmlEntry(EnsureCustomXmlInContentTypes);
        await relationships.EditXmlEntry(EnsureCustomXmlInRels);
    }

    static ZipArchiveEntry GetPackageEntry(ZipArchive zip, string name, string parameter)
    {
        var entry = zip.GetEntry(name);
        if (entry == null)
        {
            throw new ArgumentException($"Not an Office document. The package has no '{name}'.", parameter);
        }

        return entry;
    }

    internal static void EnsureCustomXmlInContentTypes(XDocument document)
    {
        var root = document.Root!;
        var overrideName = root.Name.Namespace + "Override";
        var overrideElement = root
            .Elements(overrideName)
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

    internal static void EnsureCustomXmlInRels(XDocument document)
    {
        var root = document.Root!;
        var relationshipName = root.Name.Namespace + "Relationship";
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

        // A relationship id is any unique string. Office numbers them rId1, rId2 and so on, but the
        // OpenXml SDK names a part it adds "R" and 16 hex digits. So the new id is numbered after
        // the highest one of the rId shape, which no id of another shape can collide with.
        var number = relationships
            .Select(_ => RelationshipNumber(_.Attribute("Id")!.Value))
            .DefaultIfEmpty(0)
            .Max() + 1;

        root.Add(
            new XElement(
                relationshipName,
                new XAttribute("Id", $"rId{number}"),
                new XAttribute("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties"),
                new XAttribute("Target", "docProps/custom.xml")));
    }

    static int RelationshipNumber(string id)
    {
        if (id.StartsWith("rId", StringComparison.Ordinal) &&
            int.TryParse(id[3..], NumberStyles.None, CultureInfo.InvariantCulture, out var number))
        {
            return number;
        }

        return 0;
    }

    static async Task EnsureCustomPropertyEntry(ZipArchive zip, string header)
    {
        var entry = zip.GetEntry(customPropsFileName);
        if (entry == null)
        {
            entry = zip.CreateEntry(customPropsFileName);
            // ReSharper disable once UseAwaitUsing
            using var stream = await entry.OpenAsync();
            // ReSharper disable once UseAwaitUsing
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

    // The namespace itself, not the "vt" prefix it is usually bound to: an element named with a
    // prefix as its namespace is written as <lpwstr xmlns="vt">, which no reader recognises as a
    // string value.
    static XNamespace vtNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes";

    internal static void SetHeader(XDocument document, string marking)
    {
        var root = document.Root!;
        // The root's own namespace rather than the default one: Office declares it as the default,
        // but the OpenXml SDK writes it with an "op" prefix, which leaves the default namespace empty.
        var propertyName = root.Name.Namespace + "property";
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