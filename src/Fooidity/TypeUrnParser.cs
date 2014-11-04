namespace Fooidity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Parses a CodeFeatureId into the appropriate .NET type name
    /// </summary>
    class TypeUrnParser
    {
        /// <summary>
        /// Transforms a type name specified in a given URN to a .Net-compatible type name.
        /// </summary>
        public string Parse(Uri uri)
        {
            if (!uri.Scheme.Equals("urn", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("A CodeFeatureId must be a URN", "uri");

            string absolutePath = uri.AbsolutePath;

            const string featurePreamble = "feature:";
            const string contextPreamble = "context:";
            if (absolutePath.StartsWith(featurePreamble, StringComparison.OrdinalIgnoreCase))
                absolutePath = absolutePath.Substring(featurePreamble.Length);
            else if (absolutePath.StartsWith(contextPreamble, StringComparison.OrdinalIgnoreCase))
                absolutePath = absolutePath.Substring(contextPreamble.Length);

            // Workaround for a bug in .NET < 4.5.1 which incorrectly
            // escapes '[' and ']' as %5B and %5D (respectively) under some
            // circumstances, even though both are RFC 2396 unreserved characters.
            // http://stackoverflow.com/questions/20003106/uri-escapeuristring-with-square-braces
            // http://msdn.microsoft.com/en-us/library/hh367887%28v=vs.110%29.aspx
            absolutePath = absolutePath.Replace("%5B", "[").Replace("%5D", "]");

            var root = new TypeNameNode();
            TypeNameNode current = root;

            foreach (char c in absolutePath)
            {
                switch (c)
                {
                    case '[': // go one level down
                        var child = new TypeNameNode(current);
                        current.Children.Add(child);
                        current = child;
                        break;
                    case ']': // go one level up
                        current = current.Parent;
                        break;
                    case ',': // sibling will be caugth by '['
                    case ' ': // ignore whitespace
                        break;
                    default:
                        current.ContentBuilder.Append(c);
                        break;
                }
            }

            root.Flatten();
            return root.ToString();
        }


        class TypeNameNode
        {
            public readonly StringBuilder ContentBuilder;
            public readonly TypeNameNode Parent;
            public List<TypeNameNode> Children;

            public TypeNameNode(TypeNameNode parent)
                : this()
            {
                Parent = parent;
            }

            public TypeNameNode()
            {
                ContentBuilder = new StringBuilder();
                Children = new List<TypeNameNode>();
            }

            string GenericParameters
            {
                get { return Children.Count > 0 ? "`" + Children.Count : String.Empty; }
            }

            string GenericArguments
            {
                get
                {
                    // no generic type arguments
                    if (Children.Count == 0)
                        return String.Empty;

                    // if any of the type arguments are empty, treat current
                    // type as an open generic - without brackets, just the backtick
                    string[] childrenNames = Children.Select(c => c.ToString()).ToArray();
                    return childrenNames.Any(c => c.Length == 0)
                        ? String.Empty
                        : "[" + String.Join(",", childrenNames) + "]";
                }
            }

            string FormatAsNetTypeName()
            {
                // I'm just an open generic argument, no antual content!
                if (ContentBuilder.Length == 0)
                    return String.Empty;

                string[] nameParts = ContentBuilder.ToString().Split(':');
                string netTypeName = String.Empty;

                switch (nameParts.Length)
                {
                    case 1:
                        netTypeName = nameParts[0] + GenericParameters + GenericArguments;
                        break;
                    case 2:
                        netTypeName = nameParts[1] + "." + nameParts[0] + GenericParameters + GenericArguments + ", " + nameParts[1];
                        break;
                    default:
                        if (nameParts.Length >= 3)
                        {
                            // Namespace:ClassName:AssemblyName -> Namespace.ClassName`Tn[T1, T2, ..., Tn], AssemblyName
                            netTypeName = nameParts[1] + "." + nameParts[0] + GenericParameters + GenericArguments + ", " + nameParts[2];
                        }
                        break;
                }

                return netTypeName;
            }

            /// <summary>
            /// Makes sure there is no nested empty parentheses.
            /// </summary>
            public void Flatten()
            {
                if (ContentBuilder.Length == 0 && Parent != null)
                    Parent.Children = Children;

                foreach (TypeNameNode child in Children)
                    child.Flatten();
            }

            /// <summary>
            /// Returns the node formatted as a .Net type name, including its children.
            /// </summary>
            public override string ToString()
            {
                string formattedName = FormatAsNetTypeName() ?? String.Empty;

                // for the root (outer message type) return name without brackets;
                // if type name is empty (I'm an open generic argument) do so too
                if (Parent == null || String.IsNullOrEmpty(formattedName))
                    return formattedName;
                return "[" + formattedName + "]";
            }
        }
    }
}