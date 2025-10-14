## CommonMarkings

`AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

Values:

| Property | Value |
|----------|-------|
| `Unofficial` | `new ProtectiveMarking(Unofficial)` |
| `UnofficialEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=UNOFFICIAL` |
| `UnofficialEmailSubjectSuffix` | string: `[SEC=UNOFFICIAL]` |
| `UnofficialClassificationAndCaveats` | string: `UNOFFICIAL` |
| `Official` | `new ProtectiveMarking(Official)` |
| `OfficialEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=OFFICIAL` |
| `OfficialEmailSubjectSuffix` | string: `[SEC=OFFICIAL]` |
| `OfficialClassificationAndCaveats` | string: `OFFICIAL` |
| `OfficialSensitive` | `new ProtectiveMarking(OfficialSensitive)` |
| `OfficialSensitiveEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=OFFICIAL:Sensitive` |
| `OfficialSensitiveEmailSubjectSuffix` | string: `[SEC=OFFICIAL:Sensitive]` |
| `OfficialSensitiveClassificationAndCaveats` | string: `OFFICIAL:Sensitive` |
| `Protected` | `new ProtectiveMarking(Protected)` |
| `ProtectedEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=PROTECTED` |
| `ProtectedEmailSubjectSuffix` | string: `[SEC=PROTECTED]` |
| `ProtectedClassificationAndCaveats` | string: `PROTECTED` |
| `Secret` | `new ProtectiveMarking(Secret)` |
| `SecretEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=SECRET` |
| `SecretEmailSubjectSuffix` | string: `[SEC=SECRET]` |
| `SecretClassificationAndCaveats` | string: `SECRET` |
| `TopSecret` | `new ProtectiveMarking(TopSecret)` |
| `TopSecretEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=TOP-SECRET` |
| `TopSecretEmailSubjectSuffix` | string: `[SEC=TOP-SECRET]` |
| `TopSecretClassificationAndCaveats` | string: `TOP-SECRET` |
| `ProtectedCabinet` | `new ProtectiveMarking(Protected){Caveats = {Cabinet = true}}` |
| `ProtectedCabinetEmailHeader` | string: `VER=2024.1, NS=gov.au, SEC=PROTECTED, CAVEAT=SH:CABINET` |
| `ProtectedCabinetEmailSubjectSuffix` | string: `[SEC=PROTECTED, CAVEAT=SH:CABINET]` |
| `ProtectedCabinetClassificationAndCaveats` | string: `PROTECTED//CABINET` |
