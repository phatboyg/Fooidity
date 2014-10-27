namespace Fooidity
{
    using System;
    using Caching;
    using Caching.Internals;
    using Configuration;
    using Events;
    using Metadata;


    /// <summary>
    /// A dynamic code switch that uses the feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public class CodeFeatureStateCodeSwitch<TFeature> :
        CodeSwitch<TFeature>,
        IObservable<CodeSwitchEvaluated>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;
        readonly Lazy<bool> _enabled;
        readonly Connectable<IObserver<CodeSwitchEvaluated>> _evaluated;

        public CodeFeatureStateCodeSwitch(ICodeFeatureStateCache cache)
        {
            _cache = cache;

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
            CodeFeatureState featureState;
            return _cache.TryGetState<TFeature>(out featureState) && featureState.Enabled;
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