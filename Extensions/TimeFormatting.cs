using System;

namespace Extensions
{
    public static class TimeFormatting
    {
        public static DateTime ToTurkeyTime(this DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();
            TimeZoneInfo turkeyZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey");
            DateTime turkeyTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, turkeyZone);
            return turkeyTime;
        }
    }
}
