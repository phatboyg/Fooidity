namespace Fooidity
{
    using System;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;


    public class TypeUrn :
        Uri
    {
        protected TypeUrn(string uriString)
            : base(uriString)
        {
        }

        protected TypeUrn(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        public Type GetType(bool throwOnError = true, bool ignoreCase = true)
        {
            if (Segments.Length == 0)
            {
                if (throwOnError)
                    throw new FormatException("The TypeUrn is not in a valid format");

                return null;
            }

            string typeName = new TypeUrnParser()
                .Parse(this);

            return Type.GetType(typeName, throwOnError, ignoreCase);
        }

        protected static string FormatId(StringBuilder sb, Type type, bool includeScope)
        {
            if (type.IsGenericParameter)
                return "";

            if (type.IsNested)
            {
                FormatId(sb, type.DeclaringType, false);
                sb.Append('+');
            }

            if (type.IsGenericType)
            {
                string name = type.GetGenericTypeDefinition().Name;

                // remove generic parameters (`Tc)
                int index = name.IndexOf('`');
                if (index > 0)
                    name = name.Remove(index);

                sb.Append(name);
                sb.Append('[');

                Type[] arguments = type.GetGenericArguments();
                for (int i = 0; i < arguments.Length; i++)
                {
                    if (i > 0)
                        sb.Append(',');

                    sb.Append('[');
                    FormatId(sb, arguments[i], true);
                    sb.Append(']');
                }

                sb.Append(']');
            }
            else
                sb.Append(type.Name);

            if (includeScope && type.Namespace != null)
            {
                string ns = type.Namespace;
                sb.Append(':');
                sb.Append(ns);

                AssemblyName assemblyName = type.Assembly.GetName();
                if (assemblyName.Name != type.Namespace)
                {
                    sb.Append(':');
                    sb.Append(assemblyName.Name);
                }
            }

            return sb.ToString();
        }
    }
}