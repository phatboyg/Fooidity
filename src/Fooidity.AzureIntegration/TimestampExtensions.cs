namespace Fooidity.AzureIntegration
{
    using System;
    using System.Globalization;


    public static class TimestampExtensions
    {
        static readonly long _maxTicks = DateTime.MaxValue.Ticks;

        /// <summary>
        /// Return the DateTime as a 21-character string that is reverse-chronological
        /// to allow proper sorting as a RowKey in Azure Table Storage
        /// </summary>
        /// <param name="value">The DateTime value (must be UTC)</param>
        /// <returns>A 21-character string representing the value</returns>
        public static string ToDescendingTimestamp(this DateTime value)
        {
            if (value.Kind != DateTimeKind.Utc)
                throw new ArgumentException("The value must be a UTC timestamp", "value");

            long ticks = _maxTicks - value.Ticks;

            return ticks.ToString("D21", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Return the DateTimeOffset as a 21-character string that is reverse-chronological
        /// to allow proper sorting as a RowKey in Azure Table Storage
        /// </summary>
        /// <param name="value">The DateTimeOffset value (will be converted to UTC)</param>
        /// <returns>A 21-character string representing the value</returns>
        public static string ToDescendingTimestamp(this DateTimeOffset value)
        {
            return ToDescendingTimestamp(value.UtcDateTime);
        }
    }
}