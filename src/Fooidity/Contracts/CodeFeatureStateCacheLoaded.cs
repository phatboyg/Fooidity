namespace Fooidity.Contracts
{
    using System;
    using Metadata;


    public class CodeFeatureStateCacheLoaded :
        ICodeFeatureStateCacheLoaded
    {
        public CodeFeatureStateCacheLoaded()
        {
        }

        public CodeFeatureStateCacheLoaded(DateTime timestamp, TimeSpan duration, int codeFeatureCount)
        {
            EventId = Guid.NewGuid();
            Timestamp = timestamp;
            Duration = duration;
            CodeFeatureCount = codeFeatureCount;
            Host = HostMetadata.Host;
        }

        public Host Host { get; set; }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public TimeSpan Duration { get; set; }

        public int CodeFeatureCount { get; set; }

        IHost ICodeFeatureStateCacheLoaded.Host
        {
            get { return Host; }
        }
    }
}