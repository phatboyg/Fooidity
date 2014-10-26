namespace Fooidity
{
    public abstract class DynamicCodeSwitch<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        readonly ICodeFeatureStateCache _cache;

        protected DynamicCodeSwitch(ICodeFeatureStateCache cache)
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