using System.Net.Mail;

[TestFixture]
public class MailMessageHelperTests
{
    [Test]
    public Task ApplyProtectiveMarkings()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);

        return Verify(mail)
            .Snapshot(
                """
                {
                  From: from@mail.com,
                  To: to@mail.com,
                  Subject: The subject [SEC=TOP-SECRET],
                  Headers: {
                    X-Protective-Marking: VER=2025.1, NS=gov.au, SEC=TOP-SECRET
                  },
                  IsBodyHtml: false,
                  Body: The body
                }
                """);
    }

    [Test]
    public Task TryReadProtectiveMarkings()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);
        IsTrue(mail.TryReadProtectiveMarkings(out var result));
        return Verify(result)
            .Snapshot("TopSecret");
    }
}