namespace Fooidity
{
    /// <summary>
    /// A CodeSwitch that can be changed by calling the appropriate method
    /// </summary>
    /// <typeparam name="TFeature">The code feature</typeparam>
    public class ToggleCodeSwitch<TFeature> :
        CodeSwitch<TFeature>,
        IToggleCodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        bool _enabled;

        public ToggleCodeSwitch(bool enabled)
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