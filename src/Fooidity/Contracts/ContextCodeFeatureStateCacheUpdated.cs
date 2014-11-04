namespace Fooidity.Contracts
{
    using System;
    using Metadata;


    public class ContextCodeFeatureStateCacheUpdated :
        IContextCodeFeatureStateCacheUpdated
    {
        public ContextCodeFeatureStateCacheUpdated()
        {
        }

        public ContextCodeFeatureStateCacheUpdated(Uri contextId, string contextKey, Uri codeFeatureId, bool enabled, Guid? commandId = null)
        {
            EventId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;

            CommandId = commandId;
            ContextId = contextId;
            ContextKey = contextKey;
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            Host = HostMetadata.Host;
        }

        public Host Host { get; private set; }

        public bool Enabled { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime Timestamp { get; private set; }

        public Guid? CommandId { get; private set; }

        public Uri ContextId { get; private set; }

        public string ContextKey { get; private set; }

        public Uri CodeFeatureId { get; private set; }

        IHost IContextCodeFeatureStateCacheUpdated.Host
        {
            get { return Host; }
        }
    }
}