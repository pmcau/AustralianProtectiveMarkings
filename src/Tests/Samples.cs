using System.Net.Mail;

[TestFixture]
public class Samples
{
    [Test]
    public Task RenderEmailSubjectSuffixMinimum()
    {
        #region RenderEmailSubjectSuffixMinimum

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        var result = marking.RenderEmailSubjectSuffix();

        #endregion

        return Verify(result).NotInline();
    }

    [Test]
    public Task RenderEmailSubjectSuffixFull()
    {
        #region RenderEmailSubjectSuffixFull

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
            Expiry = new()
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero)
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new()
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "USA caveat",
                Cabinet = true,
                ExclusiveFor = "person",
                Country = Country.Afghanistan
            }
        };
        var result = marking.RenderEmailSubjectSuffix();

        #endregion

        return Verify(result)
            .Snapshot("[SEC=TOP-SECRET, CAVEAT=C:LOBSTER, CAVEAT=FG:USA caveat, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege]");
    }

    [Test]
    public Task RenderEmailHeaderMinimum()
    {
        #region RenderEmailHeaderMinimum

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        var result = marking.RenderEmailHeader();

        #endregion

        return Verify(result)
            .NotInline();
    }

    [Test]
    public Task RenderEmailHeaderFull()
    {
        #region RenderEmailHeaderFull

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
            Expiry = new()
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero)
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new()
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "USA caveat",
                Agao = true,
                ExclusiveFor = "person",
                Country = Country.Afghanistan
            }
        };
        var result = marking.RenderEmailHeader();

        #endregion

        return Verify(result)
            .NotInline();
    }

    [Test]
    public Task ParseEmailHeaderMinimumOmit()
    {
        #region ParseEmailHeaderMinimumOmit

        var protectiveMarking = Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(SerializeForDocs(protectiveMarking))
            .NotInline();
    }

    static string SerializeForDocs(object value)
    {
        var builder = new StringBuilder();
        using (var stringWriter = new StringWriter(builder))
        using (var jsonWriter = new JsonTextWriter(stringWriter)
               {
                   QuoteName = false,
                   QuoteValue = false
               })
        {
            var jsonSerializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            jsonSerializer.Converters.Add(new StringEnumConverter());
            jsonSerializer.Serialize(jsonWriter, value);
        }

        return builder.ToString();
    }

    [Test]
    public Task ParseEmailHeaderMinimum()
    {
        #region ParseEmailHeaderMinimum

        var protectiveMarking = Parser.ParseProtectiveMarking("VER=2025.1, NS=gov.au, SEC=OFFICIAL:Sensitive");

        #endregion

        return Verify(protectiveMarking)
            .Snapshot("OfficialSensitive");
    }

    [Test]
    public Task ApplyProtectiveMarkings()
    {
        #region ApplyProtectiveMarkings

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
            LegalPrivilege = true,
            Caveats = new()
            {
                Cabinet = true,
                Country = Country.Afghanistan
            }
        };

        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com",
            subject: "The subject",
            body: "The body");
        mail.ApplyProtectiveMarkings(marking);

        #endregion

        return Verify(mail)
            .Snapshot(
                """
                {
                  From: from@mail.com,
                  To: to@mail.com,
                  Subject: The subject [SEC=TOP-SECRET, CAVEAT=SH:CABINET, CAVEAT=RI:REL AFG, ACCESS=Legal-Privilege],
                  Headers: {
                    X-Protective-Marking: VER=2025.1, NS=gov.au, SEC=TOP-SECRET, CAVEAT=SH:CABINET, CAVEAT=RI:REL AFG, ACCESS=Legal-Privilege
                  },
                  IsBodyHtml: false,
                  Body: The body
                }
                """);
    }

    [Test]
    public Task ParseEmailHeaderFull()
    {
        #region ParseEmailHeaderFull

        var protectiveMarking = Parser.ParseProtectiveMarking("VER=2024.1, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG/DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");

        #endregion

        return Verify(SerializeForDocs(protectiveMarking));
    }

    [Test]
    public Task RenderDocumentHeaderAndFooter()
    {
        #region RenderDocumentHeaderAndFooter

        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret,
            LegislativeSecrecy = true,
            Caveats = new()
            {
                Cabinet = true,
                Austeo = true
            }
        };
        var (header, footer) = marking.RenderDocumentHeaderAndFooter();

        #endregion

        return Verify(new
        {
            header,
            footer
        })
        .Snapshot(
            """
            {
              header:
            SECRET//AUSTEO//CABINET
            Legislative-Secrecy,
              footer:
            Legislative-Secrecy
            SECRET//AUSTEO//CABINET
            }
            """);
    }

    [Test]
    public Task ParseEmailHeaderFullNewlines()
    {
        #region ParseEmailHeaderFullNewlines

        var protectiveMarking = Parser.ParseProtectiveMarking(
            """
            VER=2024.1,
            NS=gov.au,
            SEC=TOP-SECRET,
            CAVEAT=C:CodeWord,
            CAVEAT=FG:USA caveat,
            CAVEAT=RI:AGAO,
            CAVEAT=SH:CABINET,
            CAVEAT=SH:EXCLUSIVE-FOR person,
            CAVEAT=RI:REL AFG/DZA,
            EXPIRES=2020-10-01,
            DOWNTO=OFFICIAL,
            ACCESS=Legal-Privilege,
            NOTE=the comments,
            ORIGIN=a@b.com
            """);

        #endregion

        return Verify(SerializeForDocs(protectiveMarking));
    }

    [Test]
    public Task DefineMultiple()
    {
        #region DefineMultiple

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret,
            Expiry = new()
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero)
            },
            Comment = "the comments",
            AuthorEmail = "a@b.com",
            LegalPrivilege = true,
            Caveats = new()
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "USA caveat",
                Agao = true,
                Cabinet = true,
                ExclusiveFor = "person",
                CountryCodes =
                [
                    Country.Afghanistan,
                    Country.Algeria
                ]
            }
        };

        #endregion

        return Verify(marking);
    }

    // ReSharper disable once ReplaceAsyncWithTaskReturn
    static async Task OfficeDocHelperSample(Stream stream)
    {
        #region OfficeDocHelperStream

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        await OfficeDocHelper.Patch(stream, marking);

        #endregion
    }

    // ReSharper disable once ReplaceAsyncWithTaskReturn
    static async Task OfficeDocHelperSample(string filePath)
    {
        #region OfficeDocHelperFile

        var marking = new ProtectiveMarking
        {
            Classification = Classification.TopSecret
        };
        await OfficeDocHelper.Patch(filePath, marking);

        #endregion
    }
}
