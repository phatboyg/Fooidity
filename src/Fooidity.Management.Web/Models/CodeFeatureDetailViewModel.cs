namespace Fooidity.Management.Web.Models
{
    using System.Collections.Generic;


    public class CodeFeatureDetailViewModel
    {
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }

        public CodeFeatureId CodeFeatureId { get; set; }

        public CodeFeatureStateViewModel CurrentState { get; set; }

        public IEnumerable<CodeFeatureStateViewModel> StateHistory { get; set; }
    }
}