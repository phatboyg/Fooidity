namespace Fooidity.Management
{
    using System;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;


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

            return builder.Build();
        }


        static class Cache
        {
            internal static readonly Lazy<IContainer> CachedContainer = new Lazy<IContainer>(Configure);
        }
    }
}