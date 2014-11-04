namespace Fooidity.Client
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Caching;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    public class FooidityClient :
        IObserver<ICodeSwitchEvaluated>,
        IDisposable,
        ICodeFeatureStateCache
    {
        readonly string _applicationKey;
        IHubProxy _applicationHub;
        ICodeFeatureStateCache _cache;
        HubConnection _hubConnection;
        CodeSwitchEvaluationApplicationReporter _reporter;
        IUpdateCodeFeatureCache _updateCache;

        public FooidityClient(string applicationKey)
        {
            _applicationKey = applicationKey;
        }

        public bool TryGetState<TFeature>(out Caching.ICachedCodeFeatureState featureState)
        {
            if (_cache != null)
                return _cache.TryGetState<TFeature>(out featureState);

            featureState = default(Caching.ICachedCodeFeatureState);
            return false;
        }

        public void Dispose()
        {
            if (_hubConnection != null)
            {
                try
                {
                    _hubConnection.Stop();
                }
                finally
                {
                    _hubConnection.Dispose();
                }
            }
        }

        public void OnNext(ICodeSwitchEvaluated value)
        {
            if (_reporter != null)
                _reporter.OnNext(value);
        }

        public void OnError(Exception error)
        {
            if (_reporter != null)
                _reporter.OnError(error);
        }

        public void OnCompleted()
        {
            if (_reporter != null)
                _reporter.OnCompleted();
        }

        public async Task Connect(string hostAddress)
        {
            var hubConnection = new HubConnection(hostAddress);

            hubConnection.Headers.Add(Headers.FooidityAppKey, _applicationKey);


            hubConnection.Error += x => Console.WriteLine(x.Message);
            hubConnection.ConnectionSlow += () => Console.WriteLine("Connection is slow");
            hubConnection.StateChanged += x => Console.WriteLine("state changed from {0} to {1}",x.OldState, x.NewState);
            hubConnection.Closed += () => Console.WriteLine("connection closed");
            hubConnection.Received += x => Console.WriteLine("received: {0}", x);

            IHubProxy applicationHub = hubConnection.CreateHubProxy("ApplicationHub");

            applicationHub.On("notifyMissingAppKey", OnMissingAppKey);
            applicationHub.On("notifyInvalidAppKey", OnInvalidAppKey);

            applicationHub.On<CodeFeatureStateUpdated>("notifyCodeFeatureStateUpdated", OnCodeFeatureStateUpdated);

            await hubConnection.Start();

            _hubConnection = hubConnection;
            _applicationHub = applicationHub;
            _reporter = new CodeSwitchEvaluationApplicationReporter(_applicationHub);

            await Task.Run(() =>
            {
                var cache = new CodeFeatureStateCache(new ApplicationHubProvider(applicationHub));

                _cache = cache;
                _updateCache = cache;
            });
        }

        void OnInvalidAppKey()
        {
            _hubConnection.Stop();
        }

        void OnMissingAppKey()
        {
            _hubConnection.Stop();
        }

        void OnCodeFeatureStateUpdated(ICodeFeatureStateUpdated message)
        {
            IUpdateCodeFeature update = new UpdateCodeFeature(new CodeFeatureId(message.CodeFeatureId), message.Enabled,
                message.Timestamp, message.CommandId ?? Guid.NewGuid());
            _updateCache.UpdateCache(update);

            Console.WriteLine("Updated: {0} to {1}", message.CodeFeatureId, message.Enabled);
        }
    }
}