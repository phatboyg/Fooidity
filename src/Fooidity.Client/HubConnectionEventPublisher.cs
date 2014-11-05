namespace Fooidity.Client
{
    using System;
    using Microsoft.AspNet.SignalR.Client;


    public class HubConnectionEventPublisher :
        IDisposable
    {
        readonly HubConnection _hubConnection;

        public HubConnectionEventPublisher(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;

            hubConnection.Error += PublishError;
            hubConnection.ConnectionSlow += PublishSlow;
            hubConnection.StateChanged += PublishStateChange;
            hubConnection.Closed += PublishClosed;
            hubConnection.Reconnecting += PublishReconnecting;
            hubConnection.Reconnected += PublishReconnected;
        }

        public void Dispose()
        {
        }

        void PublishReconnected()
        {
        }

        void PublishReconnecting()
        {
        }

        void PublishClosed()
        {
        }

        void PublishStateChange(StateChange stateChange)
        {
        }

        void PublishSlow()
        {
        }

        void PublishError(Exception exception)
        {
        }
    }
}