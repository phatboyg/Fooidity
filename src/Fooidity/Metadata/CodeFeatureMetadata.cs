namespace Fooidity.Metadata
{
    using System;
    using System.Threading;


    /// <summary>
    /// Caches metadata about the code features to avoid duplication of information
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public class CodeFeatureMetadata<TFeature> :
        ICodeFeatureMetadata<TFeature>
    {
        readonly string _id;

        CodeFeatureMetadata()
        {
            Type type = typeof(TFeature);

            _id = string.Format("urn:feature:{0}{1}", type.Name, type.Namespace != null ? ":" + type.Namespace : "");
        }

        public static string Id
        {
            get { return Cached.Instance.Value.Id; }
        }

        public Type FeatureType
        {
            get { return typeof(TFeature); }
        }

        string ICodeFeatureMetadata<TFeature>.Id
        {
            get { return _id; }
        }


        static class Cached
        {
            internal static readonly Lazy<ICodeFeatureMetadata<TFeature>> Instance = new Lazy
                <ICodeFeatureMetadata<TFeature>>(
                () => new CodeFeatureMetadata<TFeature>(), LazyThreadSafetyMode.PublicationOnly);
        }
    }
}