namespace Fooidity
{
    /// <summary>
    /// Enables a feature for subset of the users based on some context identifier
    /// </summary>
    /// <typeparam name="TFoo"></typeparam>
    public class SlowRollout<TFoo> :
        FooId<TFoo>
        where TFoo : struct, FooId
    {
        public bool Enabled
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}