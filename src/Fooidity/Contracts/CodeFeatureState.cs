namespace Fooidity.Contracts
{
    using System;


    public class CodeFeatureState :
        ICodeFeatureState,
        IEquatable<CodeFeatureState>
    {
        public CodeFeatureState(Uri codeFeatureId, DateTime lastUpdated, bool enabled)
        {
            CodeFeatureId = codeFeatureId;
            LastUpdated = lastUpdated;
            Enabled = enabled;
        }

        public Uri CodeFeatureId { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Enabled { get; set; }

        public bool Equals(CodeFeatureState other)
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

            return Equals((CodeFeatureState)obj);
        }

        public override int GetHashCode()
        {
            return CodeFeatureId.GetHashCode();
        }
    }
}