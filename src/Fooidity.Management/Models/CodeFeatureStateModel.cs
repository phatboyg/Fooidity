namespace Fooidity.Management.Models
{
    using System;


    public class CodeFeatureStateModel :
        ICodeFeatureState,
        IEquatable<CodeFeatureStateModel>
    {
        public CodeFeatureStateModel(CodeFeatureId codeFeatureId, DateTime lastUpdated, bool enabled)
        {
            CodeFeatureId = codeFeatureId;
            LastUpdated = lastUpdated;
            Enabled = enabled;
        }

        public CodeFeatureId CodeFeatureId { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Enabled { get; set; }

        public bool Equals(CodeFeatureStateModel other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return CodeFeatureId.Equals(other.CodeFeatureId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((CodeFeatureStateModel)obj);
        }

        public override int GetHashCode()
        {
            return CodeFeatureId.GetHashCode();
        }
    }
}