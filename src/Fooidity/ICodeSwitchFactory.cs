namespace Fooidity
{
    using System;
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
        ICodeSwitch<T> Enabled<T>()
            where T : struct, ICodeFeature;

        /// <summary>
        /// Returns a CodeSwitch that is always disabled
        /// </summary>
        /// <typeparam name="T">The CodeSwitch type</typeparam>
        /// <returns></returns>
        ICodeSwitch<T> Disabled<T>()
            where T : struct, ICodeFeature;

        /// <summary>
        /// Creates a CodeSwitch that can be toggled from enabled to disabled (and back, of course)
        /// </summary>
        /// <typeparam name="T">The CodeSwitch atom</typeparam>
        /// <param name="initial">The initial state of the CodeSwitch</param>
        /// <returns></returns>
        IToggleCodeSwitch<T> Toggle<T>(bool initial = false)
            where T : struct, ICodeFeature;

        /// <summary>
        /// Returns the dependent code switch build by the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factoryMethod"></param>
        /// <returns></returns>
        ICodeSwitch<T> Dependent<T>(Func<IDependentCodeSwitchFactory<T>, ICodeSwitch<T>> factoryMethod)
            where T : struct, ICodeFeature;
    }
}