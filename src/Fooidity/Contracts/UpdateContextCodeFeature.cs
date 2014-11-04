namespace Fooidity.Contracts
{
    using System;


    public class UpdateContextCodeFeature :
        IUpdateContextCodeFeature
    {
        public UpdateContextCodeFeature()
        {
        }

        public UpdateContextCodeFeature(Uri contextId, string contextKey, CodeFeatureId codeFeatureId, bool enabled, DateTime timestamp,
            Guid commandId)
        {
            CodeFeatureId = codeFeatureId;
            CommandId = commandId;
            ContextId = contextId;
            Enabled = enabled;
            ContextKey = contextKey;
            Timestamp = timestamp;
        }

        public Guid CommandId { get; set; }

        public DateTime Timestamp { get; set; }

        public CodeFeatureId CodeFeatureId { get; set; }

        public Uri ContextId { get; set; }

        public string ContextKey { get; set; }

        public bool Enabled { get; set; }
    }
}