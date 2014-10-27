namespace Fooidity
{
    using System;
    using Dependents;


    /// <summary>
    /// A code switch determines and returns the state of the switch based on any environmental
    /// conditions that are present at the time of the switch being evaluated.
    /// </summary>
    /// <typeparam name="TFeature">The code feature that identifies the switch state</typeparam>
    public interface CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        /// <summary>
        /// Returns true if the FooId is enabled
        /// </summary>
        bool Enabled { get; }
    }


    /// <summary>
    /// A set of cached factory methods for various switch types
    /// </summary>
    public static class CodeSwitch
    {
        /// <summary>
        /// Returns a CodeSwitch that is always enabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        public static CodeSwitch<T> Enabled<T>()
            where T : struct, CodeFeature
        {
            return Cached<T>.EnabledCodeSwitch;
        }

        /// <summary>
        /// Returns a CodeSwitch that is always disabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        public static CodeSwitch<T> Disabled<T>()
            where T : struct, CodeFeature
        {
            return Cached<T>.DisabledCodeSwitch;
        }

        /// <summary>
        /// Creates a CodeSwitch that can be toggled from enabled to disabled (and back, of course)
        /// </summary>
        /// <typeparam name="T">The CodeSwitch atom</typeparam>
        /// <param name="initial">The initial state of the CodeSwitch</param>
        /// <returns></returns>
        public static ToggleCodeSwitch<T> Toggle<T>(bool initial = false)
            where T : struct, CodeFeature
        {
            return new ToggleCodeSwitch<T>(initial);
        }

        /// <summary>
        /// Enable the code feature after the specified date/time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static CodeSwitch<T> EnableAfter<T>(DateTime dateTime) 
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, dateTime, null, () => DateTime.UtcNow);
        }

        /// <summary>
        /// Enable the code feature until the specified date/time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static CodeSwitch<T> EnableUntil<T>(DateTime dateTime) 
            where T : struct, CodeFeature
        {
            return new DateRangeCodeSwitch<T>(true, null, dateTime, () => DateTime.UtcNow);
        }

        /// <summary>
        /// Returns the dependent code switch build by the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factoryMethod"></param>
        /// <returns></returns>
        public static CodeSwitch<T> Dependent<T>(Func<IDependentCodeSwitchFactory<T>, CodeSwitch<T>> factoryMethod)
            where T : struct, CodeFeature
        {
            return factoryMethod(Cached<T>.Factory);
        }


        static class Cached<TFeature>
            where TFeature : struct, CodeFeature
        {
            internal static readonly CodeSwitch<TFeature> DisabledCodeSwitch = new DisabledCodeSwitch<TFeature>();
            internal static readonly CodeSwitch<TFeature> EnabledCodeSwitch = new EnabledCodeSwitch<TFeature>();
            internal static readonly IDependentCodeSwitchFactory<TFeature> Factory = new DependentCodeSwitchFactory<TFeature>();
        }
    }
}