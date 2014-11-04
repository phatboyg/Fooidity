namespace Fooidity
{
    public interface IContextCodeSwitch<TFeature, TContext> :
        ICodeSwitch<TFeature>
        where TFeature : struct, ICodeFeature
    {
    }
}