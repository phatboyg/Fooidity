namespace Fooidity
{
    public interface ContextCodeSwitch<TFeature, TContext> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
    }
}