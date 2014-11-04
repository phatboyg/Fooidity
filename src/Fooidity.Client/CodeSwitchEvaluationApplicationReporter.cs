namespace Fooidity.Client
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    /// <summary>
    /// Reports newly evaluated switches to the application hub, only once for each switch type
    /// </summary>
    public class CodeSwitchEvaluationApplicationReporter :
        IObserver<ICodeSwitchEvaluated>
    {
        readonly IHubProxy _applicationHub;
        readonly ConcurrentDictionary<Uri, Task> _notificationTasks;

        public CodeSwitchEvaluationApplicationReporter(IHubProxy applicationHub)
        {
            _applicationHub = applicationHub;
            _notificationTasks = new ConcurrentDictionary<Uri, Task>();
        }

        public void OnNext(ICodeSwitchEvaluated value)
        {
            _notificationTasks.GetOrAdd(value.CodeFeatureId, x => _applicationHub.Invoke("OnCodeSwitchEvaluated", value));
        }

        public void OnError(Exception error)
        {
        }

        public void OnCompleted()
        {
        }

        public Task Stop()
        {
            return Task.WhenAll(_notificationTasks.Values);
        }
    }
}