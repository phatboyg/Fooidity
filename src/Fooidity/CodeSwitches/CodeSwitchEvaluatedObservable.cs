namespace Fooidity.CodeSwitches
{
    using System;
    using Caching.Internals;
    using Contracts;
    using Metadata;


    class CodeSwitchEvaluatedObservable<TFeature> :
        Connectable<IObserver<ICodeSwitchEvaluated>>
        where TFeature : struct, CodeFeature
    {
        public void Evaluated(bool enabled)
        {
            var evaluted = new CodeSwitchEvaluated(CodeFeatureMetadata<TFeature>.Id, enabled);
            ForEach(x => x.OnNext(evaluted));
        }

        public void Evaluated(ContextId contextId, string contextKey, bool enabled)
        {
            var evaluted = new CodeSwitchEvaluated(CodeFeatureMetadata<TFeature>.Id, contextId, contextKey, enabled);
            ForEach(x => x.OnNext(evaluted));
        }
    }
}