using System.IO.Compression;
using System.Xml.Linq;

namespace AustralianProtectiveMarkings;

public static class OfficeDoc
{
    const string customPropsFileName = @"docProps/custom.xml";

    public static void PatchWord(Stream stream, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        using var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: false);
        var zipArchiveEntry = zip.Entries.SingleOrDefault(_ => _.FullName == customPropsFileName);
        if (zipArchiveEntry == null)
        {
            zipArchiveEntry = zip.CreateEntry(customPropsFileName);
            using var writer = new StreamWriter(zipArchiveEntry.Open());
            writer.Write($$"""
                        <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                        <Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/custom-properties" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
                            <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}" pid="2" name="X-Protective-Marking">
                                <vt:lpwstr>{{header}}</vt:lpwstr>
                            </property>
                        </Properties>
                        """);
            return;
        }

        var xDocument = new XDocument(new StreamReader(zipArchiveEntry.Open()).ReadToEnd());
        AddHeader(xDocument, marking);
    }

    internal static void AddHeader(XDocument xDocument, ProtectiveMarking marking)
    {
        var header = marking.RenderEmailHeader();
        var property = xDocument
            .Descendants()
            .SingleOrDefault(_ => _.Name.LocalName == "property" &&
                                  _.Attribute("name")?.Value == "X-Protective-Marking");
        if (property == null)
        {
            xDocument.Root!.Add(
                XElement.Parse($$"""
                    <property fmtid="{D5CDD505-2E9C-101B-9397-08002B2CF9AE}"
                              pid="2"
                              name="X-Protective-Marking">
                        <vt:lpwstr>{{header}}</vt:lpwstr>
                    </property>
                    """));
        }
        else
        {
            var xElement = property
                .Elements()
                .Single(_ => _.Name.LocalName == "lpwstr");
            xElement.Value = header;
        }
    }
}