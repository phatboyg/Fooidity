namespace Fooidity.Contracts
{
    using System;


    public class CodeFeatureStateEnabled :
        ICodeFeatureStateEnabled
    {
        public CodeFeatureStateEnabled()
        {
        }

        public CodeFeatureStateEnabled(Uri codeFeatureId, Guid eventId, DateTime timestamp, Guid? commandId = null)
        {
            CodeFeatureId = codeFeatureId;
            CommandId = commandId;
            EventId = eventId;
            Timestamp = timestamp;
        }

        public Guid EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid? CommandId { get; set; }

        public Uri CodeFeatureId { get; set; }
    }
}