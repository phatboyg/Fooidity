namespace Fooidity.Contracts
{
    using System;


    public class ContextCodeFeatureStateDisabled :
        IContextCodeFeatureStateDisabled
    {
        public ContextCodeFeatureStateDisabled()
        {
        }

        public ContextCodeFeatureStateDisabled(Uri contextId, string contextKey, Uri codeFeatureId, Guid? commandId = null)
        {
            EventId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;

            CodeFeatureId = codeFeatureId;
            CommandId = commandId;
            ContextId = contextId;
            ContextKey = contextKey;
        }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid? CommandId { get; set; }

        public Uri CodeFeatureId { get; set; }

        public Uri ContextId { get; set; }

        public string ContextKey { get; set; }
    }
}