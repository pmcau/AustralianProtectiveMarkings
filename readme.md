# <img src="/src/icon.png" height="30px"> Australian Protective Markings

[![Build status](https://ci.appveyor.com/api/projects/status/8kjm4utaiq58ok01/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/australianprotectivemarkings)
[![NuGet Status](https://img.shields.io/nuget/v/AustralianProtectiveMarkings.svg)](https://www.nuget.org/packages/AustralianProtectiveMarkings/)

A dotnet representation of Protective Markings defined in the [Australian Protective Security Policy Framework](https://www.protectivesecurity.gov.au/publications-library/policy-8-classification-system)

**See [Milestones](../../milestones?state=closed) for release notes.**

Spec:

 * [PSPF: Sensitive and classified information](https://www.protectivesecurity.gov.au/system/files/2023-08/annex-f-policy-8-classification-system-pspf.pdf)
 * [PSPF: Sensitive and classified information - Annex F (email clarifications)](https://www.protectivesecurity.gov.au/system/files/2023-08/annex-f-policy-8-classification-system-pspf.pdf)


## NuGet package

 * https://nuget.org/packages/AustralianProtectiveMarkings/
 * https://nuget.org/packages/Verify.AustralianProtectiveMarkings/


## Model

The model for handling a protective marking is `AustralianProtectiveMarkings.ProtectiveMarking`.

The `ProtectiveMarking` class structure is designed to be serialization friendly. So it can be used as part of data contracts.

All string members follow the convention of:

 * Max 128 characters
 * Characters allowed: 32-43 / 45-91 / 93-126
 * Escape character is `\`. Where `:`, `\`, and  `,` can be escaped. A `\` not followed by a one of those is treated as a single `\`.


## RenderEmailSubjectSuffix

Converts a protected marking to text that should be appended to an email subject line.

See "Subject Field Marking" in  [PSPF: Sensitive and classified information - Annex F (email clarifications)](https://www.protectivesecurity.gov.au/system/files/2023-08/annex-f-policy-8-classification-system-pspf.pdf)

> In this syntax, the protective marking is placed in the subject field of the message (RFC5322 ‘Subject’). As per
> RFC5322, an Internet email message can have at most one subject field. Allowing for no more than one email protective
> marking in the subject line minimises confusion and potential conflict.
> 
> A Subject Field Marking is less sophisticated than an Internet Message Header Extension as it is possible to
> manipulate an email’s subject during message generation or transport. However, it is easy to apply as a human
> user can construct (and interpret) the protective marking without the need for additional tools.


### Minimum content

<!-- snippet: RenderEmailSubjectSuffixMinimum -->
<a id='snippet-RenderEmailSubjectSuffixMinimum'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret
};
var result = marking.RenderEmailSubjectSuffix();
```
<sup><a href='/src/Tests/Samples.cs#L9-L17' title='Snippet source file'>snippet source</a> | <a href='#snippet-RenderEmailSubjectSuffixMinimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderEmailSubjectSuffixMinimum.verified.txt -->
<a id='snippet-Samples.RenderEmailSubjectSuffixMinimum.verified.txt'></a>
```txt
[SEC=TOP-SECRET]
```
<sup><a href='/src/Tests/Samples.RenderEmailSubjectSuffixMinimum.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderEmailSubjectSuffixMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: RenderEmailSubjectSuffixFull -->
<a id='snippet-RenderEmailSubjectSuffixFull'></a>
```cs
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
```
<sup><a href='/src/Tests/Samples.cs#L25-L49' title='Snippet source file'>snippet source</a> | <a href='#snippet-RenderEmailSubjectSuffixFull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderEmailSubjectSuffixFull.verified.txt -->
<a id='snippet-Samples.RenderEmailSubjectSuffixFull.verified.txt'></a>
```txt
[SEC=TOP-SECRET, CAVEAT=C:LOBSTER, CAVEAT=FG:USA caveat, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege]
```
<sup><a href='/src/Tests/Samples.RenderEmailSubjectSuffixFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderEmailSubjectSuffixFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## RenderEmailHeader

Converts a protected marking to text that should be added as the value opf the `X-Protective-Marking` email header.

See "Internet Message Header Extension" in  [PSPF: Sensitive and classified information - Annex F (email clarifications)](https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf)

> In this syntax, the protective marking is carried as a custom Internet Message Header Extension
> ‘X-Protective-Marking’. Allowing for no more than one ‘X-Protective-Marking’ field minimises confusion and potential
> conflict.
> 
> Using an Internet Message Header Extension is more sophisticated than a Subject Field Marking. It is designed for
> construction and parsing by email agents (clients, gateways and servers) as they have accessto internet message
> headers. In this way a richer syntax can be used and email agents can perform more complex handling based on
> the protective marking


### Minimum content

<!-- snippet: RenderEmailHeaderMinimum -->
<a id='snippet-RenderEmailHeaderMinimum'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret
};
var result = marking.RenderEmailHeader();
```
<sup><a href='/src/Tests/Samples.cs#L57-L65' title='Snippet source file'>snippet source</a> | <a href='#snippet-RenderEmailHeaderMinimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderEmailHeaderMinimum.verified.txt -->
<a id='snippet-Samples.RenderEmailHeaderMinimum.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET
```
<sup><a href='/src/Tests/Samples.RenderEmailHeaderMinimum.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderEmailHeaderMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: RenderEmailHeaderFull -->
<a id='snippet-RenderEmailHeaderFull'></a>
```cs
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
```
<sup><a href='/src/Tests/Samples.cs#L73-L97' title='Snippet source file'>snippet source</a> | <a href='#snippet-RenderEmailHeaderFull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderEmailHeaderFull.verified.txt -->
<a id='snippet-Samples.RenderEmailHeaderFull.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:LOBSTER, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com
```
<sup><a href='/src/Tests/Samples.RenderEmailHeaderFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderEmailHeaderFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## ApplyProtectiveMarkings

Extension method to apply protective markings to a [MailMessage ](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage)

<!-- snippet: ApplyProtectiveMarkings -->
<a id='snippet-ApplyProtectiveMarkings'></a>
```cs
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
```
<sup><a href='/src/Tests/Samples.cs#L150-L170' title='Snippet source file'>snippet source</a> | <a href='#snippet-ApplyProtectiveMarkings' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.ApplyProtectiveMarkings.verified.txt -->
<a id='snippet-Samples.ApplyProtectiveMarkings.verified.txt'></a>
```txt
{
  From: from@mail.com,
  To: to@mail.com,
  Subject: The subject [SEC=TOP-SECRET, CAVEAT=SH:CABINET, CAVEAT=RI:REL AFG, ACCESS=Legal-Privilege],
  Headers: {
    X-Protective-Marking: VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=SH:CABINET, CAVEAT=RI:REL AFG, ACCESS=Legal-Privilege
  },
  IsBodyHtml: false,
  Body: The body
}
```
<sup><a href='/src/Tests/Samples.ApplyProtectiveMarkings.verified.txt#L1-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.ApplyProtectiveMarkings.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## RenderDocumentHeaderAndFooter

`RenderDocumentHeaderAndFooter` generated a header and footer for a document.

See: [PSPF: Sensitive and classified information - Applying text-based protective markings](https://www.protectivesecurity.gov.au/system/files/2023-11/policy-8-classification-system-pspf_0.pd#C.5.1.1)

<!-- snippet: RenderDocumentHeaderAndFooter -->
<a id='snippet-RenderDocumentHeaderAndFooter'></a>
```cs
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
```
<sup><a href='/src/Tests/Samples.cs#L190-L204' title='Snippet source file'>snippet source</a> | <a href='#snippet-RenderDocumentHeaderAndFooter' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

Header:

```
SECRET//AUSTEO//CABINET
Legislative-Secrecy
```

Footer:

```
Legislative-Secrecy
SECRET//AUSTEO//CABINET
```


## ParseEmailHeader

Parses a `X-Protective-Marking` email header.

Also useful for when a protective marking needs to be store in a configuration file. In which case ParseEmailHeader can be used to load that text into a `ProtectiveMarking` which can be applied to documents or emails.


### Minimum content

<!-- snippet: ParseEmailHeaderMinimumOmit -->
<a id='snippet-ParseEmailHeaderMinimumOmit'></a>
```cs
var protectiveMarking = Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive");
```
<sup><a href='/src/Tests/Samples.cs#L105-L109' title='Snippet source file'>snippet source</a> | <a href='#snippet-ParseEmailHeaderMinimumOmit' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.ParseEmailHeaderMinimumOmit.verified.txt -->
<a id='snippet-Samples.ParseEmailHeaderMinimumOmit.verified.txt'></a>
```txt
{
  Classification: OfficialSensitive,
  Caveats: null,
  Expiry: null,
  PersonalPrivacy: false,
  LegalPrivilege: false,
  LegislativeSecrecy: false,
  Comment: null,
  AuthorEmail: null
}
```
<sup><a href='/src/Tests/Samples.ParseEmailHeaderMinimumOmit.verified.txt#L1-L10' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.ParseEmailHeaderMinimumOmit.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Omit Version and Namespace

The version and namespace is hard coded in the spec. Both can be omitted when parsing.

<!-- snippet: ParseEmailHeaderMinimumOmit -->
<a id='snippet-ParseEmailHeaderMinimumOmit'></a>
```cs
var protectiveMarking = Parser.ParseProtectiveMarking("SEC=OFFICIAL:Sensitive");
```
<sup><a href='/src/Tests/Samples.cs#L105-L109' title='Snippet source file'>snippet source</a> | <a href='#snippet-ParseEmailHeaderMinimumOmit' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: ParseEmailHeaderFull -->
<a id='snippet-ParseEmailHeaderFull'></a>
```cs
var protectiveMarking = Parser.ParseProtectiveMarking("VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=RI:REL AFG/DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");
```
<sup><a href='/src/Tests/Samples.cs#L178-L182' title='Snippet source file'>snippet source</a> | <a href='#snippet-ParseEmailHeaderFull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.ParseEmailHeaderFull.verified.txt -->
<a id='snippet-Samples.ParseEmailHeaderFull.verified.txt'></a>
```txt
{
  Classification: TopSecret,
  Caveats: {
    Codeword: CodeWord,
    ForeignGovernment: USA caveat,
    ExclusiveFor:  person,
    CountryCodes: [
      Afghanistan,
      Algeria
    ],
    Agao: true,
    Austeo: false,
    DelicateSource: false,
    Orcon: false,
    Cabinet: true,
    NationalCabinet: false
  },
  Expiry: {
    DownTo: Official,
    GenDate: 2020-10-01T00:00:00+00:00,
    Event: null
  },
  PersonalPrivacy: false,
  LegalPrivilege: true,
  LegislativeSecrecy: false,
  Comment: the comments,
  AuthorEmail: a@b.com
}
```
<sup><a href='/src/Tests/Samples.ParseEmailHeaderFull.verified.txt#L1-L28' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.ParseEmailHeaderFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Newlines

For readability, newlines are allowed to delineate key value pairs:

<!-- snippet: ParseEmailHeaderFullNewlines -->
<a id='snippet-ParseEmailHeaderFullNewlines'></a>
```cs
var protectiveMarking = Parser.ParseProtectiveMarking(
    """
    VER=2018.4,
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
```
<sup><a href='/src/Tests/Samples.cs#L216-L236' title='Snippet source file'>snippet source</a> | <a href='#snippet-ParseEmailHeaderFullNewlines' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## OfficeDocHelper

Protective markings can be applied to an office document (docx, xlsx, pptx) using OfficeDocHelper.

A custom property named `X-Protective-Marking` will be added.

<!-- snippet: OfficeDocHelperStream -->
<a id='snippet-OfficeDocHelperStream'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret
};
await OfficeDocHelper.Patch(stream, marking);
```
<sup><a href='/src/Tests/Samples.cs#L280-L288' title='Snippet source file'>snippet source</a> | <a href='#snippet-OfficeDocHelperStream' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<!-- snippet: OfficeDocHelperFile -->
<a id='snippet-OfficeDocHelperFile'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret
};
await OfficeDocHelper.Patch(filePath, marking);
```
<sup><a href='/src/Tests/Samples.cs#L294-L302' title='Snippet source file'>snippet source</a> | <a href='#snippet-OfficeDocHelperFile' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

<img src="/src/docxWithProps.png" width="400px">


## Icon

Icon [Protect](https://thenounproject.com/icon/protect-1173962/) from [The Noun Project](https://thenounproject.com).
