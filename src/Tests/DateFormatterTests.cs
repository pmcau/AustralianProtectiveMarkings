[TestFixture]
public class DateFormatterTests
{
    [Test]
    public Task Parse()
    {
        var list = new List<string>
        {
            "2019-07-01",
            "2019-07-01+10",
            "2019-07-01+10:08",
            "2019-07-01Z",
            "2019-07-01T12:10:01",
            "2019-07-01T12:10:01+10",
            "2019-07-01T12:10:01+10:08",
            "2019-07-01T12:10:01Z",
            "2019-07-01T12:10:01.123",
            "2019-07-01T12:10:01.123+10",
            "2019-07-01T12:10:01.123+10:08",
            "2019-07-01T12:10:01.123Z"
        };

        var dictionary = new Dictionary<string, DateTimeOffset?>();
        foreach (var item in list)
        {
            DateFormatter.TryParse(item, out var result);
            dictionary.Add(item, result);
        }

        return Verify(dictionary)
            .DontScrubDateTimes();
    }

    [Test]
    public async Task DateTimeOffsetCombinations()
    {
        var values = new Dictionary<string, string>();

        foreach (var offset in bools)
        foreach (var hour in bools)
        foreach (var minute in bools)
        foreach (var second in bools)
        foreach (var tick in bools)
        {
            var name = new StringBuilder();
            var timeSpan = TimeSpan.Zero;
            if (offset)
            {
                name.Append("_offset");
                timeSpan = new(7, 8, 0);
            }

            var value = new DateTimeOffset(2020, 1, 1, 0, 0, 0, timeSpan);
            if (hour)
            {
                name.Append("_hour");
                value = value.AddHours(2);
            }

            if (minute)
            {
                name.Append("_minute");
                value = value.AddMinutes(3);
            }

            if (second)
            {
                name.Append("_second");
                value = value.AddMinutes(4);
            }

            if (tick)
            {
                name.Append("_tick");
                value = value.AddTicks(6);
            }

            values.Add(name.ToString(), value.Render());
        }

        await Verify(values)
            .DontScrubDateTimes();
    }

    static bool[] bools =
    [
        true,
        false
    ];
}