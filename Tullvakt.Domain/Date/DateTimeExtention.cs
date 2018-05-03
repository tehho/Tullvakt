using System;
using PublicHoliday;

namespace Tullvakt.Domain
{
    public static class DateTimeExtention
    {
        public static bool IsRedDay(this DateTime dateTime)
        {
            if (!IsWeekday(dateTime))
            {
                return true;
            }

            return new SwedenPublicHoliday().IsPublicHoliday(dateTime);
        }

        private static bool IsWeekday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Monday ||
                   dateTime.DayOfWeek == DayOfWeek.Tuesday ||
                   dateTime.DayOfWeek == DayOfWeek.Wednesday ||
                   dateTime.DayOfWeek == DayOfWeek.Thursday ||
                   dateTime.DayOfWeek == DayOfWeek.Friday;
        }
    }
}