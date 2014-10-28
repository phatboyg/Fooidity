namespace Fooidity
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Events;


    /// <summary>
    /// Tracks the state of evaluated switches
    /// </summary>
    public class CodeSwitchEvaluationObserver :
        IObserver<CodeSwitchEvaluated>,
        ICodeSwitchEvaluationObserver,
        ICodeSwitchesEvaluated
    {
        readonly ConcurrentBag<CodeSwitchEvaluated> _events;

        public CodeSwitchEvaluationObserver()
        {
            _events = new ConcurrentBag<CodeSwitchEvaluated>();
        }

        public IEnumerator<CodeSwitchEvaluated> GetEnumerator()
        {
            return GetEvaluatedSwitches().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<CodeSwitchEvaluated> GetEvaluatedSwitches()
        {
            return _events.OrderBy(x => x.Timestamp).ToArray();
        }

        public void OnNext(CodeSwitchEvaluated value)
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