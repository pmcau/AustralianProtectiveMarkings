using System.Net.Mail;

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
            .NotInline();
    }

    [Test]
    public async Task TryReadProtectiveMarkings()
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
        var found = mail.TryReadProtectiveMarkings(out var result);
        await Assert.That(found).IsTrue();
        await Verify(result)
            .Snapshot("TopSecret");
    }
}
