namespace Fooidity.Contracts
{
    using System;
    using Metadata;


    class CodeFeatureStateCacheUpdated :
        ICodeFeatureStateCacheUpdated
    {
        public CodeFeatureStateCacheUpdated()
        {
        }

        public CodeFeatureStateCacheUpdated(DateTime timestamp, TimeSpan duration, Uri codeFeatureId, bool enabled,
            Guid? commandId = null)
        {
            EventId = Guid.NewGuid();
            Timestamp = timestamp;
            Duration = duration;
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            CommandId = commandId;
            Host = HostMetadata.Host;
        }

        public Host Host { get; set; }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid? CommandId { get; set; }

        public TimeSpan Duration { get; set; }

        public Uri CodeFeatureId { get; set; }

        public bool Enabled { get; set; }

        IHost ICodeFeatureStateCacheUpdated.Host
        {
            get { return Host; }
        }
    }
}