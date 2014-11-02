namespace Fooidity.Management.Web
{
    using Owin;
    using Owin.Security.Providers.GitHub;


    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
//            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
//                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
//                {
//                    Audience = audience,
//                    Tenant = tenant,
//                });

//            app.UseGitHubAuthentication("", "");
        }
    }
}