namespace Fooidity
{
    public class DisabledFooId<T> :
        FooId<T>
        where T : FooId
    {
        bool FooId<T>.Enabled
        {
            get { return false; }
        }
    }
}