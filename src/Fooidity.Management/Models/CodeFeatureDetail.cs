namespace Fooidity.Management.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Fooidity.Contracts;


    public class CodeFeatureDetail :
        ICodeFeatureDetail
    {
        public CodeFeatureDetail(string applicationId, string applicationName, CodeFeatureId codeFeatureId, ICodeFeatureState currentState,
            IEnumerable<ICodeFeatureState> stateHistory)
        {
            ApplicationId = applicationId;
            ApplicationName = applicationName;
            CodeFeatureId = codeFeatureId;
            CurrentState = currentState;
            StateHistory = stateHistory.ToArray();
        }

        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public CodeFeatureId CodeFeatureId { get; set; }
        public ICodeFeatureState CurrentState { get; set; }
        public IEnumerable<ICodeFeatureState> StateHistory { get; set; }
    }
}