namespace Fooidity
{
    using System;
    using Autofac;
    using Client.AutofacIntegration;
    using Client.Configuration;


    public static class FooidityClientRegistrationExtensions
    {
        public static void ConfigureFoodityClient(this ContainerBuilder builder, Action<IClientConfigurator> configureClient)
        {
            var configurator = new AutofacClientConfigurator(builder);

            configureClient(configurator);
        }
    }
}