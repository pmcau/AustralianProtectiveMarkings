[TestFixture]
public class OfficeDocTests
{
    [Test]
    public async Task Simple()
    {
        var memoryStream = new MemoryStream();
        await Resourcer.Resource.AsStream("docs/noProps.docx").CopyToAsync(memoryStream);
        OfficeDoc.PatchWord(
            memoryStream,
            new()
            {
                Classification = Classification.Protected
            });
        memoryStream.Position = 0;
        File.Delete(@"C:\Code\doc.docx");
        using var fileStream = File.OpenWrite(@"C:\Code\doc.docx");
        memoryStream.CopyTo(fileStream);
    }

    [Test]
    public Task UpdateHeader()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties"
                            xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="2"
                              name="X-Protective-Marking">
                        <vt:lpwstr>oldValue</vt:lpwstr>
                    </property>
                </Properties>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDoc.SetHeader(document, "newValue");
        return Verify(document);
    }

    [Test]
    public Task AddHeader()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties"
                            xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                </Properties>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDoc.SetHeader(document, "value");
        return Verify(document);
    }

    [Test]
    public Task AddCustomXml()
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
        OfficeDoc.EnsureCustomXmlInContentTypes(document);
        return Verify(document);
    }
    [Test]
    public Task AddCustomXml_existing()
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
        OfficeDoc.EnsureCustomXmlInContentTypes(document);
        return Verify(document);
    }
}