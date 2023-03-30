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

        public static DateOnly ToDateOnly(this string date)
        {
            return DateOnly.ParseExact(date, DateTimeFormatConstants.DATE_ONLY_FORMAT);
        }
    }
}
