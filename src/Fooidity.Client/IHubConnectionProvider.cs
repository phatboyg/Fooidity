namespace Fooidity.Client
{
    using Microsoft.AspNet.SignalR.Client;


    public interface IHubConnectionProvider
    {
        HubConnection GetConnection();
    }
}