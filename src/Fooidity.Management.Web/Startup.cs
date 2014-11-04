namespace Fooidity.Management.Web
{
    using Autofac;
    using Hubs;
    using Microsoft.AspNet.SignalR;
    using Owin;


    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalHost.DependencyResolver.Register(typeof(ApplicationHub), () => WebAppContainer.Container.Resolve<ApplicationHub>());

            app.MapSignalR();
        }
    }
}