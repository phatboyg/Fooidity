namespace Fooidity.CodeSwitches
{
    using System.Security.Principal;
    using System.Threading;


    public class EnabledThreadPrincipalInRoleCodeSwitch<TFeature> :
        CodeSwitch<TFeature>
        where TFeature : struct, CodeFeature
    {
        readonly string _role;

        public EnabledThreadPrincipalInRoleCodeSwitch(string role)
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