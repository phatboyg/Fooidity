namespace Fooidity.Contracts
{
    using System;


    public class ContextCodeFeatureStateUpdated :
        IContextCodeFeatureStateUpdated
    {
        public ContextCodeFeatureStateUpdated()
        {
        }

        public ContextCodeFeatureStateUpdated(Uri contextId, string contextKey, Uri codeFeatureId, bool enabled, Guid? commandId = null)
        {
            EventId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;

            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            CommandId = commandId;
            ContextId = contextId;
            ContextKey = contextKey;
        }

        public bool Enabled { get; set; }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid? CommandId { get; set; }

        public Uri CodeFeatureId { get; set; }

        public Uri ContextId { get; set; }

        public string ContextKey { get; set; }
    }
}