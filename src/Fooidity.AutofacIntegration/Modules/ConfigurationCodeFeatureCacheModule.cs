namespace Fooidity.Modules
{
    using Autofac;
    using Caching;
    using Configuration;


    /// <summary>
    /// Registers the types required to load the code feature cache via the App.Config
    /// </summary>
    public class ConfigurationCodeFeatureCacheModule :
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
        }
    }
}