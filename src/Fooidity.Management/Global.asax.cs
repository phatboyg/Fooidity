namespace Fooidity.Management
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;


    public class WebApiApplication :
        HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(WebAppContainer.Container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(WebAppContainer.Container));
        }

        protected void Application_End()
        {
            WebAppContainer.Container.Dispose();
        }
    }
}