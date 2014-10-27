namespace Fooidity.CodeSwitches
{
    public class ToggleSwitchState<TFeature> :
        IToggleSwitchState<TFeature>
        where TFeature : struct, CodeFeature
    {
        public ToggleSwitchState()
        {
        }

        public ToggleSwitchState(bool initial)
        {
            Enabled = initial;
        }

        public bool Enabled { get; set; }
    }
}