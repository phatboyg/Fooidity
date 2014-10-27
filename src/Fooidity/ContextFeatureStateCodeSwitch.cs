namespace Fooidity
{
    using Configuration;


    /// <summary>
    /// A dynamic code switch that uses the contextual feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature">The feature</typeparam>
    /// <typeparam name="TContext">The context type for this code switch</typeparam>
    public class ContextFeatureStateCodeSwitch<TFeature, TContext> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;
        readonly TContext _context;
        readonly IContextFeatureStateCache<TContext> _contextCache;

        public ContextFeatureStateCodeSwitch(ICodeFeatureStateCache cache,
            IContextFeatureStateCache<TContext> contextCache, TContext context)
        {
            _cache = cache;
            _contextCache = contextCache;
            _context = context;
        }

        public bool Enabled
        {
            get
            {
                CodeFeatureState codeFeatureState;

                ContextFeatureState contextFeatureState;
                if (_contextCache.TryGetState(_context, out contextFeatureState))
                    if(contextFeatureState.TryGetFeature<TFeature>(out codeFeatureState))
                    return codeFeatureState.Enabled;

                return _cache.TryGetState<TFeature>(out codeFeatureState) && codeFeatureState.Enabled;
            }
        }
    }
}