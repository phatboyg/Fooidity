namespace Fooidity.Management.Web.Hubs
{
    using System;
    using System.Threading.Tasks;
    using Commands;
    using Contracts;
    using Management.Models;
    using Microsoft.AspNet.SignalR;
    using Queries;


    public class ApplicationHub :
        Hub
    {
        static readonly ConnectionIdAppKeyDictionary _appKeys = new ConnectionIdAppKeyDictionary();
        readonly IQueryHandler<GetApplicationKey, OrganizationApplicationKey> _getApplicationKey;
        readonly ICommandHandler<RegisterCodeFeature> _registerCodeFeature;

        public ApplicationHub(IQueryHandler<GetApplicationKey, OrganizationApplicationKey> getApplicationKey,
            ICommandHandler<RegisterCodeFeature> registerCodeFeature)
        {
            _getApplicationKey = getApplicationKey;
            _registerCodeFeature = registerCodeFeature;
        }

        public override async Task OnConnected()
        {
            string appKey = Context.QueryString["appkey"];
            if (string.IsNullOrWhiteSpace(appKey))
                Clients.Caller.notifyMissingAppKey();

            OrganizationApplicationKey application = await _getApplicationKey.Execute(new GetApplicationKeyQuery(appKey));

            _appKeys.TryAdd(Context.ConnectionId, application);

            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            OrganizationApplicationKey application;
            if (_appKeys.TryRemove(Context.ConnectionId, out application))
            {
            }

            await base.OnDisconnected(stopCalled);
        }

        public async Task OnCodeSwitchEvaluated(CodeSwitchEvaluated message)
        {
            OrganizationApplicationKey application;
            if (_appKeys.TryGetAppKey(Context.ConnectionId, out application))
                await _registerCodeFeature.Execute(new RegisterCodeFeatureCommand(application.ApplicationId, message.CodeFeatureId));
        }


        class GetApplicationKeyQuery :
            GetApplicationKey
        {
            readonly string _key;

            public GetApplicationKeyQuery(string key)
            {
                _key = key;
            }

            public string Key
            {
                get { return _key; }
            }
        }


        class RegisterCodeFeatureCommand :
            RegisterCodeFeature
        {
            string _applicationId;
            string _codeFeatureId;

            public RegisterCodeFeatureCommand(string applicationId, Uri codeFeatureId)
            {
                _applicationId = applicationId;
                _codeFeatureId = codeFeatureId.ToString();
            }

            public string ApplicationId
            {
                get { return _applicationId; }
            }

            public string CodeFeatureId
            {
                get { return _codeFeatureId; }
            }
        }
    }
}