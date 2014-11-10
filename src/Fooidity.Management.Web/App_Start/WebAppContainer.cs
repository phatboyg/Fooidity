namespace Fooidity.Management.Web
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    using AzureIntegration;
    using AzureIntegration.CommandHandlers;
    using AzureIntegration.QueryHandlers;
    using AzureIntegration.UserStore;
    using Commands;
    using Contracts;
    using Fooidity.AzureIntegration;
    using Fooidity.Contracts;
    using Hubs;
    using Management.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Queries;


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

            builder.Register(context =>
            {
                var tableProvider = context.Resolve<ICloudTableProvider>();

                return new UserManager<ApplicationUser>(new TableUserStore<ApplicationUser>(tableProvider));
            })
                .As<UserManager<ApplicationUser>>();

            builder.RegisterType<UpdateCodeFeatureStateCommandHandler>()
                .As<ICommandHandler<UpdateCodeFeatureState>>();

            builder.RegisterType<QueryCodeFeatureStateQueryHandler>()
                .As<IQueryHandler<QueryCodeFeatureState, IEnumerable<ICodeFeatureState>>>();

            builder.RegisterType<ListApplicationsQueryHandler>()
                .As<IQueryHandler<IListApplications, IEnumerable<IUserOrganizationApplication>>>();

            builder.RegisterType<ListOrganizationsQueryHandler>()
                .As<IQueryHandler<IListOrganizations, IEnumerable<IOrganization>>>();

            builder.RegisterType<GetOrganizationQueryHandler>()
                .As<IQueryHandler<IGetOrganization, IOrganization>>();

            builder.RegisterType<GetApplicationQueryHandler>()
                .As<IQueryHandler<IGetApplication, IUserOrganizationApplication>>();

            builder.RegisterType<CreateOrganizationCommandHandler>()
                .As<ICommandHandler<ICreateOrganization, IOrganization>>();

            builder.RegisterType<CreateApplicationCommandHandler>()
                .As<ICommandHandler<ICreateApplication, IUserOrganizationApplication>>();

            builder.RegisterType<CreateApplicationKeyCommandHandler>()
                .As<ICommandHandler<ICreateApplicationKey, IOrganizationApplicationKey>>();

            builder.RegisterType<ListApplicationKeysQueryHandler>()
                .As<IQueryHandler<IListApplicationKeys, IEnumerable<IOrganizationApplicationKey>>>();

            builder.RegisterType<GetApplicationKeyQueryHandler>()
                .As<IQueryHandler<IGetApplicationByKey, IOrganizationApplicationKey>>();

            builder.RegisterType<RegisterCodeFeatureCommandHandler>()
                .As<ICommandHandler<IRegisterCodeFeature>>();

            builder.RegisterType<RegisterApplicationContextCommandHandler>()
                .As<ICommandHandler<IRegisterApplicationContext>>();

            builder.RegisterType<UpdateApplicationCodeFeatureStateCommandHandler>()
                .As<ICommandHandler<IUpdateApplicationCodeFeatureState>>();

            builder.RegisterType<ListApplicationCodeFeaturesQueryHandler>()
                .As<IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>>>();

            builder.RegisterType<GetCodeFeatureDetailQueryHandler>()
                .As<IQueryHandler<IGetCodeFeatureDetail, ICodeFeatureDetail>>();

            builder.RegisterType<ApplicationHubEventHandler>()
                .As<IEventHandler<IApplicationCodeFeatureStateUpdated>>();

            builder.RegisterType<ApplicationHub>();

            builder.RegisterType<DefaultAzureManagementSettings>()
                .As<IAzureManagementSettings>()
                .SingleInstance();

            return builder.Build();
        }


        static class Cache
        {
            internal static readonly Lazy<IContainer> CachedContainer = new Lazy<IContainer>(Configure);
        }
    }
}