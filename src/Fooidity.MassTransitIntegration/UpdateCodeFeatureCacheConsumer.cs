namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateCodeFeatureCacheConsumer :
        Consumes<ICodeFeatureStateUpdated>.All
    {
        static readonly ILog _log = Logger.Get<UpdateCodeFeatureCacheConsumer>();

        readonly IUpdateCodeFeatureCache _updateCache;

        public UpdateCodeFeatureCacheConsumer(IUpdateCodeFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(ICodeFeatureStateUpdated message)
        {
            Uri id = message.CodeFeatureId;
            try
            {
                var codeFeatureId = new CodeFeatureId(id);

                var update = new UpdateCodeFeature(codeFeatureId, message.Enabled, message.Timestamp, message.CommandId ?? message.EventId);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", id), ex);
            }
        }
    }
}