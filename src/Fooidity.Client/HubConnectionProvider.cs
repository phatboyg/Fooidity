namespace Fooidity.Client
{
    using Configuration;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    /// <summary>
    /// Creates a hub connection using the client settings
    /// </summary>
    public class HubConnectionProvider :
        IHubConnectionProvider
    {
        readonly IClientSettings _settings;

        public HubConnectionProvider(IClientSettings settings)
        {
            _settings = settings;
        }

        public HubConnection GetConnection()
        {
            var hubConnection = new HubConnection(_settings.HostAddress);

            hubConnection.Headers.Add(Headers.FooidityAppKey, _settings.ApplicationKey);

            return hubConnection;
        }
    }
}