namespace Fooidity.MassTransitIntegration
{
    using System;
    using Caching;
    using Contracts;
    using MassTransit;
    using MassTransit.Logging;


    public class UpdateCodeFeatureCacheConsumer :
        Consumes<CodeFeatureStateEnabled>.All,
        Consumes<CodeFeatureStateDisabled>.All
    {
        static readonly ILog _log = Logger.Get<UpdateCodeFeatureCacheConsumer>();

        readonly IUpdateCodeFeatureCache _updateCache;

        public UpdateCodeFeatureCacheConsumer(IUpdateCodeFeatureCache updateCache)
        {
            _updateCache = updateCache;
        }

        public void Consume(CodeFeatureStateDisabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, false);
        }

        public void Consume(CodeFeatureStateEnabled message)
        {
            UpdateCodeFeature(message.CodeFeatureId, message.CommandId ?? message.EventId, message.Timestamp, true);
        }

        void UpdateCodeFeature(Uri id, Guid commandId, DateTime timestamp, bool enabled)
        {
            try
            {
                var codeFeatureId = new CodeFeatureId(id);

                var update = new Update(codeFeatureId, commandId, timestamp, enabled);
                _updateCache.UpdateCache(update);
            }
            catch (FormatException ex)
            {
                _log.Error(string.Format("The CodeFeatureId was not valid: {0}", id), ex);
            }
        }


        class Update :
            UpdateCodeFeature
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Guid _commandId;
            readonly bool _enabled;
            readonly DateTime _timestamp;

            public Update(CodeFeatureId codeFeatureId, Guid commandId, DateTime timestamp, bool enabled)
            {
                _codeFeatureId = codeFeatureId;
                _commandId = commandId;
                _enabled = enabled;
                _timestamp = timestamp;
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

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}