namespace Fooidity.Client
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR.Client;


    public class ApplicationHubProxy :
        IApplicationHubProxy,
        IDisposable
    {
        readonly IEnumerable<IApplicationHubEventConnector> _connectors;
        readonly Lazy<Task<IHubProxy>> _hub;
        readonly ConcurrentDictionary<long, Task> _pendingTasks;
        IEnumerable<IDisposable> _connected;
        HubConnection _connection;
        IDisposable _onInvalidAppKey;
        IDisposable _onMissingAppKey;
        long _taskId;

        public ApplicationHubProxy(IHubConnectionProvider hubConnectionProvider, IEnumerable<IApplicationHubEventConnector> connectors)
        {
            _connectors = connectors;
            _pendingTasks = new ConcurrentDictionary<long, Task>();

            _hub = new Lazy<Task<IHubProxy>>(() => GetApplicationHubProxy(hubConnectionProvider));
        }

        public Task<IHubProxy> Proxy
        {
            get { return _hub.Value; }
        }

        public async Task<TResult> UseProxy<TResult>(Func<IHubProxy, Task<TResult>> callback)
        {
            long id = Interlocked.Increment(ref _taskId);

            try
            {
                IHubProxy hub = await _hub.Value;

                Task<TResult> task = callback(hub);

                _pendingTasks.GetOrAdd(id, _ => task);

                return await task;
            }
            finally
            {
                Task removed;
                _pendingTasks.TryRemove(id, out removed);
            }
        }

        public async Task UseProxy(Func<IHubProxy, Task> callback)
        {
            long id = Interlocked.Increment(ref _taskId);

            try
            {
                IHubProxy hub = await _hub.Value;

                Task task = callback(hub);

                _pendingTasks.GetOrAdd(id, _ => task);

                await task;
            }
            finally
            {
                Task removed;
                _pendingTasks.TryRemove(id, out removed);
            }
        }

        public void Dispose()
        {
            Task.WaitAll(_pendingTasks.Values.ToArray(), TimeSpan.FromSeconds(60));

            if (_connected != null)
            {
                foreach (IDisposable connection in _connected)
                    connection.Dispose();
            }

            if (_onInvalidAppKey != null)
                _onInvalidAppKey.Dispose();
            if (_onMissingAppKey != null)
                _onMissingAppKey.Dispose();

            if (_connection != null)
            {
                // TODO stop first??

                _connection.Dispose();
            }
        }

        async Task<IHubProxy> GetApplicationHubProxy(IHubConnectionProvider connectionProvider)
        {
            HubConnection hubConnection = connectionProvider.GetConnection();

            IHubProxy applicationHub = hubConnection.CreateHubProxy("ApplicationHub");

            _onMissingAppKey = applicationHub.On("notifyMissingAppKey", OnMissingAppKey);
            _onInvalidAppKey = applicationHub.On("notifyInvalidAppKey", OnInvalidAppKey);

            _connected = _connectors.SelectMany(x => x.Connect(applicationHub)).ToList();

            await hubConnection.Start();

            _connection = hubConnection;

            return applicationHub;
        }

        void OnInvalidAppKey()
        {
            if (_connection != null)
                _connection.Stop();
        }

        void OnMissingAppKey()
        {
            if (_connection != null)
                _connection.Stop();
        }
    }
}