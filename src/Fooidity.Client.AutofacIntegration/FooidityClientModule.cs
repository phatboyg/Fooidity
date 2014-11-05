namespace Fooidity.Client.AutofacIntegration
{
    using System;
    using Autofac;
    using Caching;
    using Contracts;


    public class FooidityClientModule :
        Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CodeSwitchContainerScope>()
                .As<ICodeSwitchContainerScope>()
                .ExternallyOwned();

            builder.RegisterType<CodeFeatureStateCache>()
                .As<ICodeFeatureStateCache>()
                .As<IReloadCache>()
                .As<IUpdateCodeFeatureCache>()
                .SingleInstance();

            builder.RegisterType<ApplicationHubCodeFeatureStateCacheProvider>()
                .As<ICodeFeatureStateCacheProvider>();

            builder.RegisterType<ApplicationHubProxy>()
                .As<IApplicationHubProxy>()
                .SingleInstance();

            builder.RegisterType<HubConnectionProvider>()
                .As<IHubConnectionProvider>();

            builder.RegisterType<UpdateCacheApplicationHubEventConnector>()
                .As<IApplicationHubEventConnector>();

            builder.RegisterType<DistinctCodeSwitchEvaluationObserver>()
                .As<IObserver<ICodeSwitchEvaluated>>()
                .SingleInstance();

            builder.RegisterType<ApplicationHubCodeSwitchEventHandler>()
                .As<ICodeSwitchEventHandler>();

            builder.RegisterType<FooidityClient>()
                .As<IFooidityClient>()
                .SingleInstance();
        }
    }
}