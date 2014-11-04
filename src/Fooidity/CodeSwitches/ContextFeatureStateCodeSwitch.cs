namespace Fooidity.CodeSwitches
{
    using System;
    using Caching;
    using Contracts;
    using Metadata;


    /// <summary>
    /// A dynamic code switch that uses the contextual feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature">The feature</typeparam>
    /// <typeparam name="TContext">The context type for this code switch</typeparam>
    public class ContextFeatureStateCodeSwitch<TFeature, TContext> :
        IContextCodeSwitch<TFeature, TContext>
        where TFeature : struct, ICodeFeature
    {
        readonly ICodeFeatureStateCache _cache;
        readonly TContext _context;
        readonly IContextFeatureStateCache<TContext> _contextCache;
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;

        public ContextFeatureStateCodeSwitch(ICodeFeatureStateCache cache,
            IContextFeatureStateCache<TContext> contextCache, TContext context)
        {
            _cache = cache;
            _contextCache = contextCache;
            _context = context;

            _evaluated = new CodeSwitchEvaluatedObservable<TFeature>();
            _enabled = new Lazy<bool>(Evaluate);
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            ICachedCodeFeatureState codeFeatureState;
            ICachedContextFeatureState contextFeatureState;
            if (_contextCache.TryGetContextFeatureState(_context, out contextFeatureState))
            {
                if (contextFeatureState.TryGetCodeFeatureState(CodeFeatureMetadata<TFeature>.Id, out codeFeatureState))
                {
                    _evaluated.Evaluated(ContextMetadata<TContext>.Id, contextFeatureState.Key, codeFeatureState.Enabled);
                    return codeFeatureState.Enabled;
                }
            }

            bool enabled = _cache.TryGetState<TFeature>(out codeFeatureState) && codeFeatureState.Enabled;

            _evaluated.Evaluated(enabled);

            return enabled;
        }
    }
}