namespace Fooidity.Management.Web.Hubs
{
    using System.Collections.Concurrent;
    using Management.Models;


    public class ConnectionIdAppKeyDictionary
    {
        readonly ConcurrentDictionary<string, IOrganizationApplicationKey> _ids;

        public ConnectionIdAppKeyDictionary()
        {
            _ids = new ConcurrentDictionary<string, IOrganizationApplicationKey>();
        }

        public bool TryGetAppKey(string connectionId, out IOrganizationApplicationKey appKey)
        {
            if (_ids.TryGetValue(connectionId, out appKey))
                return true;

            return false;
        }

        public bool TryAdd(string connectionId, IOrganizationApplicationKey appKey)
        {
            if (_ids.TryAdd(connectionId, appKey))
                return true;

            return false;
        }

        public bool TryRemove(string connectionId, out IOrganizationApplicationKey application)
        {
            return _ids.TryRemove(connectionId, out application);
        }
    }
}