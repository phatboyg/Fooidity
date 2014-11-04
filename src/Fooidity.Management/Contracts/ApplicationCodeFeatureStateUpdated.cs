namespace Fooidity.Management.Contracts
{
    using System;


    public class ApplicationCodeFeatureStateUpdated :
        IApplicationCodeFeatureStateUpdated
    {
        public ApplicationCodeFeatureStateUpdated(string applicationId, Uri codeFeatureId, bool enabled, DateTime timestamp,
            Guid? commandId = null,
            Guid? eventId = null)
        {
            ApplicationId = applicationId;
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            CommandId = commandId;
            EventId = eventId.HasValue ? eventId.Value : Guid.NewGuid();
            Timestamp = timestamp;
        }

        public Guid EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid? CommandId { get; set; }
        public string ApplicationId { get; set; }
        public Uri CodeFeatureId { get; set; }
        public bool Enabled { get; set; }
    }
}