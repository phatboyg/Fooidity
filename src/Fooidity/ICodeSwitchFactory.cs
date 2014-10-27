namespace Fooidity
{
    using System;
    using CodeSwitches;
    using Dependents;

    /// <summary>
    /// Methods to create code switches based on the internal types available. Can
    /// be extended using extension methods for new switch types.
    /// </summary>
    public interface ICodeSwitchFactory
    {
        /// <summary>
        /// Returns a CodeSwitch that is always enabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        CodeSwitch<T> Enabled<T>()
            where T : struct, CodeFeature;

        /// <summary>
        /// Returns a CodeSwitch that is always disabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        CodeSwitch<T> Disabled<T>()
            where T : struct, CodeFeature;

        /// <summary>
        /// Creates a CodeSwitch that can be toggled from enabled to disabled (and back, of course)
        /// </summary>
        /// <typeparam name="T">The CodeSwitch atom</typeparam>
        /// <param name="initial">The initial state of the CodeSwitch</param>
        /// <returns></returns>
        ToggleCodeSwitch<T> Toggle<T>(bool initial = false)
            where T : struct, CodeFeature;

        /// <summary>
        /// Returns the dependent code switch build by the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factoryMethod"></param>
        /// <returns></returns>
        CodeSwitch<T> Dependent<T>(Func<IDependentCodeSwitchFactory<T>, CodeSwitch<T>> factoryMethod)
            where T : struct, CodeFeature;
    }
}