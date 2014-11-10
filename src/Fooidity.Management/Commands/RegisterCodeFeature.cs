namespace Fooidity.Management.Commands
{
    using System;


    public class RegisterCodeFeature :
        IRegisterCodeFeature
    {
        public RegisterCodeFeature(string applicationId, Uri codeFeatureId)
        {
            ApplicationId = applicationId;
            CodeFeatureId = codeFeatureId.ToString();
        }

        public string ApplicationId { get; set; }
        public string CodeFeatureId { get; set; }
    }
}