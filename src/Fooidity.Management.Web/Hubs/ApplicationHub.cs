namespace Fooidity.Management.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AzureIntegration.Exceptions;
    using Commands;
    using Fooidity.Contracts;
    using Management.Models;
    using Microsoft.AspNet.SignalR;
    using Queries;


    public class ApplicationHub :
        Hub
    {
        static readonly ConnectionIdAppKeyDictionary _appKeys = new ConnectionIdAppKeyDictionary();
        readonly IQueryHandler<IGetApplicationByKey, IOrganizationApplicationKey> _getApplicationKey;
        readonly IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> _listApplicationCodeFeatures;
        readonly ICommandHandler<IRegisterApplicationContext> _registerApplicationContext;
        readonly ICommandHandler<IRegisterCodeFeature> _registerCodeFeature;

        public ApplicationHub(IQueryHandler<IGetApplicationByKey, IOrganizationApplicationKey> getApplicationKey,
            ICommandHandler<IRegisterCodeFeature> registerCodeFeature,
            IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> listApplicationCodeFeatures,
            ICommandHandler<IRegisterApplicationContext> registerApplicationContext)
        {
            _getApplicationKey = getApplicationKey;
            _registerCodeFeature = registerCodeFeature;
            _listApplicationCodeFeatures = listApplicationCodeFeatures;
            _registerApplicationContext = registerApplicationContext;
        }

        public override async Task OnConnected()
        {
            string appKey = Context.Request.Headers.Get(Headers.FooidityAppKey);
            if (string.IsNullOrWhiteSpace(appKey))
            {
                Clients.Caller.notifyMissingAppKey();
                return;
            }

            try
            {
                IOrganizationApplicationKey application = await _getApplicationKey.Execute(new GetApplicationByKey(appKey));

                await Groups.Add(Context.ConnectionId, application.ApplicationId);

                _appKeys.TryAdd(Context.ConnectionId, application);
            }
            catch (ApplicationNotFoundException)
            {
                Clients.Caller.notifyInvalidAppKey();
            }

            await base.OnConnected();
        }

        public async Task<IEnumerable<CodeFeatureState>> GetCodeFeatureStates()
        {
            IOrganizationApplicationKey application;
            if (_appKeys.TryGetAppKey(Context.ConnectionId, out application))
            {
                IEnumerable<ICodeFeatureState> codeFeatureStates =
                    await _listApplicationCodeFeatures.Execute(new ListApplicationCodeFeatures(null, application.ApplicationId));

                return codeFeatureStates.Cast<CodeFeatureState>().ToList();
            }

            throw new InvalidOperationException("Unknown application key");
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            IOrganizationApplicationKey application;
            if (_appKeys.TryRemove(Context.ConnectionId, out application))
                Groups.Remove(Context.ConnectionId, application.ApplicationId);

            await base.OnDisconnected(stopCalled);
        }

        public async Task OnCodeSwitchEvaluated(CodeSwitchEvaluated message)
        {
            IOrganizationApplicationKey application;
            if (_appKeys.TryGetAppKey(Context.ConnectionId, out application))
            {
                await _registerCodeFeature.Execute(new RegisterCodeFeature(application.ApplicationId, message.CodeFeatureId));

                if (message.ContextId != null)
                {
                    var registerApplicationContext = new RegisterApplicationContext(application.ApplicationId, message.ContextId.ToString());
                    await _registerApplicationContext.Execute(registerApplicationContext);
                }
            }
        }
    }
}