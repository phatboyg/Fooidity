namespace Fooidity.Client
{
    public class FooidityClient :
        IFooidityClient
    {
        readonly IApplicationHubProxy _applicationHub;

        public FooidityClient(IApplicationHubProxy applicationHub)
        {
            _applicationHub = applicationHub;
        }
    }
}