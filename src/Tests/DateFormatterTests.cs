[TestFixture]
public class DateFormatterTests
{
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

        await Verify(values);
    }

    static bool[] bools =
    {
        true,
        false
    };
}