## CommonMarkings

`AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

Values:

| Property | Value |
|----------|-------|
| `Unofficial` | `new ProtectiveMarking(Classification.Unofficial)` |
| `UnofficialEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=UNOFFICIAL` |
| `UnofficialEmailSubjectSuffix` | string: `[SEC=UNOFFICIAL]` |
| `UnofficialClassificationAndCaveats` | string: `UNOFFICIAL` |
| `Official` | `new ProtectiveMarking(Classification.Official)` |
| `OfficialEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=OFFICIAL` |
| `OfficialEmailSubjectSuffix` | string: `[SEC=OFFICIAL]` |
| `OfficialClassificationAndCaveats` | string: `OFFICIAL` |
| `OfficialSensitive` | `new ProtectiveMarking(Classification.OfficialSensitive)` |
| `OfficialSensitiveEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=OFFICIAL:Sensitive` |
| `OfficialSensitiveEmailSubjectSuffix` | string: `[SEC=OFFICIAL:Sensitive]` |
| `OfficialSensitiveClassificationAndCaveats` | string: `OFFICIAL:Sensitive` |
| `Protected` | `new ProtectiveMarking(Classification.Protected)` |
| `ProtectedEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=PROTECTED` |
| `ProtectedEmailSubjectSuffix` | string: `[SEC=PROTECTED]` |
| `ProtectedClassificationAndCaveats` | string: `PROTECTED` |
| `Secret` | `new ProtectiveMarking(Classification.Secret)` |
| `SecretEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=SECRET` |
| `SecretEmailSubjectSuffix` | string: `[SEC=SECRET]` |
| `SecretClassificationAndCaveats` | string: `SECRET` |
| `TopSecret` | `new ProtectiveMarking(Classification.TopSecret)` |
| `TopSecretEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=TOP-SECRET` |
| `TopSecretEmailSubjectSuffix` | string: `[SEC=TOP-SECRET]` |
| `TopSecretClassificationAndCaveats` | string: `TOP-SECRET` |
| `ProtectedCabinet` | `new ProtectiveMarking(Classification.Protected){Caveats = new(){Cabinet = true}}` |
| `ProtectedCabinetEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=PROTECTED, CAVEAT=SH:CABINET` |
| `ProtectedCabinetEmailSubjectSuffix` | string: `[SEC=PROTECTED, CAVEAT=SH:CABINET]` |
| `ProtectedCabinetClassificationAndCaveats` | string: `PROTECTED//CABINET` |
