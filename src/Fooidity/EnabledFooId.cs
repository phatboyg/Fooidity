namespace Fooidity
{
    public class EnabledFooId<T> :
        FooId<T>
        where T : FooId
    {
        bool FooId<T>.Enabled
        {
            get { return true; }
        }
    }
}