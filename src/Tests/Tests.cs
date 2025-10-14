[TestFixture]
public class Tests
{
    [Test]
    public Task Serialization()
    {
        var marking = new ProtectiveMarking
        {
            Classification = Classification.Secret,
            Expiry = new Expiry
            {
                DownTo = Classification.Official,
                GenDate = new DateTimeOffset(new(2020, 10, 1))
            },
            LegalPrivilege = true,
            Caveats = new Caveats
            {
                Codeword = "LOBSTER",
                ForeignGovernment = "usa caveat",
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
        var serialized1 = JsonConvert.SerializeObject(marking);
        var deserialized = JsonConvert.DeserializeObject<ProtectiveMarking>(serialized1);
        var serialized2 = JsonConvert.SerializeObject(deserialized);
        AreEqual(serialized1, serialized2);
        return Verify(marking);
    }
#if NET9_0

    [Test]
    public async Task WriteCommonMarkings()
    {
        var md = Path.Combine(SolutionDirectoryFinder.Find(), "common-markings.include.md");
        File.Delete(md);
        await using var writer = File.CreateText(md);

        await writer.WriteLineAsync(
            """
            ## CommonMarkings

            `AustralianProtectiveMarkings.CommonMarkings` is a static helper class that gives access regularly use and pre-calculated values.

            Values:

            """);
        var properties = typeof(CommonMarkings)
            .GetProperties(BindingFlags.Public | BindingFlags.Static);

        foreach (var property in properties
                     .Where(_ => _.PropertyType == typeof(ProtectiveMarking)))
        {
            if (property.Name == "ProtectedCabinet")
            {
                await writer.WriteLineAsync(
                    """
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
                    """);
            }
            else
            {
                await writer.WriteLineAsync(
                    $"""
                      * `{property.Name}`<br>
                        Value: `new ProtectiveMarking(Classification.{property.Name})`
                     """);
            }

            await WriteMember(property, "EmailHeader");
            await WriteMember(property, "EmailSubjectSuffix");
            await WriteMember(property, "ClassificationAndCaveats");
        }

        Task WriteMember(PropertyInfo property, string suffix)
        {
            var stringProperty = properties.Single(_ => _.Name == property.Name + suffix);

            // ReSharper disable once AccessToDisposedClosure
            return writer.WriteLineAsync(
                $"""
                  * `{stringProperty.Name}`<br>
                    Value: `{stringProperty.GetValue(null)}`
                 """);
        }
    }

#endif
}