namespace Fooidity.CodeSwitches
{
    public interface IToggleSwitchState<TFeature>
        where TFeature : struct, CodeFeature
    {
        bool Enabled { get; set; }
    }
}