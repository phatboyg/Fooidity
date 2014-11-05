namespace Fooidity.Client.AutofacIntegration
{
    using System;
    using Autofac;
    using Configuration;


    public class AutofacClientConfigurator :
        IClientConfigurator
    {
        readonly ContainerBuilder _builder;
        readonly Lazy<ClientSettings> _clientSettings;

        public AutofacClientConfigurator(ContainerBuilder builder)
        {
            _builder = builder;
            _clientSettings = new Lazy<ClientSettings>(CreateAndRegisterClientSettings);

            builder.RegisterModule<FooidityClientModule>();
        }

        public void Host(string hostAddress)
        {
            if (hostAddress == null)
                throw new ArgumentNullException("hostAddress");

            _clientSettings.Value.HostAddress = hostAddress;
        }

        public void ApplicationKey(string applicationKey)
        {
            if (applicationKey == null)
                throw new ArgumentNullException("applicationKey");

            _clientSettings.Value.ApplicationKey = applicationKey;
        }

        ClientSettings CreateAndRegisterClientSettings()
        {
            var clientSettings = new ClientSettings();

            _builder.RegisterInstance(clientSettings)
                .As<IClientSettings>();

            return clientSettings;
        }
    }
}