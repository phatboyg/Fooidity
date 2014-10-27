namespace Fooidity
{
    using Configuration;


    /// <summary>
    /// A cache of contextual feature states, which can be configured per-context
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IContextFeatureStateCache<in TContext>
    {
        bool TryGetContextFeatureState(TContext context, out ContextFeatureState featureState);
    }
}