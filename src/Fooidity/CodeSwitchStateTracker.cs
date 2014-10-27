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
    public class CodeSwitchStateTracker :
        IObserver<CodeSwitchEvaluated>,
        IEnumerable<CodeSwitchEvaluated>
    {
        readonly ConcurrentBag<CodeSwitchEvaluated> _events;

        public CodeSwitchStateTracker()
        {
            _events = new ConcurrentBag<CodeSwitchEvaluated>();
        }

        public IEnumerator<CodeSwitchEvaluated> GetEnumerator()
        {
            return _events.OrderBy(x => x.Timestamp).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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