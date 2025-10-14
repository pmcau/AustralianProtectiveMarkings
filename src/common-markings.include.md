## CommonMarkings

`AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

Values:

 * `Unofficial`<br>
   Value: `new ProtectiveMarking(Classification.Unofficial)`
 * `UnofficialEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=UNOFFICIAL`
 * `UnofficialEmailSubjectSuffix`<br>
   Value: `[SEC=UNOFFICIAL]`
 * `UnofficialClassificationAndCaveats`<br>
   Value: `UNOFFICIAL`
 * `Official`<br>
   Value: `new ProtectiveMarking(Classification.Official)`
 * `OfficialEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=OFFICIAL`
 * `OfficialEmailSubjectSuffix`<br>
   Value: `[SEC=OFFICIAL]`
 * `OfficialClassificationAndCaveats`<br>
   Value: `OFFICIAL`
 * `OfficialSensitive`<br>
   Value: `new ProtectiveMarking(Classification.OfficialSensitive)`
 * `OfficialSensitiveEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=OFFICIAL:Sensitive`
 * `OfficialSensitiveEmailSubjectSuffix`<br>
   Value: `[SEC=OFFICIAL:Sensitive]`
 * `OfficialSensitiveClassificationAndCaveats`<br>
   Value: `OFFICIAL:Sensitive`
 * `Protected`<br>
   Value: `new ProtectiveMarking(Classification.Protected)`
 * `ProtectedEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=PROTECTED`
 * `ProtectedEmailSubjectSuffix`<br>
   Value: `[SEC=PROTECTED]`
 * `ProtectedClassificationAndCaveats`<br>
   Value: `PROTECTED`
 * `Secret`<br>
   Value: `new ProtectiveMarking(Classification.Secret)`
 * `SecretEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=SECRET`
 * `SecretEmailSubjectSuffix`<br>
   Value: `[SEC=SECRET]`
 * `SecretClassificationAndCaveats`<br>
   Value: `SECRET`
 * `TopSecret`<br>
   Value: `new ProtectiveMarking(Classification.TopSecret)`
 * `TopSecretEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=TOP-SECRET`
 * `TopSecretEmailSubjectSuffix`<br>
   Value: `[SEC=TOP-SECRET]`
 * `TopSecretClassificationAndCaveats`<br>
   Value: `TOP-SECRET`
 * `ProtectedCabinet`<br>
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
 * `ProtectedCabinetEmailHeader`<br>
   Value: `VER=2024.1, NS=gov.au, SEC=PROTECTED, CAVEAT=SH:CABINET`
 * `ProtectedCabinetEmailSubjectSuffix`<br>
   Value: `[SEC=PROTECTED, CAVEAT=SH:CABINET]`
 * `ProtectedCabinetClassificationAndCaveats`<br>
   Value: `PROTECTED//CABINET`
