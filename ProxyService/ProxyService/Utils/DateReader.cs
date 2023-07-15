using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyService.Utils
{
    internal class DateReader
    {
        public static DateTime GetDateTime(string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime frenchTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

            return frenchTime;
        }
    }
}
