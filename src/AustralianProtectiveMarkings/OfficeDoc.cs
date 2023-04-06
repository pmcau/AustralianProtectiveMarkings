using System.IO.Compression;

public static class OfficeDoc
{
    public static Task PatchWord(Stream stream)
    {
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: false))
        {
            zip.Entries.Where(_=>_.Name == )
        }

        return Task.CompletedTask;
    }
}