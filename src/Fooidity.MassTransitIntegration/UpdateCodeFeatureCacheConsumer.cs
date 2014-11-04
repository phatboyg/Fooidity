namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateCodeFeatureCacheConsumer :
        Consumes<ICodeFeatureStateEnabled>.All,
        Consumes<ICodeFeatureStateDisabled>.All
    {
        static readonly ILog _log = Logger.Get<UpdateCodeFeatureCacheConsumer>();

        readonly IUpdateCodeFeatureCache _updateCache;

        public UpdateCodeFeatureCacheConsumer(IUpdateCodeFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(ICodeFeatureStateDisabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, false);
        }

        public void Consume(ICodeFeatureStateEnabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, true);
        }

        void UpdateCodeFeature(Uri id, Guid commandId, DateTime timestamp, bool enabled)
        {
            try
            {
                var codeFeatureId = new CodeFeatureId(id);

                var update = new UpdateCodeFeature(codeFeatureId, enabled, timestamp, commandId);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", id), ex);
            }
        }
    }
}