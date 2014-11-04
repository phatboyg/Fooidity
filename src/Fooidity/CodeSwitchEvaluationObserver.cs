namespace Fooidity
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;


    /// <summary>
    /// Tracks the state of evaluated switches
    /// </summary>
    public class CodeSwitchEvaluationObserver :
        IObserver<ICodeSwitchEvaluated>,
        ICodeSwitchEvaluationObserver,
        ICodeSwitchesEvaluated
    {
        readonly ConcurrentBag<ICodeSwitchEvaluated> _events;

        public CodeSwitchEvaluationObserver()
        {
            _events = new ConcurrentBag<ICodeSwitchEvaluated>();
        }

        public IEnumerator<ICodeSwitchEvaluated> GetEnumerator()
        {
            return GetEvaluatedSwitches().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<ICodeSwitchEvaluated> GetEvaluatedSwitches()
        {
            return _events.OrderBy(x => x.Timestamp).ToArray();
        }

        public void OnNext(ICodeSwitchEvaluated value)
        {
            _events.Add(value);
        }

        public void OnError(Exception error)
        {
        }

        public void OnCompleted()
        {
        }
    }
}