## CommonMarkings

`AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

Values:

| Property | Type | Value |
|----------|------|-------|
| `Unofficial` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.Unofficial)` |
| `UnofficialEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=UNOFFICIAL` |
| `UnofficialEmailSubjectSuffix` | `string` | `[SEC=UNOFFICIAL]` |
| `UnofficialClassificationAndCaveats` | `string` | `UNOFFICIAL` |
| `Official` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.Official)` |
| `OfficialEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=OFFICIAL` |
| `OfficialEmailSubjectSuffix` | `string` | `[SEC=OFFICIAL]` |
| `OfficialClassificationAndCaveats` | `string` | `OFFICIAL` |
| `OfficialSensitive` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.OfficialSensitive)` |
| `OfficialSensitiveEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=OFFICIAL:Sensitive` |
| `OfficialSensitiveEmailSubjectSuffix` | `string` | `[SEC=OFFICIAL:Sensitive]` |
| `OfficialSensitiveClassificationAndCaveats` | `string` | `OFFICIAL:Sensitive` |
| `Protected` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.Protected)` |
| `ProtectedEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=PROTECTED` |
| `ProtectedEmailSubjectSuffix` | `string` | `[SEC=PROTECTED]` |
| `ProtectedClassificationAndCaveats` | `string` | `PROTECTED` |
| `Secret` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.Secret)` |
| `SecretEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=SECRET` |
| `SecretEmailSubjectSuffix` | `string` | `[SEC=SECRET]` |
| `SecretClassificationAndCaveats` | `string` | `SECRET` |
| `TopSecret` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.TopSecret)` |
| `TopSecretEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=TOP-SECRET` |
| `TopSecretEmailSubjectSuffix` | `string` | `[SEC=TOP-SECRET]` |
| `TopSecretClassificationAndCaveats` | `string` | `TOP-SECRET` |
| `ProtectedCabinet` | `ProtectiveMarking` | `new ProtectiveMarking(Classification.Protected){Caveats = new(){Cabinet = true}}` |
| `ProtectedCabinetEmailHeader` | `string` | `VER=2024.1, NS=gov.au, SEC=PROTECTED, CAVEAT=SH:CABINET` |
| `ProtectedCabinetEmailSubjectSuffix` | `string` | `[SEC=PROTECTED, CAVEAT=SH:CABINET]` |
| `ProtectedCabinetClassificationAndCaveats` | `string` | `PROTECTED//CABINET` |
