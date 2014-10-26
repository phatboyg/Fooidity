namespace Fooidity.Security
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledByRoleInThreadPrincipal<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
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