namespace Fooidity.Modules
{
    using Autofac;
    using Caching;
    using Configuration;


    /// <summary>
    /// Registers the types required to resolve the context cache for a given context type
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TKeyProvider"></typeparam>
    public class ConfigurationContextFeatureCacheModule<TContext, TKeyProvider> :
        Module
        where TKeyProvider : class, IContextKeyProvider<TContext>
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TKeyProvider>()
                .As<IContextKeyProvider<TContext>>();

            builder.RegisterType<ContextFeatureStateCache<TContext>>()
                .As<IContextFeatureStateCache<TContext>>()
                .As<IUpdateContextFeatureCache>()
                .As<IReloadCache>()
                .SingleInstance();

            builder.RegisterType<ConfigurationContextFeatureStateCacheProvider<TContext>>()
                .As<IContextFeatureStateCacheProvider<TContext>>();
        }
    }
}