namespace Fooidity.Contracts
{
    using System;


    public class UpdateCodeFeature :
        IUpdateCodeFeature
    {
        public UpdateCodeFeature()
        {
        }

        public UpdateCodeFeature(CodeFeatureId codeFeatureId, bool enabled, DateTime timestamp, Guid commandId)
        {
            CodeFeatureId = codeFeatureId;
            CommandId = commandId;
            Enabled = enabled;
            Timestamp = timestamp;
        }

        public Guid CommandId { get; set; }

        public DateTime Timestamp { get; set; }

        public CodeFeatureId CodeFeatureId { get; set; }

        public bool Enabled { get; set; }
    }
}