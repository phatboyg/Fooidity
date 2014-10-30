namespace Fooidity.CodeSwitches
{
    using System;
    using Caching.Internals;
    using Contracts;
    using Metadata;


    class CodeSwitchEvaluatedObservable<TFeature> :
        Connectable<IObserver<CodeSwitchEvaluated>>
        where TFeature : struct, CodeFeature
    {
        public void Evaluated(bool enabled)
        {
            var evaluted = new CodeSwitchEvaluatedEvent(enabled);
            ForEach(x => x.OnNext(evaluted));
        }

        public void Evaluated(ContextId contextId, string contextKey, bool enabled)
        {
            var evaluted = new CodeSwitchEvaluatedEvent(contextId, contextKey, enabled);
            ForEach(x => x.OnNext(evaluted));
        }


        class CodeSwitchEvaluatedEvent :
            CodeSwitchEvaluated
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Uri _contextId;
            readonly string _contextKey;
            readonly bool _enabled;
            readonly Host _host;
            readonly DateTime _timestamp;

            public CodeSwitchEvaluatedEvent(bool enabled)
            {
                _timestamp = DateTime.UtcNow;
                _codeFeatureId = CodeFeatureMetadata<TFeature>.Id;
                _enabled = enabled;
                _host = HostMetadata.Host;
            }

            public CodeSwitchEvaluatedEvent(ContextId contextId, string contextKey, bool enabled)
                : this(enabled)
            {
                _contextId = contextId;
                _contextKey = contextKey;
            }

            public Host Host
            {
                get { return _host; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public Uri CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }

            public Uri ContextId
            {
                get { return _contextId; }
            }

            public string ContextKey
            {
                get { return _contextKey; }
            }
        }
    }
}