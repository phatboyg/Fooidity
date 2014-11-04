namespace Fooidity.Contracts
{
    using System;


    public class CodeFeatureStateDisabled :
        ICodeFeatureStateDisabled
    {
        public CodeFeatureStateDisabled()
        {
        }

        public CodeFeatureStateDisabled(Uri codeFeatureId, Guid eventId, DateTime timestamp, Guid? commandId = null)
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