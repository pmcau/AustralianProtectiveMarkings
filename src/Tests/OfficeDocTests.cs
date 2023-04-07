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
        File.Delete(@"C:\Code\wordhacking\doc.docx");
        await using var fileStream = File.OpenWrite(@"C:\Code\wordhacking\doc.docx");
        await memoryStream.CopyToAsync(fileStream);
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

    // <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
    // <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
    // <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}" pid="2" name="aaaa">
    // <vt:lpwstr>aaa</vt:lpwstr>
    // </property>
    // <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}" pid="3" name="bbbb">
    // <vt:lpwstr>bbbb</vt:lpwstr>
    // </property>
    // </Properties>
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

    [Test]
    public Task AddCustomRelsXml()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                    <Relationship Id="rId3"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties"
                                  Target="docProps/app.xml"/>
                    <Relationship Id="rId2"
                                  Type="http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties"
                                  Target="docProps/core.xml"/>
                    <Relationship Id="rId1"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
                                  Target="word/document.xml"/>
                </Relationships>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDoc.EnsureCustomXmlInRels(document);
        return Verify(document);
    }

    [Test]
    public Task AddCustomRelsXml_existing()
    {
        var xml = """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
                    <Relationship Id="rId3"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties"
                                  Target="docProps/app.xml"/>
                    <Relationship Id="rId2"
                                  Type="http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties"
                                  Target="docProps/core.xml"/>
                    <Relationship Id="rId1"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
                                  Target="word/document.xml"/>
                    <Relationship Id="rId4"
                                  Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/custom-properties"
                                  Target="docProps/custom.xml"/>
                </Relationships>
                """;
        var document = XDocument.Load(new StringReader(xml));
        OfficeDoc.EnsureCustomXmlInRels(document);
        return Verify(document);
    }
}