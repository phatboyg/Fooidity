namespace Fooidity.CodeSwitches
{
    public class ToggleSwitchState<TFeature> :
        IToggleSwitchState<TFeature>
        where TFeature : struct, ICodeFeature
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