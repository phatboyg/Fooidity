namespace Fooidity.Contracts
{
    using System;


    /// <summary>
    /// Published when a code switch is evaluated, such that the state of the switch can be
    /// captured for use in later activations
    /// </summary>
    public interface ICodeSwitchEvaluated
    {
        /// <summary>
        /// The time at which the feature state was evaluated
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The feature identifier connected to the code switch
        /// </summary>
        Uri CodeFeatureId { get; }

        /// <summary>
        /// Whether the feature was enabled or disabled after evaluation
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// If context was used to evaluate the switch, the context id
        /// </summary>
        Uri ContextId { get; }

        /// <summary>
        /// The key used to select the context if a context is used
        /// </summary>
        string ContextKey { get; }

        /// <summary>
        /// The host on which the switch was evaluated
        /// </summary>
        IHost Host { get; }
    }
}