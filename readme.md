# <img src="/src/icon.png" height="30px"> Australian Protective Markings

[![Build status](https://ci.appveyor.com/api/projects/status/8kjm4utaiq58ok01/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/australianprotectivemarkings)
[![NuGet Status](https://img.shields.io/nuget/v/AustralianProtectiveMarkings.svg)](https://www.nuget.org/packages/AustralianProtectiveMarkings/)

A dotnet representation of Protective Markings defined in the [Australian Protective Security Policy Framework](https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information)

Spec:

 * [PSPF: Sensitive and classified information](https://www.protectivesecurity.gov.au/system/files/2023-01/pspf-policy-08-sensitive-and-classified-information.pdf)
 * [PSPF: Sensitive and classified information - Annex F (email clarifications)](https://www.protectivesecurity.gov.au/system/files/2022-12/annex-f-pspf-policy8-sensitive-and-classified-information.pdf)


## NuGet package

https://nuget.org/packages/AustralianProtectiveMarkings/


## Model

The model for handling a protective marking is `AustralianProtectiveMarkings.ProtectiveMarking`.

The `ProtectiveMarking` class structure is designed to be serialization friendly. So it can be used as part of data contracts.

All string members follow the convention of:

 * Max 128 characters
 * Characters allowed: 32-43 / 45-91 / 93-126
 * Escape character is `\`. Where `:`, `\`, and  `,` can be escaped. A `\` not followed by a one of those is treated as a single '\'.


## RenderSubject


### Minimum content

<!-- snippet: RenderSubjectMinimum -->
<a id='snippet-rendersubjectminimum'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret,
};
var result = marking.RenderSubject();
```
<sup><a href='/src/Tests/SamplesTests.cs#L7-L15' title='Snippet source file'>snippet source</a> | <a href='#snippet-rendersubjectminimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderSubjectMinimum.verified.txt -->
<a id='snippet-Samples.RenderSubjectMinimum.verified.txt'></a>
```txt
[SEC=TOP-SECRET]
```
<sup><a href='/src/Tests/Samples.RenderSubjectMinimum.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderSubjectMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: RenderSubjectFull -->
<a id='snippet-rendersubjectfull'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret,
    Expiry = new Expiry
    {
        DownTo = Classification.Official,
        GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
    },
    Comment = "the comments",
    AuthorEmail = "a@b.com",
    LegalPrivilege = true,
    Caveats = new Caveats
    {
        Codeword = "CodeWord",
        ForeignGovernment = "USA caveat",
        Cabinet = true,
        ExclusiveFor = "person",
        Country = Country.Afghanistan
    }
};
var result = marking.RenderSubject();
```
<sup><a href='/src/Tests/SamplesTests.cs#L23-L47' title='Snippet source file'>snippet source</a> | <a href='#snippet-rendersubjectfull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderSubjectFull.verified.txt -->
<a id='snippet-Samples.RenderSubjectFull.verified.txt'></a>
```txt
[SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege]
```
<sup><a href='/src/Tests/Samples.RenderSubjectFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderSubjectFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## RenderHeader


### Minimum content

<!-- snippet: RenderHeaderMinimum -->
<a id='snippet-renderheaderminimum'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret,
};
var result = marking.RenderHeader();
```
<sup><a href='/src/Tests/SamplesTests.cs#L55-L63' title='Snippet source file'>snippet source</a> | <a href='#snippet-renderheaderminimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderHeaderMinimum.verified.txt -->
<a id='snippet-Samples.RenderHeaderMinimum.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET
```
<sup><a href='/src/Tests/Samples.RenderHeaderMinimum.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderHeaderMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: RenderHeaderFull -->
<a id='snippet-renderheaderfull'></a>
```cs
var marking = new ProtectiveMarking
{
    Classification = Classification.TopSecret,
    Expiry = new Expiry
    {
        DownTo = Classification.Official,
        GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
    },
    Comment = "the comments",
    AuthorEmail = "a@b.com",
    LegalPrivilege = true,
    Caveats = new Caveats
    {
        Codeword = "CodeWord",
        ForeignGovernment = "USA caveat",
        Agao = true,
        ExclusiveFor = "person",
        Country = Country.Afghanistan
    }
};
var result = marking.RenderHeader();
```
<sup><a href='/src/Tests/SamplesTests.cs#L71-L95' title='Snippet source file'>snippet source</a> | <a href='#snippet-renderheaderfull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderHeaderFull.verified.txt -->
<a id='snippet-Samples.RenderHeaderFull.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com
```
<sup><a href='/src/Tests/Samples.RenderHeaderFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderHeaderFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Parse


### Minimum content

<!-- snippet: ParseMinimum -->
<a id='snippet-parseminimum'></a>
```cs
var protectiveMarking = Parser.Parse("VER=2018.4, NS=gov.au, SEC=OFFICIAL:Sensitive");
```
<sup><a href='/src/Tests/SamplesTests.cs#L115-L119' title='Snippet source file'>snippet source</a> | <a href='#snippet-parseminimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.ParseMinimum.verified.txt -->
<a id='snippet-Samples.ParseMinimum.verified.txt'></a>
```txt
{
  Classification: OfficialSensitive,
  PersonalPrivacy: false,
  LegalPrivilege: false,
  LegislativeSecrecy: false
}
```
<sup><a href='/src/Tests/Samples.ParseMinimum.verified.txt#L1-L6' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.ParseMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Omit Version and Namespace

The version and namespace is hard coded in the spec. Both can be omitted when parsing.

<!-- snippet: ParseMinimumOmit -->
<a id='snippet-parseminimumomit'></a>
```cs
var protectiveMarking = Parser.Parse("SEC=OFFICIAL:Sensitive");
```
<sup><a href='/src/Tests/SamplesTests.cs#L103-L107' title='Snippet source file'>snippet source</a> | <a href='#snippet-parseminimumomit' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Full content

<!-- snippet: ParseFull -->
<a id='snippet-parsefull'></a>
```cs
var protectiveMarking = Parser.Parse("VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, CAVEAT=SH:EXCLUSIVE-FOR DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com");
```
<sup><a href='/src/Tests/SamplesTests.cs#L127-L131' title='Snippet source file'>snippet source</a> | <a href='#snippet-parsefull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.ParseFull.verified.txt -->
<a id='snippet-Samples.ParseFull.verified.txt'></a>
```txt
{
  Classification: TopSecret,
  Caveats: {
    Codewords: [
      CodeWord
    ],
    ForeignGovernments: [
      USA caveat
    ],
    ExclusiveFors: [
       person,
       AFG,
       DZA
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
    GenDate: DateTimeOffset_1
  },
  PersonalPrivacy: false,
  LegalPrivilege: true,
  LegislativeSecrecy: false,
  Comment: the comments,
  AuthorEmail: a@b.com
}
```
<sup><a href='/src/Tests/Samples.ParseFull.verified.txt#L1-L31' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.ParseFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Newlines

For readability, newlines are allowed to delineate key value pairs:

<!-- snippet: ParseFullNewlines -->
<a id='snippet-parsefullnewlines'></a>
```cs
var protectiveMarking = Parser.Parse("""
    VER=2018.4,
    NS=gov.au,
    SEC=TOP-SECRET,
    CAVEAT=C:CodeWord,
    CAVEAT=FG:USA caveat,
    CAVEAT=RI:AGAO,
    CAVEAT=SH:CABINET,
    CAVEAT=SH:EXCLUSIVE-FOR person,
    CAVEAT=SH:EXCLUSIVE-FOR AFG,
    CAVEAT=SH:EXCLUSIVE-FOR DZA,
    EXPIRES=2020-10-01,
    DOWNTO=OFFICIAL,
    ACCESS=Legal-Privilege,
    NOTE=the comments,
    ORIGIN=a@b.com
    """);
```
<sup><a href='/src/Tests/SamplesTests.cs#L139-L159' title='Snippet source file'>snippet source</a> | <a href='#snippet-parsefullnewlines' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

Icon [Protect](https://thenounproject.com/icon/protect-1173962/) from [The Noun Project](https://thenounproject.com).
