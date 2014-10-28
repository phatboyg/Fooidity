namespace Fooidity
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;


    /// <summary>
    /// A code feature id is generated based on the type and is used to identify a code feature
    /// outside of the compiled code base (such as in a configuration file, database, etc).
    /// </summary>
    [Serializable]
    public class ContextFeatureId :
        TypeUrn
    {
        public ContextFeatureId(Type type)
            : base(GetCodeFeatureId(type))
        {
        }

        public ContextFeatureId(string uriString)
            : base(uriString)
        {
            if (!Scheme.Equals("urn", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("A ContextFeatureId must be a URN");
        }

        protected ContextFeatureId(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        public ContextFeatureId(Uri uri)
            : base(uri.ToString())
        {
            if (!Scheme.Equals("urn", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("A ContextFeatureId must be a URN");
        }

        static string GetCodeFeatureId(Type type)
        {
            var sb = new StringBuilder("urn:context:");

            return FormatId(sb, type, true);
        }
    }
}