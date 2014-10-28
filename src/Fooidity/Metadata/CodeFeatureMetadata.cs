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
        readonly CodeFeatureId _id;

        CodeFeatureMetadata()
        {
            _id = new CodeFeatureId(typeof(TFeature));
        }

        public static CodeFeatureId Id
        {
            get { return Cached.Instance.Value.Id; }
        }

        CodeFeatureId ICodeFeatureMetadata<TFeature>.Id
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