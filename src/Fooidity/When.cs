namespace Fooidity
{
    /// <summary>
    /// Specify a dependent FooId that must be enabled in order for the current FooId to be enabled
    /// </summary>
    public interface When<TFoo> :
        FooId
        where TFoo : FooId
    {
    }
}