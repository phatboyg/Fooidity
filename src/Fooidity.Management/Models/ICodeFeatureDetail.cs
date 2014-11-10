namespace Fooidity.Management.Models
{
    using System.Collections.Generic;
    using Fooidity.Contracts;


    public interface ICodeFeatureDetail
    {
        string ApplicationId { get; }
        string ApplicationName { get; }

        CodeFeatureId CodeFeatureId { get; }

        /// <summary>
        /// The current state of the code feature
        /// </summary>
        ICodeFeatureState CurrentState { get; }

        /// <summary>
        /// The entire code feature state history
        /// </summary>
        IEnumerable<ICodeFeatureState> StateHistory { get; }
    }
}