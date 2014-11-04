namespace Fooidity.Contracts
{
    using System;
    using Metadata;


    public class ContextCodeFeatureStateCacheLoaded :
        IContextCodeFeatureStateCacheLoaded
    {
        public ContextCodeFeatureStateCacheLoaded()
        {
        }

        public ContextCodeFeatureStateCacheLoaded(DateTime timestamp, TimeSpan duration, int contextCount)
        {
            EventId = Guid.NewGuid();
            Timestamp = timestamp;
            Duration = duration;
            ContextCount = contextCount;
            Host = HostMetadata.Host;
        }

        public Host Host { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime Timestamp { get; private set; }

        public TimeSpan Duration { get; private set; }

        public int ContextCount { get; private set; }

        IHost IContextCodeFeatureStateCacheLoaded.Host
        {
            get { return Host; }
        }
    }
}