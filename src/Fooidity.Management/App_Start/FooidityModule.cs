namespace Fooidity.Management
{
    using Autofac;
    using Caching;
    using Configuration;
    using Features;


    class FooidityModule :
        Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CodeFeatureStateCache>()
                .As<ICodeFeatureStateCache>()
                .As<IReloadCache>()
                .As<IUpdateCodeFeatureCache>()
                .SingleInstance();

            builder.RegisterType<ConfigurationCodeFeatureStateCacheProvider>()
                .As<ICodeFeatureStateCacheProvider>();

            builder.RegisterType<UserContextKeyProvider>()
                .As<ContextKeyProvider<UserContext>>();

            builder.RegisterType<ContextFeatureStateCache<UserContext>>()
                .As<IContextFeatureStateCache<UserContext>>()
                .As<IReloadCache>()
                .As<IUpdateContextFeatureCache>()
                .SingleInstance();

            builder.RegisterType<ConfigurationContextFeatureStateCacheProvider<UserContext>>()
                .As<IContextFeatureStateCacheProvider<UserContext>>();

            builder.RegisterContextSwitch<Feature_NewScreen, UserContext>();
        }
    }
}