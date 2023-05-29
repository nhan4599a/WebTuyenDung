using System;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Helper
{
    public static class DateTimeHelper
    {
        public static string GetApplicationTimeRepresentation(this DateTimeOffset date)
        {
            return date.ToString(DateTimeFormatConstants.FULL_DATE_TIME_FORMAT);
        }

        public static DateOnly Today => DateOnly.FromDateTime(DateTime.Now);

        public static string GetApplicationTimeRepresentation(this DateOnly date)
        {
            return date.ToString(DateTimeFormatConstants.DATE_ONLY_FORMAT);
        }

        public static string GetApplicationTimeRepresentation(this DateOnly? date)
        {
            if (!date.HasValue)
            {
                return string.Empty;
            }

            return date.Value.GetApplicationTimeRepresentation();
        }

        public static DateOnly ToDateOnly(this string date)
        {
            return DateOnly.ParseExact(date, DateTimeFormatConstants.DATE_ONLY_FORMAT);
        }

        public static DateTimeOffset LastDayOfCurrentMonth()
        {
            var current = DateTimeOffset.Now;

            return new DateTimeOffset(current.Year, current.Month, GetDayCountOfMonth(current.Month, current.Year), 0, 0, 0, TimeSpan.Zero);
        }

        public static int GetDayCountOfMonth(int month, int year)
        {
            if (month == 2)
                return DateTime.IsLeapYear(year) ? 29 : 28;

            var moduleResultCompareValue = month <= 7 ? 1 : 0;

            return month % 2 == moduleResultCompareValue ? 31 : 30;
        }
    }
}
