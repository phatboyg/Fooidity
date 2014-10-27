namespace Fooidity.AutofacIntegration
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
                .Named<IReloadCache>("codeFeatureCache")
                .SingleInstance();

            builder.RegisterType<ConfigurationCodeFeatureStateCacheProvider>()
                .As<ICodeFeatureStateCacheProvider>();
        }
    }
}