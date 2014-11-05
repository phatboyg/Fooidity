namespace Fooidity.Client
{
    using System.Threading.Tasks;
    using Contracts;


    public class ApplicationHubCodeSwitchEventHandler :
        ICodeSwitchEventHandler
    {
        readonly IApplicationHubProxy _applicationHub;

        public ApplicationHubCodeSwitchEventHandler(IApplicationHubProxy applicationHub)
        {
            _applicationHub = applicationHub;
        }

        public async Task Handle(ICodeSwitchEvaluated message)
        {
            await _applicationHub.UseProxy(x => x.Invoke("OnCodeSwitchEvaluated", message));
        }
    }
}