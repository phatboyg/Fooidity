namespace Fooidity.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caching;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    public class FooidityClient :
        IObserver<ICodeSwitchEvaluated>,
        IDisposable
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
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"appKey", _applicationKey}
            };
            var hubConnection = new HubConnection(hostAddress, parameters);
            hubConnection.Headers.Add("X-Fooidity-AppKey", _applicationKey);

            IHubProxy applicationHub = hubConnection.CreateHubProxy("ApplicationHub");

            applicationHub.On<ICodeFeatureStateEnabled>("CodeFeatureStateEnabled", OnCodeFeatureStateEnabled);
            applicationHub.On<ICodeFeatureStateDisabled>("CodeFeatureStateDisabled", OnCodeFeatureStateDisabled);

            await hubConnection.Start();

            _hubConnection = hubConnection;
            _applicationHub = applicationHub;
            _reporter = new CodeSwitchEvaluationApplicationReporter(_applicationHub);
        }

        void OnCodeFeatureStateEnabled(ICodeFeatureStateEnabled message)
        {
            IUpdateCodeFeature update = new UpdateCodeFeature(new CodeFeatureId(message.CodeFeatureId), true,
                message.Timestamp, message.CommandId ?? Guid.NewGuid());
            _updateCache.UpdateCache(update);
        }

        void OnCodeFeatureStateDisabled(ICodeFeatureStateDisabled message)
        {
            IUpdateCodeFeature update = new UpdateCodeFeature(new CodeFeatureId(message.CodeFeatureId), true,
                message.Timestamp, message.CommandId ?? Guid.NewGuid());
            _updateCache.UpdateCache(update);
        }
    }
}