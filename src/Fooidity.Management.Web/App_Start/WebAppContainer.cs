namespace Fooidity.Management.Web
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    using AzureIntegration;
    using Management.Models;


    public static class WebAppContainer
    {
        public static IContainer Container
        {
            get { return Cache.CachedContainer.Value; }
        }

        static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(executingAssembly);
            builder.RegisterControllers(executingAssembly);

            builder.RegisterModule<FooidityModule>();


            builder.RegisterType<UpdateCodeFeatureStateCommandHandler>()
                .As<ICommandHandler<UpdateCodeFeatureState>>();

            builder.RegisterType<QueryCodeFeatureStateQueryHandler>()
                .As<IQueryHandler<QueryCodeFeatureState, IEnumerable<CodeFeatureStateModel>>>();


            return builder.Build();
        }


        static class Cache
        {
            internal static readonly Lazy<IContainer> CachedContainer = new Lazy<IContainer>(Configure);
        }
    }
}