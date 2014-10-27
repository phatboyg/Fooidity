namespace Fooidity.CodeSwitches
{
    public interface ContextCodeSwitch<TFeature, TContext> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
    }
}