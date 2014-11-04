namespace Fooidity
{
    using System;
    using Contracts;


    /// <summary>
    /// A code switch determines and returns the state of the switch based on any environmental
    /// conditions that are present at the time of the switch being evaluated.
    /// </summary>
    /// <typeparam name="TFeature">The code feature that identifies the switch state</typeparam>
    public interface ICodeSwitch<TFeature> :
        IObservable<ICodeSwitchEvaluated>
        where TFeature : struct, ICodeFeature
    {
        /// <summary>
        /// Returns true if the FooId is enabled
        /// </summary>
        bool Enabled { get; }
    }
}