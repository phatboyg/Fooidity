namespace Fooidity.CodeSwitches
{
    /// <summary>
    /// Retains the state of the toggle switch outside of the switch itself. This is to ensure that
    /// each switch evaluation is able to be tracked and reported in the event of an exception
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public interface IToggleSwitchState<TFeature>
        where TFeature : struct, ICodeFeature
    {
        bool Enabled { get; set; }
    }
}