namespace Fooidity
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledByRoleInThreadPrincipal<TFoo> :
        FooId<TFoo>
        where TFoo : struct, FooId
    {
        readonly string _role;

        public EnabledByRoleInThreadPrincipal(string role)
        {
            _role = role;
        }

        public bool Enabled
        {
            get
            {
                IPrincipal principal = Thread.CurrentPrincipal;
                if (principal == null)
                    return false;

                return principal.IsInRole(_role);
            }
        }
    }
}