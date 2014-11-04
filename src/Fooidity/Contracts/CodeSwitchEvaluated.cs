namespace Fooidity.Contracts
{
    using System;
    using Metadata;


    public class CodeSwitchEvaluated :
        ICodeSwitchEvaluated
    {
        public CodeSwitchEvaluated()
        {
        }

        public CodeSwitchEvaluated(CodeFeatureId codeFeatureId, bool enabled)
        {
            Timestamp = DateTime.UtcNow;
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            Host = HostMetadata.Host;
        }

        public CodeSwitchEvaluated(CodeFeatureId codeFeatureId, ContextId contextId, string contextKey, bool enabled)
            : this(codeFeatureId, enabled)
        {
            ContextId = contextId;
            ContextKey = contextKey;
        }

        public Host Host { get; set; }

        public DateTime Timestamp { get; set; }

        public Uri CodeFeatureId { get; set; }

        public bool Enabled { get; set; }

        public Uri ContextId { get; set; }

        public string ContextKey { get; set; }

        IHost ICodeSwitchEvaluated.Host
        {
            get { return Host; }
        }
    }
}