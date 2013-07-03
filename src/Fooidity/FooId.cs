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
    /// <typeparam name="TFoo"></typeparam>
    public interface FooId<TFoo>
        where TFoo : FooId
    {
        bool Enabled { get; }
    }
}