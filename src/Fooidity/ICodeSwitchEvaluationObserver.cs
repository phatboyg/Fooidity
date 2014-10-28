namespace Fooidity
{
    using System.Collections.Generic;
    using Events;


    /// <summary>
    /// Obtain a list of evaluated code switches during execution
    /// </summary>
    public interface ICodeSwitchEvaluationObserver
    {
        IEnumerable<CodeSwitchEvaluated> GetEvaluatedSwitches();
    }
}