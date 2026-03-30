# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project

A .NET library implementing the Australian Government Email Protective Marking Standard. Publishes two NuGet packages: `AustralianProtectiveMarkings` (main library) and `Verify.AustralianProtectiveMarkings` (Verify test extension).

## Build & Test Commands

All commands run from the `src/` directory:

```shell
dotnet build AustralianProtectiveMarkings.slnx
dotnet test AustralianProtectiveMarkings.slnx
dotnet test AustralianProtectiveMarkings.slnx --filter "FullyQualifiedName~Tests.ParserTests.MethodName"
```

Requires .NET 10 SDK (preview). See `src/global.json` for version details.

## Architecture

**Core types** (all record structs for serialization-friendliness):
- `ProtectiveMarking` — top-level type containing a `Classification`, optional `Caveats`, optional `Expiry`, and metadata fields
- `Classification` — enum: Unofficial, Official, OfficialSensitive, Protected, Secret, TopSecret
- `Caveats` — flags/lists for Codeword, ForeignGovernment, ExclusiveFor, CountryCodes, Agao, Austeo, etc.
- `Expiry` — classification expiry with DownTo classification and GenDate or Event

**Rendering** (`Renderer.cs`, `Renderer_Email.cs`, `Renderer_Doc.cs`):
- `RenderEmailSubjectSuffix()` — `[SEC=OFFICIAL, CAVEAT=...]` format
- `RenderEmailHeader()` — `X-Protective-Marking` header value
- `RenderDocumentHeaderAndFooter()` — document marking text

**Parsing** (`Parser.cs`, `Parser_Caveats.cs`, `Parser_KeyValue.cs`):
- `ParseEmailHeader()` — state machine parser (~600 lines) that handles key-value pairs with escape sequences (`\:`, `\\`, `\,`)

**Integration helpers:**
- `MailMessageExtensions.cs` — `ApplyProtectiveMarkings()` extension for `System.Net.Mail.MailMessage`
- `OfficeDocHelper.cs` — applies markings to .docx/.xlsx/.pptx via OpenXml custom properties
- `CommonMarkings.cs` — pre-calculated standard marking instances

**Text validation:** allowed character range is ASCII 32-43, 45-91, 93-126; max 128 characters per field.

## Testing

Uses **NUnit** with **Verify** (approval/snapshot testing). Tests are in `src/Tests/`. Verified outputs are `.verified.txt` files alongside test files — review and accept changes with the Verify workflow when output changes intentionally.

`ModuleInitializer.cs` in Tests registers Verify converters for `ProtectiveMarking` and `Caveats`.

## Build Configuration

- **Multi-targeting:** net10.0, net9.0, net8.0, net48
- **C# LangVersion:** preview
- **TreatWarningsAsErrors:** true
- **EnforceCodeStyleInBuild:** true (rules in `.editorconfig`)
- **Central package management:** all versions in `src/Directory.Packages.props`

## CI

- **AppVeyor** (`appveyor.yml`): builds and tests, publishes NuGet packages
- **GitHub Actions**: auto-generates docs from code snippets (`on-push-do-docs.yml`), milestone-based releases, dependabot auto-merge
