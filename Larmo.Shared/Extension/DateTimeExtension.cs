namespace Larmo.Shared.Extension;

public static class DateTimeExtension
{
    public static bool IsUniversalTimeZone(this DateTime dateTime)
    {
        return dateTime.Kind == DateTimeKind.Utc;
    }

    public static DateTime ToDateTime(this DateOnly dateOnly)
    {
        return dateOnly.ToDateTime(new TimeOnly(0, 0, 0, 0), DateTimeKind.Utc);
    }

    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return DateOnly.FromDateTime(dateTime);
    }

    public static TimeOnly? ToTimeOnly(this TimeSpan? timeSpan)
    {
        return timeSpan.HasValue ? TimeOnly.FromTimeSpan(timeSpan.Value) : null;
    }
}
