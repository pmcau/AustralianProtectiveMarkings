using System.Net.Mail;

namespace AustralianProtectiveMarkings;

public static class MailMessageHelper
{
    public static void ApplyProtectiveMarkings(this MailMessage mail, ProtectiveMarking marking)
    {
        mail.Subject = $"{mail.Subject} {marking.RenderEmailSubjectSuffix()}";
        mail.Headers["X-Protective-Marking"] = marking.RenderEmailHeader();
    }

    public static bool TryReadProtectiveMarkings(
        this MailMessage mail,
        [NotNullWhen(true)] out ProtectiveMarking? marking)
    {
        var mailHeader = mail.Headers["X-Protective-Marking"];
        if (mailHeader == null)
        {
            marking = null;
            return false;
        }

        marking = Parser.ParseProtectiveMarking(mailHeader.AsSpan());
        return true;
    }
}