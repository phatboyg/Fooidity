namespace Fooidity
{
    /// <summary>
    /// Defines a selector that can be used for selectively executing code paths and/or versions
    /// </summary>
    public interface FooId
    {
    }


    /// <summary>
    /// The selector instance used to determine if the code is enabled or disabled
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface FooId<T>
        where T : struct, FooId
    {
        /// <summary>
        /// Returns true if the FooId is enabled
        /// </summary>
        bool Enabled { get; }
    }
}