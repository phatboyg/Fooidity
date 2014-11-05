namespace Fooidity
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;


    /// <summary>
    /// 
    /// </summary>
    public class DistinctCodeSwitchEvaluationObserver :
        IObserver<ICodeSwitchEvaluated>,
        IDisposable
    {
        readonly ConcurrentDictionary<Tuple<Uri, Uri>, Task> _contextTasks;
        readonly ConcurrentDictionary<Uri, Task> _featureTasks;
        readonly ICodeSwitchEventHandler _handler;

        public DistinctCodeSwitchEvaluationObserver(ICodeSwitchEventHandler handler)
        {
            _handler = handler;
            _featureTasks = new ConcurrentDictionary<Uri, Task>();
            _contextTasks = new ConcurrentDictionary<Tuple<Uri, Uri>, Task>();
        }

        public void Dispose()
        {
            Task.WaitAll(_featureTasks.Values.Concat(_contextTasks.Values).ToArray(), TimeSpan.FromSeconds(60));
        }

        public void OnNext(ICodeSwitchEvaluated value)
        {
            if (value.ContextId != null)
                _contextTasks.GetOrAdd(Tuple.Create(value.CodeFeatureId, value.ContextId), x => _handler.Handle(value));
            else
                _featureTasks.GetOrAdd(value.CodeFeatureId, x => _handler.Handle(value));
        }

        public void OnError(Exception error)
        {
        }

        public void OnCompleted()
        {
        }
    }
}