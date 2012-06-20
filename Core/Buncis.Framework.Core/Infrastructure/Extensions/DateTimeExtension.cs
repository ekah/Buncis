using System;

namespace Buncis.Framework.Infrastructure.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Toes the string default format.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToLongFormatString(this DateTime input)
        {
            return input.ToString("ddd, dd MMM yyyy HH:mm");
        }
    }
}
