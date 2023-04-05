using System.IO.Compression;

public static class OfficeDoc
{
    public static Task PatchWord(Stream stream)
    {
        var zip = ZipFile.Open(stream,ZipArchiveMode.Update);
        return new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: false, entryNameEncoding: entryNameEncoding);
        return Task.CompletedTask;
    }
}