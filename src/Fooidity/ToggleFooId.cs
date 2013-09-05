namespace Fooidity
{
    /// <summary>
    /// Control a toggle fooId, allowing it to be enabled or disabled
    /// </summary>
    public interface ToggleFooId
    {
        /// <summary>
        /// Enable the fooId
        /// </summary>
        void Enable();

        /// <summary>
        /// Disable the fooId
        /// </summary>
        void Disable();
    }


    /// <summary>
    /// A FooId that can be changed by calling the appropriate method
    /// </summary>
    /// <typeparam name="TFoo"></typeparam>
    public class ToggleFooId<TFoo> :
        FooId<TFoo>,
        ToggleFooId
        where TFoo : struct, FooId
    {
        bool _enabled;

        public ToggleFooId(bool enabled)
        {
            _enabled = enabled;
        }

        public bool Enabled
        {
            get { return _enabled; }
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