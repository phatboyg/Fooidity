namespace Fooidity
{
    using System;
    using System.Threading;


    public class CodeFeatureCache<TFeature> :
        ICodeFeatureCache<TFeature>
    {
        readonly string _id;

        CodeFeatureCache()
        {
            Type type = typeof(TFeature);

            _id = string.Format("urn:feature:{0}{1}", type.Name, type.Namespace != null ? ":" + type.Namespace : "");
        }

        public static string Id
        {
            get { return Cached.Instance.Value.Id; }
        }


        string ICodeFeatureCache<TFeature>.Id
        {
            get { return _id; }
        }


        static class Cached
        {
            internal static readonly Lazy<ICodeFeatureCache<TFeature>> Instance = new Lazy<ICodeFeatureCache<TFeature>>(
                () => new CodeFeatureCache<TFeature>(), LazyThreadSafetyMode.PublicationOnly);
        }
    }
}