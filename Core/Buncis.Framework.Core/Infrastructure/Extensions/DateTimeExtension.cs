using System;

namespace Buncis.Framework.Core.Infrastructure.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Toes the string default format.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToBuncisLongFormatString(this DateTime input)
        {
            return input.ToString("ddd, dd MMM yyyy HH:mm");
        }

		/// <summary>
		/// Toes the short format string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string ToBuncisShortFormatString(this DateTime input)
		{
			return input.ToString("ddd, dd MMM yyyy");
		}

        /// <summary>
        /// Dates the part.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static DateTime DatePart(this DateTime input)
        {
            var dateTime = new DateTime(input.Year, input.Month, input.Day);
            return dateTime;
        }
    }
}
