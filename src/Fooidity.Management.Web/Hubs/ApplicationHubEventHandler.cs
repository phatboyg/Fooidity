namespace Fooidity.Management.Web.Hubs
{
    using System.Threading.Tasks;
    using Contracts;
    using Fooidity.Contracts;
    using Microsoft.AspNet.SignalR;

    /// <summary>
    /// Handles events related to applications and publishes them to connections on the application hub
    /// </summary>
    public class ApplicationHubEventHandler :
        IEventHandler<IApplicationCodeFeatureStateUpdated>
    {
        public async Task Handle(Task<IApplicationCodeFeatureStateUpdated> eventTask)
        {
            IApplicationCodeFeatureStateUpdated updated = await eventTask;

            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ApplicationHub>();

            var clientEvent = new CodeFeatureStateUpdated(updated.CodeFeatureId, updated.Enabled, updated.EventId, updated.Timestamp,
                updated.CommandId);

            await context.Clients.Group(updated.ApplicationId).notifyCodeFeatureStateUpdated(clientEvent);
//
//            await context.Clients.All.notifyCodeFeatureStateUpdated(clientEvent);
        }
    }
}