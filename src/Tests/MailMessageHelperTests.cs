using System.Net.Mail;

[TestFixture]
public class MailMessageHelperTests
{
    [Test]
    public Task ApplyProtectiveMarkings()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);

        return Verify(mail);
    }

    [Test]
    public Task TryReadProtectiveMarkings()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);
        IsTrue(mail.TryReadProtectiveMarkings(out var result));
        return Verify(result);
    }
}