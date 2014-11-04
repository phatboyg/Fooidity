namespace Fooidity.Management.Web
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    using AzureIntegration;
    using AzureIntegration.Commands;
    using AzureIntegration.Queries;
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
                .As<IQueryHandler<QueryCodeFeatureState, IEnumerable<CodeFeatureStateModelDoDie>>>();

            builder.RegisterType<ListApplicationsQueryHandler>()
                .As<IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>>>();

            builder.RegisterType<ListOrganizationsQueryHandler>()
                .As<IQueryHandler<ListOrganizations, IEnumerable<Organization>>>();

            builder.RegisterType<GetOrganizationQueryHandler>()
                .As<IQueryHandler<GetOrganization, Organization>>();

            builder.RegisterType<GetApplicationQueryHandler>()
                .As<IQueryHandler<GetApplication, UserOrganizationApplication>>();

            builder.RegisterType<CreateOrganizationCommandHandler>()
                .As<ICommandHandler<CreateOrganization, Organization>>();

            builder.RegisterType<CreateApplicationCommandHandler>()
                .As<ICommandHandler<CreateApplication, UserOrganizationApplication>>();

            builder.RegisterType<CreateApplicationKeyCommandHandler>()
                .As<ICommandHandler<CreateApplicationKey, OrganizationApplicationKey>>();

            builder.RegisterType<ListApplicationKeysQueryHandler>()
                .As<IQueryHandler<ListApplicationKeys, IEnumerable<OrganizationApplicationKey>>>();

            builder.RegisterType<GetApplicationKeyQueryHandler>()
                .As<IQueryHandler<GetApplicationKey, OrganizationApplicationKey>>();

            builder.RegisterType<RegisterCodeFeatureCommandHandler>()
                .As<ICommandHandler<RegisterCodeFeature>>();

            builder.RegisterType<UpdateApplicationCodeFeatureStateCommandHandler>()
                .As<ICommandHandler<IUpdateApplicationCodeFeatureState>>();

            builder.RegisterType<ListApplicationCodeFeaturesQueryHandler>()
                .As<IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>>>();

            builder.RegisterType<HubEventHandler>()
                .As<IEventHandler<IApplicationCodeFeatureStateUpdated>>();

            builder.RegisterType<ApplicationHub>();

            builder.RegisterType<DefaultAzureManagementSettings>()
                .As<AzureManagementSettings>()
                .SingleInstance();

            return builder.Build();
        }


        static class Cache
        {
            internal static readonly Lazy<IContainer> CachedContainer = new Lazy<IContainer>(Configure);
        }
    }
}