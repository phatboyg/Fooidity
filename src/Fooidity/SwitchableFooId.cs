namespace Fooidity
{
    /// <summary>
    /// A FooId that can be changed by calling the appropriate method
    /// </summary>
    /// <typeparam name="TFoo"></typeparam>
    public class SwitchableFooId<TFoo> :
        FooId<TFoo>
        where TFoo : struct, FooId
    {
        bool _enabled;

        public SwitchableFooId(bool enabled)
        {
            _enabled = enabled;
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }
    }
}