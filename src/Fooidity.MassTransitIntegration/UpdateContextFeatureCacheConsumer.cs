namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateContextCodeFeatureCacheConsumer :
        Consumes<ContextCodeFeatureStateEnabled>.All,
        Consumes<ContextCodeFeatureStateDisabled>.All
    {
        static readonly ILog _log = Logger.Get<UpdateContextCodeFeatureCacheConsumer>();
        readonly IUpdateContextFeatureCache _updateCache;

        public UpdateContextCodeFeatureCacheConsumer(IUpdateContextFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(ContextCodeFeatureStateDisabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, message.ContextId, message.ContextKey,
                false);
        }

        public void Consume(ContextCodeFeatureStateEnabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, message.ContextId, message.ContextKey,
                true);
        }

        void UpdateCodeFeature(Uri codeFeatureUri, Guid commandId, DateTime timestamp, Uri contextUri, string key, bool enabled)
        {
            try
            {
                var codeFeatureId = new CodeFeatureId(codeFeatureUri);
                var contextId = new ContextId(contextUri);

                var update = new Update(codeFeatureId, commandId, timestamp, contextId, key, enabled);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", codeFeatureUri), ex);
            }
        }


        class Update :
            UpdateContextCodeFeature
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Guid _commandId;
            readonly ContextId _contextId;
            readonly bool _enabled;
            readonly string _key;
            readonly DateTime _timestamp;

            public Update(CodeFeatureId codeFeatureId, Guid commandId, DateTime timestamp, ContextId contextId, string key, bool enabled)
            {
                _codeFeatureId = codeFeatureId;
                _commandId = commandId;
                _enabled = enabled;
                _timestamp = timestamp;
                _contextId = contextId;
                _key = key;
            }

            public Guid CommandId
            {
                get { return _commandId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public CodeFeatureId CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public Uri ContextId
            {
                get { return _contextId; }
            }

            public string Key
            {
                get { return _key; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}