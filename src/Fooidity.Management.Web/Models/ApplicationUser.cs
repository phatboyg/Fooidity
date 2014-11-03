namespace Fooidity.Management.Web.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AzureIntegration.UserStore;
    using Microsoft.AspNet.Identity;


    public class ApplicationUser :
        UserEntity
    {
        public ApplicationUser()
        {
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}