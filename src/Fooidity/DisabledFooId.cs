namespace Fooidity
{
    public class DisabledFooId<T> :
        FooId<T>
        where T : struct, FooId
    {
        bool FooId<T>.Enabled
        {
            get { return false; }
        }
    }
}