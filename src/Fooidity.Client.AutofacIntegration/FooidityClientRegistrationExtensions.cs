namespace Fooidity.Client.AutofacIntegration
{
    using System;
    using Autofac;
    using Configuration;


    public static class FooidityClientRegistrationExtensions
    {
        public static void ConfigureFoodityClient(this ContainerBuilder builder, Action<IClientConfigurator> configureClient)
        {
            var configurator = new AutofacClientConfigurator(builder);

            configureClient(configurator);
        }
    }
}