namespace Fooidity.Security
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledForAuthenticatedIdentity<TFoo> :
        CodeSwitch<TFoo>
        where TFoo : struct, CodeFeature
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