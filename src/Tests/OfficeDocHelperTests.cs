using DocumentFormat.OpenXml.Packaging;

[TestFixture]
public class OfficeDocHelperTests
{
    [Test]
    public async Task Patch()
    {
        var assembly = GetType().Assembly;
        var dictionary = new Dictionary<string, string>();
        foreach (var resourceName in assembly.GetManifestResourceNames())
        {
            await using var resourceStream = assembly.GetManifestResourceStream(resourceName)!;
            using var stream = new MemoryStream();
            await resourceStream.CopyToAsync(stream);
            await OfficeDocHelper.Patch(
                stream,
                new()
                {
                    Classification = Classification.Protected
                });
            var propertyOuterXml = GetProperty(stream, resourceName);
            dictionary.Add(resourceName, "\n" + propertyOuterXml);
        }

        await Verify(dictionary);
    }

    [Test]
    public async Task TryReadProtectiveMarkings()
    {
        var assembly = GetType().Assembly;

        ProtectiveMarking protectiveMarking = new()
        {
            Classification = Classification.TopSecret,
            Expiry = new Expiry
            {
                DownTo = Classification.Protected,
                GenDate = new DateTimeOffset(new(2020, 10, 1))
            },
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "usa caveat",
                Agao = true,
                Cabinet = true,
                ExclusiveFor = "person",
                CountryCodes = new[]
                {
                    Country.Afghanistan,
                    Country.Algeria
                }
            }
        };

        var resourceName = assembly.GetManifestResourceNames().First(x => x.Contains("noProps.docx"));
        await using var resourceStream = assembly.GetManifestResourceStream(resourceName)!;
        using var stream = new MemoryStream();
        stream.Seek(0, SeekOrigin.Begin);
        await resourceStream.CopyToAsync(stream);
        await OfficeDocHelper.Patch(
            stream,
            protectiveMarking);


        OfficeDocHelper.TryReadProtectiveMarkings(
            stream,
            out var outProtectiveMarking);

        await Verify(new
        {
            protectiveMarking,
            outProtectiveMarking
        });
    }


    [Test]
    public async Task TryReadProtectiveMarkings_Existing_File_Stream()
    {
        var assembly = GetType().Assembly;

        var resourceName = assembly.GetManifestResourceNames().First(x => x.Contains("correctProps.docx"));
        await using var resourceStream = assembly.GetManifestResourceStream(resourceName)!;
        using var stream = new MemoryStream();
        stream.Seek(0, SeekOrigin.Begin);
        await resourceStream.CopyToAsync(stream);

        OfficeDocHelper.TryReadProtectiveMarkings(
            stream,
            out var outProtectiveMarking);

        await Verify(new
        {
            outProtectiveMarking
        });
    }

    static string GetProperty(MemoryStream stream, string resourceName)
    {
        stream.Position = 0;

        if (resourceName.EndsWith("docx"))
        {
            using var document = WordprocessingDocument.Open(stream, false);
            var property = document.CustomFilePropertiesPart!.Properties.Single();
            return property.OuterXml;
        }

        if (resourceName.EndsWith("pptx"))
        {
            using var document = PresentationDocument.Open(stream, false);
            var property = document.CustomFilePropertiesPart!.Properties.Single();
            return property.OuterXml;
        }

        if (resourceName.EndsWith("xlsx"))
        {
            using var document = SpreadsheetDocument.Open(stream, false);
            var property = document.CustomFilePropertiesPart!.Properties.Single();
            return property.OuterXml;
        }

        throw new InvalidOperationException();
    }

    [Test]
    public Task SetHeader()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties"
                            xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="1"
                              name="otherKey">
                        <vt:lpwstr>value</vt:lpwstr>
                    </property>
                </Properties>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.SetHeader(document, "value");
        return Verify(document);
    }

    [Test]
    public Task SetHeader_existing()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties"
                            xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="1"
                              name="X-Protective-Marking">
                        <vt:lpwstr>oldValue</vt:lpwstr>
                    </property>
                </Properties>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.SetHeader(document, "newValue");
        return Verify(document);
    }

    [Test]
    public Task EnsureCustomXmlInContentTypes()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
                    <Default Extension="rels"
                             ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
                    <Override PartName="/word/webSettings.xml"
                              ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.webSettings+xml"/>
                </Types>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.EnsureCustomXmlInContentTypes(document);
        return Verify(document);
    }

    [Test]
    public Task EnsureCustomXmlInContentTypes_existing()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
                    <Default Extension="rels"
                             ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
                    <Override PartName="/word/webSettings.xml"
                              ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.webSettings+xml"/>
                    <Override PartName="/docProps/custom.xml"
                              ContentType="application/vnd.openxmlformats-officedocument.custom-properties+xml"/>
                </Types>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.EnsureCustomXmlInContentTypes(document);
        return Verify(document);
    }

    [Test]
    public Task EnsureCustomXmlInRels()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                    <Relationship Id="rId1"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
                                  Target="word/document.xml"/>
                </Relationships>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.EnsureCustomXmlInRels(document);
        return Verify(document);
    }

    [Test]
    public Task EnsureCustomXmlInRels_existing()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                    <Relationship Id="rId1"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
                                  Target="word/document.xml"/>
                    <Relationship Id="rId2"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties"
                                  Target="docProps/custom.xml"/>
                </Relationships>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDocHelper.EnsureCustomXmlInRels(document);
        return Verify(document);
    }
}