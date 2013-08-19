namespace Fooidity
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledForAuthenticatedIdentity<TFoo> :
        FooId<TFoo>
        where TFoo : struct, FooId
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