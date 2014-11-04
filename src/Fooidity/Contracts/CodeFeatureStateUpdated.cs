namespace Fooidity.Contracts
{
    using System;


    public class CodeFeatureStateUpdated :
        ICodeFeatureStateUpdated
    {
        public CodeFeatureStateUpdated()
        {
        }

        public CodeFeatureStateUpdated(Uri codeFeatureId, bool enabled, Guid eventId, DateTime timestamp, Guid? commandId = null)
        {
            CodeFeatureId = codeFeatureId;
            Enabled = enabled;
            CommandId = commandId;
            EventId = eventId;
            Timestamp = timestamp;
        }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid? CommandId { get; set; }

        public Uri CodeFeatureId { get; set; }

        public bool Enabled { get; set; }
    }
}