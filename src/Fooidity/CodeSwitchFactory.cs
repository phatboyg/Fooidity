namespace Fooidity
{
    using System;
    using CodeSwitches;
    using Dependents;


    class CodeSwitchFactory :
        ICodeSwitchFactory
    {
        /// <summary>
        /// Returns a CodeSwitch that is always enabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        public CodeSwitch<T> Enabled<T>()
            where T : struct, CodeFeature
        {
            return Cached<T>.EnabledCodeSwitch;
        }

        /// <summary>
        /// Returns a CodeSwitch that is always disabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        public CodeSwitch<T> Disabled<T>()
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
        public IToggleCodeSwitch<T> Toggle<T>(bool initial = false)
            where T : struct, CodeFeature
        {
            var state = new ToggleSwitchState<T>(initial);
            return new ToggleCodeSwitch<T>(state);
        }

        /// <summary>
        /// Returns the dependent code switch build by the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factoryMethod"></param>
        /// <returns></returns>
        public CodeSwitch<T> Dependent<T>(Func<IDependentCodeSwitchFactory<T>, CodeSwitch<T>> factoryMethod)
            where T : struct, CodeFeature
        {
            return factoryMethod(Cached<T>.Factory);
        }


        static class Cached<TFeature>
            where TFeature : struct, CodeFeature
        {
            internal static readonly CodeSwitch<TFeature> DisabledCodeSwitch = new DisabledCodeSwitch<TFeature>();
            internal static readonly CodeSwitch<TFeature> EnabledCodeSwitch = new EnabledCodeSwitch<TFeature>();

            internal static readonly IDependentCodeSwitchFactory<TFeature> Factory =
                new DependentCodeSwitchFactory<TFeature>();
        }
    }
}