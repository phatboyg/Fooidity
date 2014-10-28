namespace Fooidity
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;


    /// <summary>
    /// A context id is generated based on the type and is used to identify a context
    /// in configuration sources
    /// </summary>
    [Serializable]
    public class ContextId :
        TypeUrn
    {
        public ContextId(Type type)
            : base(GetCodeFeatureId(type))
        {
        }

        public ContextId(string uriString)
            : base(uriString)
        {
            if (!Scheme.Equals("urn", StringComparison.OrdinalIgnoreCase))
                throw new FormatException("A ContextFeatureId must be a URN");
        }

        protected ContextId(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        public ContextId(Uri uri)
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