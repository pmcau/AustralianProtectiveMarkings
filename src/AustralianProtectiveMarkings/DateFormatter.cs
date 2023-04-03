using System.Globalization;

static class DateFormatter
{
    public static bool TryParse(string value, [NotNullWhen(true)] out DateTimeOffset? result)
    {
        if (!DateTimeOffset.TryParse(value,CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var parsed))
        {
            result = null;
            return false;
        }

        result = parsed;
        return true;
    }

    public static string Render(this DateTimeOffset value)
    {
        var builder = new StringBuilder(10);
        var timeOfDay = value.TimeOfDay;
        if (timeOfDay == TimeSpan.Zero)
        {
            builder.Append(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
        else if (timeOfDay is {Seconds: 0, Ticks: 0})
        {
            builder.Append(value.ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture));
        }
        else if (timeOfDay.Ticks == 0)
        {
            builder.Append(value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture));
        }
        else
        {
            builder.Append(value.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFF", CultureInfo.InvariantCulture));
        }

        var offset = value.Offset;

        if (offset > TimeSpan.Zero)
        {
            builder.Append($"+{offset.Hours:00}:{offset.Minutes:00}");
        }
        else if (offset < TimeSpan.Zero)
        {
            builder.Append($"-{offset.Hours:00}:{offset.Minutes:00}");
        }

        return builder.ToString();
    }
}