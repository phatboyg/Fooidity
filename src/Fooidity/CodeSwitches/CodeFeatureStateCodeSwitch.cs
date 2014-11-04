namespace Fooidity.CodeSwitches
{
    using System;
    using Configuration;
    using Contracts;


    /// <summary>
    /// A dynamic code switch that uses the feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public class CodeFeatureStateCodeSwitch<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;

        public CodeFeatureStateCodeSwitch(ICodeFeatureStateCache cache)
        {
            _cache = cache;

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
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            CodeFeatureState featureState;
            return _cache.TryGetState<TFeature>(out featureState) && featureState.Enabled;
        }
    }
}