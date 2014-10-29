namespace Fooidity
{
    using System;
    using Events;


    /// <summary>
    /// A code switch determines and returns the state of the switch based on any environmental
    /// conditions that are present at the time of the switch being evaluated.
    /// </summary>
    /// <typeparam name="TFeature">The code feature that identifies the switch state</typeparam>
    public interface CodeSwitch<TFeature> :
        IObservable<CodeSwitchEvaluated>
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
        /// Factory instance used to create code switches, allowing extension methods
        /// to add new factory methods for a single point of creation
        /// </summary>
        public static ICodeSwitchFactory Factory
        {
            get { return Cached.CodeSwitchFactory; }
        }


        static class Cached
        {
            internal static readonly ICodeSwitchFactory CodeSwitchFactory = new CodeSwitchFactory();
        }
    }
}