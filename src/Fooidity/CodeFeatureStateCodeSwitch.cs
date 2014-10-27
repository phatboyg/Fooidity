namespace Fooidity
{
    using Configuration;


    /// <summary>
    /// A dynamic code switch that uses the feature state cache to determine the switch state
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public class CodeFeatureStateCodeSwitch<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;

        public CodeFeatureStateCodeSwitch(ICodeFeatureStateCache cache)
        {
            _cache = cache;
        }

        public bool Enabled
        {
            get
            {
                CodeFeatureState featureState;
                return _cache.TryGetState<TFeature>(out featureState) && featureState.Enabled;
            }
        }
    }
}