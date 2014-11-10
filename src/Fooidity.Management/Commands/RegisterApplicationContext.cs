namespace Fooidity.Management.Commands
{
    public class RegisterApplicationContext :
        IRegisterApplicationContext
    {
        public RegisterApplicationContext(string applicationId, string contextId)
        {
            ApplicationId = applicationId;
            ContextId = contextId;
        }

        public string ApplicationId { get; set; }
        public string ContextId { get; set; }
    }
}