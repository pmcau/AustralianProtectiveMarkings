# <img src="/src/icon.png" height="30px"> Australian Protective Markings

[![Build status](https://ci.appveyor.com/api/projects/status/mds12hp4duduyie8/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/australianprotectivemarkings)
[![NuGet Status](https://img.shields.io/nuget/v/AustralianProtectiveMarkings.svg)](https://www.nuget.org/packages/AustralianSecurityClassifications/)

A dotnet representaion of [Protective Security Policy Framework](https://www.protectivesecurity.gov.au/publications-library/policy-8-sensitive-and-classified-information)

## Render


### Subject


#### Minimum content

<!-- snippet: RenderSubjectMinimum -->
<a id='snippet-rendersubjectminimum'></a>
```cs
var marking = new ProtectiveMarking
{
    SecurityClassification = SecurityClassification.TopSecret,
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


#### Full content

<!-- snippet: RenderSubjectFull -->
<a id='snippet-rendersubjectfull'></a>
```cs
var marking = new ProtectiveMarking
{
    SecurityClassification = SecurityClassification.TopSecret,
    Expiry = new Expiry
    {
        DownTo = SecurityClassification.Official,
        GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
    },
    Comment = "the comments",
    AuthorEmail = "a@b.com",
    InformationManagementMarkers = new[]
    {
        InformationManagementMarker.LegalPrivilege
    },
    CodewordCaveats = new[]
    {
        "CodeWord"
    },
    ForeignGovernmentCaveats = new[]
    {
        "USA caveat"
    },
    CaveatTypes = new[]
    {
        CaveatType.Agao,
        CaveatType.Cabinet,
    },
    ExclusiveForCaveats = new[]
    {
        "person"
    },
    CountryCodeCaveats = new[]
    {
        CountryCode.Afghanistan,
        CountryCode.Algeria
    }
};
var result = marking.RenderSubject();
```
<sup><a href='/src/Tests/SamplesTests.cs#L23-L64' title='Snippet source file'>snippet source</a> | <a href='#snippet-rendersubjectfull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderSubjectFull.verified.txt -->
<a id='snippet-Samples.RenderSubjectFull.verified.txt'></a>
```txt
[SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, CAVEAT=SH:EXCLUSIVE-FOR DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege]
```
<sup><a href='/src/Tests/Samples.RenderSubjectFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderSubjectFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Header


#### Minimum content

<!-- snippet: RenderHeaderMinimum -->
<a id='snippet-renderheaderminimum'></a>
```cs
var marking = new ProtectiveMarking
{
    SecurityClassification = SecurityClassification.TopSecret,
};
var result = marking.RenderHeader();
```
<sup><a href='/src/Tests/SamplesTests.cs#L71-L79' title='Snippet source file'>snippet source</a> | <a href='#snippet-renderheaderminimum' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderHeaderMinimum.verified.txt -->
<a id='snippet-Samples.RenderHeaderMinimum.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET
```
<sup><a href='/src/Tests/Samples.RenderHeaderMinimum.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderHeaderMinimum.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Full content

<!-- snippet: RenderHeaderFull -->
<a id='snippet-renderheaderfull'></a>
```cs
var marking = new ProtectiveMarking
{
    SecurityClassification = SecurityClassification.TopSecret,
    Expiry = new Expiry
    {
        DownTo = SecurityClassification.Official,
        GenDate = new DateTimeOffset(2020, 10, 1, 0, 0, 0, TimeSpan.Zero),
    },
    Comment = "the comments",
    AuthorEmail = "a@b.com",
    InformationManagementMarkers = new[]
    {
        InformationManagementMarker.LegalPrivilege
    },
    CodewordCaveats = new[]
    {
        "CodeWord"
    },
    ForeignGovernmentCaveats = new[]
    {
        "USA caveat"
    },
    CaveatTypes = new[]
    {
        CaveatType.Agao,
        CaveatType.Cabinet,
    },
    ExclusiveForCaveats = new[]
    {
        "person"
    },
    CountryCodeCaveats = new[]
    {
        CountryCode.Afghanistan,
        CountryCode.Algeria
    }
};
var result = marking.RenderHeader();
```
<sup><a href='/src/Tests/SamplesTests.cs#L87-L128' title='Snippet source file'>snippet source</a> | <a href='#snippet-renderheaderfull' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in:

<!-- snippet: Samples.RenderHeaderFull.verified.txt -->
<a id='snippet-Samples.RenderHeaderFull.verified.txt'></a>
```txt
VER=2018.4, NS=gov.au, SEC=TOP-SECRET, CAVEAT=C:CodeWord, CAVEAT=FG:USA caveat, CAVEAT=RI:AGAO, CAVEAT=SH:CABINET, CAVEAT=SH:EXCLUSIVE-FOR person, CAVEAT=SH:EXCLUSIVE-FOR AFG, CAVEAT=SH:EXCLUSIVE-FOR DZA, EXPIRES=2020-10-01, DOWNTO=OFFICIAL, ACCESS=Legal-Privilege, NOTE=the comments, ORIGIN=a@b.com
```
<sup><a href='/src/Tests/Samples.RenderHeaderFull.verified.txt#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-Samples.RenderHeaderFull.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

Icon designed by [Iconathon](https://thenounproject.com/Iconathon1) from [The Noun Project](https://thenounproject.com).
