namespace Fooidity.Client
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR.Client;


    public interface IApplicationHubProxy
    {
        Task<TResult> UseProxy<TResult>(Func<IHubProxy, Task<TResult>> callback);
        Task UseProxy(Func<IHubProxy, Task> callback);
    }
}