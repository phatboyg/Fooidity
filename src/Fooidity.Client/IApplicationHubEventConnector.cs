namespace Fooidity.Client
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.SignalR.Client;


    public interface IApplicationHubEventConnector
    {
        IEnumerable<IDisposable> Connect(IHubProxy hubProxy);
    }
}