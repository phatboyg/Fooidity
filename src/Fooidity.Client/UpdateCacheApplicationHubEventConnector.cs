namespace Fooidity.Client
{
    using System;
    using System.Collections.Generic;
    using Caching;
    using Contracts;
    using Microsoft.AspNet.SignalR.Client;


    public class UpdateCacheApplicationHubEventConnector :
        IApplicationHubEventConnector
    {
        readonly ICodeSwitchContainerScope _containerScope;

        public UpdateCacheApplicationHubEventConnector(ICodeSwitchContainerScope containerScope)
        {
            _containerScope = containerScope;
        }

        public IEnumerable<IDisposable> Connect(IHubProxy hubProxy)
        {
            yield return hubProxy.On<CodeFeatureStateUpdated>("notifyCodeFeatureStateUpdated", OnUpdated);

            yield return hubProxy.On<ContextCodeFeatureStateUpdated>("notifyContextCodeFeatureStateUpdated", OnUpdated);
        }

        void OnUpdated(IContextCodeFeatureStateUpdated message)
        {
            IEnumerable<IUpdateContextFeatureCache> contextCaches;
            if (_containerScope.TryResolve(out contextCaches))
            {
                IUpdateContextCodeFeature update = new UpdateContextCodeFeature(message.ContextId, message.ContextKey,
                    new CodeFeatureId(message.CodeFeatureId), message.Enabled,
                    message.Timestamp, message.CommandId ?? Guid.NewGuid());

                foreach (IUpdateContextFeatureCache contextCache in contextCaches)
                    contextCache.UpdateCache(update);
            }
        }

        void OnUpdated(ICodeFeatureStateUpdated message)
        {
            IUpdateCodeFeatureCache codeCache;
            if (_containerScope.TryResolve(out codeCache))
            {
                IUpdateCodeFeature update = new UpdateCodeFeature(new CodeFeatureId(message.CodeFeatureId), message.Enabled,
                    message.Timestamp, message.CommandId ?? Guid.NewGuid());

                codeCache.UpdateCache(update);
            }
        }
    }
}