namespace Fooidity
{
    using System;
    using CodeSwitches;


    /// <summary>
    /// Extensions for creating DateTime switches that activate at a given date/time
    /// </summary>
    public static class DateTimeSwitchExtensions
    {
        /// <summary>
        /// Enable the code feature after the specified date/time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static IToggleCodeSwitch<T> EnableAfter<T>(this ICodeSwitchFactory factory, DateTime dateTime,
            CurrentTimeProvider currentTimeProvider = null)
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, dateTime, null, currentTimeProvider ?? DefaultTimeProvider);
        }

        /// <summary>
        /// Enable the code feature between the specified dates
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="currentTimeProvider"></param>
        /// <returns></returns>
        public static IToggleCodeSwitch<T> EnableBetween<T>(this ICodeSwitchFactory factory, DateTime startDateTime,
            DateTime endDateTime, CurrentTimeProvider currentTimeProvider = null)
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, startDateTime, endDateTime,
                currentTimeProvider ?? DefaultTimeProvider);
        }

        /// <summary>
        /// Enable the code feature until the specified date/time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static IToggleCodeSwitch<T> EnableUntil<T>(this ICodeSwitchFactory factory, DateTime dateTime,
            CurrentTimeProvider currentTimeProvider = null)
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, null, dateTime, currentTimeProvider ?? DefaultTimeProvider);
        }

        static DateTime DefaultTimeProvider()
        {
            return DateTime.UtcNow;
        }
    }
}