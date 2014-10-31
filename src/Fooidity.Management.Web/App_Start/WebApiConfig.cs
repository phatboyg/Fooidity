namespace Fooidity.Management.Web
{
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;
    using Logging;


    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.SuppressDefaultHostAuthentication();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new
            {
                id = RouteParameter.Optional
            });

            config.Services.Add(typeof(IExceptionLogger), new UnhandledExceptionLogger());
        }
    }
}