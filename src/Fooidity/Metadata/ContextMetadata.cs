namespace Fooidity.Metadata
{
    using System;
    using System.Threading;


    /// <summary>
    /// Caches metadata about the code features to avoid duplication of information
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class ContextMetadata<TContext> :
        IContextMetadata<TContext>
    {
        readonly ContextId _id;

        ContextMetadata()
        {
            _id = new ContextId(typeof(TContext));
        }

        public static ContextId Id
        {
            get { return Cached.Instance.Value.Id; }
        }

        ContextId IContextMetadata<TContext>.Id
        {
            get { return _id; }
        }


        static class Cached
        {
            internal static readonly Lazy<IContextMetadata<TContext>> Instance = new Lazy
                <IContextMetadata<TContext>>(() => new ContextMetadata<TContext>(), LazyThreadSafetyMode.PublicationOnly);
        }
    }
}