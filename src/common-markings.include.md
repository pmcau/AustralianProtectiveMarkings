## CommonMarkings

`AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

Values:

 * `Unofficial`
   Value: `new ProtectiveMarking(Classification.Unofficial)`
 * `UnofficialEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=UNOFFICIAL`
 * `UnofficialEmailSubjectSuffix`
   Value: `[SEC=UNOFFICIAL]`
 * `UnofficialClassificationAndCaveats`
   Value: `UNOFFICIAL`
 * `Official`
   Value: `new ProtectiveMarking(Classification.Official)`
 * `OfficialEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=OFFICIAL`
 * `OfficialEmailSubjectSuffix`
   Value: `[SEC=OFFICIAL]`
 * `OfficialClassificationAndCaveats`
   Value: `OFFICIAL`
 * `OfficialSensitive`
   Value: `new ProtectiveMarking(Classification.OfficialSensitive)`
 * `OfficialSensitiveEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=OFFICIAL:Sensitive`
 * `OfficialSensitiveEmailSubjectSuffix`
   Value: `[SEC=OFFICIAL:Sensitive]`
 * `OfficialSensitiveClassificationAndCaveats`
   Value: `OFFICIAL:Sensitive`
 * `Protected`
   Value: `new ProtectiveMarking(Classification.Protected)`
 * `ProtectedEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=PROTECTED`
 * `ProtectedEmailSubjectSuffix`
   Value: `[SEC=PROTECTED]`
 * `ProtectedClassificationAndCaveats`
   Value: `PROTECTED`
 * `Secret`
   Value: `new ProtectiveMarking(Classification.Secret)`
 * `SecretEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=SECRET`
 * `SecretEmailSubjectSuffix`
   Value: `[SEC=SECRET]`
 * `SecretClassificationAndCaveats`
   Value: `SECRET`
 * `TopSecret`
   Value: `new ProtectiveMarking(Classification.TopSecret)`
 * `TopSecretEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=TOP-SECRET`
 * `TopSecretEmailSubjectSuffix`
   Value: `[SEC=TOP-SECRET]`
 * `TopSecretClassificationAndCaveats`
   Value: `TOP-SECRET`
 * `ProtectedCabinet`
   Value:
   ```
   new ProtectiveMarking(Classification.Protected)
   {
     Caveats = new()
     {
         Cabinet = true
     }
   }
   ```
 * `ProtectedCabinetEmailHeader`
   Value: `VER=2024.1, NS=gov.au, SEC=PROTECTED, CAVEAT=SH:CABINET`
 * `ProtectedCabinetEmailSubjectSuffix`
   Value: `[SEC=PROTECTED, CAVEAT=SH:CABINET]`
 * `ProtectedCabinetClassificationAndCaveats`
   Value: `PROTECTED//CABINET`
