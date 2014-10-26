namespace Fooidity.Security
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledForAuthenticatedIdentity<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        public bool Enabled
        {
            get
            {
                IPrincipal principal = Thread.CurrentPrincipal;
                if (principal == null)
                    return false;

                return principal.Identity.IsAuthenticated;
            }
        }
    }
}