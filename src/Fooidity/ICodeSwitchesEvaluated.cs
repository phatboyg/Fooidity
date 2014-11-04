namespace Fooidity
{
    using System.Collections.Generic;
    using Contracts;


    /// <summary>
    /// Obtain a list of evaluated code switches during execution
    /// </summary>
    public interface ICodeSwitchesEvaluated :
        IEnumerable<ICodeSwitchEvaluated>
    {
    }
}