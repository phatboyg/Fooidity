namespace Fooidity
{
    using System;
    using Caching;
    using Caching.Internals;
    using Configuration;
    using Events;
    using Metadata;


    /// <summary>
    /// A dynamic code switch that uses the contextual feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature">The feature</typeparam>
    /// <typeparam name="TContext">The context type for this code switch</typeparam>
    public class ContextFeatureStateCodeSwitch<TFeature, TContext> :
        ContextCodeSwitch<TFeature, TContext>,
        IObservable<CodeSwitchEvaluated>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;
        readonly TContext _context;
        readonly IContextFeatureStateCache<TContext> _contextCache;
        readonly Lazy<bool> _enabled;
        readonly Connectable<IObserver<CodeSwitchEvaluated>> _evaluated;

        public ContextFeatureStateCodeSwitch(ICodeFeatureStateCache cache,
            IContextFeatureStateCache<TContext> contextCache, TContext context)
        {
            _cache = cache;
            _contextCache = contextCache;
            _context = context;

            _evaluated = new Connectable<IObserver<CodeSwitchEvaluated>>();
            _enabled = new Lazy<bool>(Evaluate);
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<CodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            var evaluted = new Evaluated(enabled);
            _evaluated.ForEach(x => x.OnNext(evaluted));

            return enabled;
        }

        bool GetEnabled()
        {
            CodeFeatureState codeFeatureState;
            ContextFeatureState contextFeatureState;
            if (_contextCache.TryGetContextFeatureState(_context, out contextFeatureState))
            {
                if (contextFeatureState.TryGetCodeFeatureState<TFeature>(out codeFeatureState))
                    return codeFeatureState.Enabled;
            }

            return _cache.TryGetState<TFeature>(out codeFeatureState) && codeFeatureState.Enabled;
        }


        class Evaluated :
            CodeSwitchEvaluated
        {
            readonly bool _enabled;
            readonly string _id;
            readonly DateTime _timestamp;

            public Evaluated(bool enabled)
            {
                _timestamp = DateTime.UtcNow;
                _id = CodeFeatureMetadata<TFeature>.Id;
                _enabled = enabled;
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public string Id
            {
                get { return _id; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}