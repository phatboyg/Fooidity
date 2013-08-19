namespace Fooidity
{
    /// <summary>
    /// Snapshots capture the state of a FooId (and dependent FooIds) at a point in time
    /// for consistency across a distributed network of services.
    /// </summary>
    /// <typeparam name="TFoo"></typeparam>
    public interface Snapshot<TFoo> :
        FooId<TFoo>
        where TFoo : struct, FooId
    {
        EvaluationType EvaluationType { get; }
    }

    public enum EvaluationType
    {
        /// <summary>
        /// Evaluate the graph of FooIds to determine the current state
        /// </summary>
        Default = 0,

        /// <summary>
        /// Use the Enabled values to determine the current state
        /// </summary>
        Snapshot = 1,
    }
}