namespace Fooidity.Management.Commands
{
    using System;


    public class UpdateApplicationCodeFeatureState :
        IUpdateApplicationCodeFeatureState
    {
        public UpdateApplicationCodeFeatureState(string applicationId, Uri codeFeatureId, bool enabled, DateTime timestamp,
            Guid? commandId = null)
        {
            CommandId = commandId.HasValue ? commandId.Value : Guid.NewGuid();
            Timestamp = timestamp;

            ApplicationId = applicationId;
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
        }

        public Guid CommandId { get; set; }

        public DateTime Timestamp { get; set; }

        public string ApplicationId { get; set; }

        public Uri CodeFeatureId { get; set; }

        public bool Enabled { get; set; }
    }
}