namespace Fooidity.CodeSwitches
{
    using System;
    using Caching.Internals;
    using Events;
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


        class CodeSwitchEvaluatedEvent :
            CodeSwitchEvaluated
        {
            readonly bool _enabled;
            readonly string _id;
            readonly DateTime _timestamp;

            public CodeSwitchEvaluatedEvent(bool enabled)
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