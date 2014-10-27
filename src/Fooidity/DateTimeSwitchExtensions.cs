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
        public static CodeSwitch<T> EnableAfter<T>(this ICodeSwitchFactory factory, DateTime dateTime)
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, dateTime, null, () => DateTime.UtcNow);
        }

        /// <summary>
        /// Enable the code feature until the specified date/time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static CodeSwitch<T> EnableUntil<T>(this ICodeSwitchFactory factory, DateTime dateTime)
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, null, dateTime, () => DateTime.UtcNow);
        }
    }
}