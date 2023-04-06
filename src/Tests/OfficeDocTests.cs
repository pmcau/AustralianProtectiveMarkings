using System.Xml;
using System.Xml.Linq;

[TestFixture]
public class OfficeDocTests
{
    // [Test]
    // public async Task Parse()
    // {
    //     var memoryStream = new MemoryStream();
    //     await Resourcer.Resource.AsStream("doc.docx").CopyToAsync(memoryStream);
    //     await OfficeDoc.PatchWord(memoryStream);
    // }

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
        OfficeDoc.AddHeader(document, "newValue");
        return Verify(document);
    }
}