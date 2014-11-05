namespace Fooidity.Management.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
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
        readonly IQueryHandler<GetApplicationKey, OrganizationApplicationKey> _getApplicationKey;
        readonly IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> _listApplicationCodeFeatures;
        readonly ICommandHandler<RegisterCodeFeature> _registerCodeFeature;

        public ApplicationHub(IQueryHandler<GetApplicationKey, OrganizationApplicationKey> getApplicationKey,
            ICommandHandler<RegisterCodeFeature> registerCodeFeature,
            IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> listApplicationCodeFeatures)
        {
            _getApplicationKey = getApplicationKey;
            _registerCodeFeature = registerCodeFeature;
            _listApplicationCodeFeatures = listApplicationCodeFeatures;
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
                OrganizationApplicationKey application = await _getApplicationKey.Execute(new GetApplicationKeyQuery(appKey));

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
            OrganizationApplicationKey application;
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
            OrganizationApplicationKey application;
            if (_appKeys.TryRemove(Context.ConnectionId, out application))
            {
                Groups.Remove(Context.ConnectionId, application.ApplicationId);
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