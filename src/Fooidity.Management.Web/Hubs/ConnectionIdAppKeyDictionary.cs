namespace Fooidity.Management.Web.Hubs
{
    using System.Collections.Concurrent;
    using Management.Models;


    public class ConnectionIdAppKeyDictionary
    {
        readonly ConcurrentDictionary<string, OrganizationApplicationKey> _ids;

        public ConnectionIdAppKeyDictionary()
        {
            _ids = new ConcurrentDictionary<string, OrganizationApplicationKey>();
        }

        public bool TryGetAppKey(string connectionId, out OrganizationApplicationKey appKey)
        {
            if (_ids.TryGetValue(connectionId, out appKey))
                return true;

            return false;
        }

        public bool TryAdd(string connectionId, OrganizationApplicationKey appKey)
        {
            if (_ids.TryAdd(connectionId, appKey))
                return true;

            return false;
        }

        public bool TryRemove(string connectionId, out OrganizationApplicationKey application)
        {
            return _ids.TryRemove(connectionId, out application);
        }
    }
}