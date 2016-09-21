using System;

namespace Crosscutting.Common.Extensions
{
    public class DateTimeExtension
    {
        public static int CalculateAge(DateTime birthDate, DateTime now)
        {
            var age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
        public static long ToTimestamp(DateTime value)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var elapsedTime = value - epoch;
            return (long)elapsedTime.TotalMilliseconds;
        }
    }
}
