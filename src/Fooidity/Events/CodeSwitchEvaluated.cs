namespace Fooidity.Events
{
    using System;


    /// <summary>
    /// Published when a code switch is evaluated, such that the state of the switch can be
    /// captured for use in later activations
    /// </summary>
    public interface CodeSwitchEvaluated
    {
        /// <summary>
        /// The time at which the feature state was evaluated
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The feature identifier connected to the code switch
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Whether the feature was enabled or disabled after evaluation
        /// </summary>
        bool Enabled { get; }
    }
}