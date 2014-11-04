namespace Fooidity.Management.Web
{
    using Autofac;
    using Caching;
    using Fooidity.AzureIntegration;
    using Switching.Contexts;
    using Switching.Features;


    class FooidityModule :
        Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureStorageAccountProvider>()
                .WithParameter("connectionName", "Fooidity.AzureIntegration.ConnectionString")
                .As<ICloudStorageAccountProvider>();

            builder.RegisterType<AzureTableProvider>()
                .As<ICloudTableProvider>()
                .SingleInstance();

            builder.RegisterType<CodeFeatureStateCache>()
                .As<ICodeFeatureStateCache>()
                .As<IReloadCache>()
                .As<IUpdateCodeFeatureCache>()
                .SingleInstance();

            builder.RegisterType<AzureCodeFeatureStateCacheProvider>()
                .As<ICodeFeatureStateCacheProvider>();

            builder.RegisterType<UserContextKeyProvider>()
                .As<IContextKeyProvider<UserContext>>();

            builder.RegisterType<ContextFeatureStateCache<UserContext>>()
                .As<IContextFeatureStateCache<UserContext>>()
                .As<IReloadCache>()
                .As<IUpdateContextFeatureCache>()
                .SingleInstance();

            builder.RegisterType<AzureContextFeatureStateCacheProvider<UserContext>>()
                .As<IContextFeatureStateCacheProvider<UserContext>>();

            builder.RegisterContextCodeSwitch<Feature_NewScreen, UserContext>();
        }
    }
}