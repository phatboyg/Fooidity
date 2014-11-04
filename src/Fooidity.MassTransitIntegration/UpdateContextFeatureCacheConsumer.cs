namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateContextCodeFeatureCacheConsumer :
        Consumes<IContextCodeFeatureStateEnabled>.All,
        Consumes<IContextCodeFeatureStateDisabled>.All
    {
        static readonly ILog _log = Logger.Get<UpdateContextCodeFeatureCacheConsumer>();
        readonly IUpdateContextFeatureCache _updateCache;

        public UpdateContextCodeFeatureCacheConsumer(IUpdateContextFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(IContextCodeFeatureStateDisabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, message.ContextId,
                message.ContextKey,
                false);
        }

        public void Consume(IContextCodeFeatureStateEnabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, message.ContextId,
                message.ContextKey,
                true);
        }

        void UpdateCodeFeature(Uri codeFeatureUri, Guid commandId, DateTime timestamp, Uri contextUri, string contextKey, bool enabled)
        {
            try
            {
                var codeFeatureId = new CodeFeatureId(codeFeatureUri);
                var contextId = new ContextId(contextUri);

                var update = new UpdateContextCodeFeature(contextId, contextKey, codeFeatureId, enabled, timestamp, commandId);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", codeFeatureUri), ex);
            }
        }
    }
}