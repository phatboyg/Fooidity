namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateContextCodeFeatureCacheConsumer :
        Consumes<IContextCodeFeatureStateUpdated>.All
    {
        static readonly ILog _log = Logger.Get<UpdateContextCodeFeatureCacheConsumer>();
        readonly IUpdateContextFeatureCache _updateCache;

        public UpdateContextCodeFeatureCacheConsumer(IUpdateContextFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(IContextCodeFeatureStateUpdated message)
        {
            Uri codeFeatureUri = message.CodeFeatureId;
            try
            {
                var codeFeatureId = new CodeFeatureId(codeFeatureUri);
                var contextId = new ContextId(message.ContextId);

                var update = new UpdateContextCodeFeature(contextId, message.ContextKey, codeFeatureId, message.Enabled, message.Timestamp,
                    message.CommandId ?? message.EventId);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", codeFeatureUri), ex);
            }
        }
    }
}