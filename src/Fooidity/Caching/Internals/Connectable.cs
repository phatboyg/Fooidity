namespace Fooidity.Caching.Internals
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;


    class Connectable<T>
    {
        readonly ConcurrentDictionary<long, T> _connections;
        long _nextId;

        public Connectable()
        {
            _connections = new ConcurrentDictionary<long, T>();
        }

        /// <summary>
        /// The number of connections
        /// </summary>
        public int Count
        {
            get { return _connections.Count; }
        }

        /// <summary>
        /// Connect a connectable type
        /// </summary>
        /// <param name="connection">The connection to add</param>
        /// <returns>The connection handle</returns>
        public ConnectionHandle Connect(T connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            long id = Interlocked.Increment(ref _nextId);

            bool added = _connections.TryAdd(id, connection);
            if (!added)
                throw new InvalidOperationException("The connection could not be added");

            return new Handle(id, Disconnect);
        }

        /// <summary>
        /// Enumerate the connections invoking the callback for each connection
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <returns>An awaitable Task for the operation</returns>
        public async Task ForEach(Func<T, Task> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            if (_connections.Count == 0)
                return;

            var exceptions = new List<Exception>();

            foreach (T connection in _connections.Values)
            {
                try
                {
                    await callback(connection);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }

        /// <summary>
        /// Synchronously enumerate the cache and invoke the callback for each item
        /// </summary>
        /// <param name="callback"></param>
        public void ForEach(Action<T> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            if (_connections.Count == 0)
                return;

            var exceptions = new List<Exception>();

            foreach (T connection in _connections.Values)
            {
                try
                {
                    callback(connection);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }


        public bool All(Func<T, bool> callback)
        {
            return _connections.Values.All(callback);
        }

        void Disconnect(long id)
        {
            T ignored;
            _connections.TryRemove(id, out ignored);
        }


        class Handle :
            ConnectionHandle
        {
            readonly Action<long> _disconnect;
            readonly long _id;

            public Handle(long id, Action<long> disconnect)
            {
                _id = id;
                _disconnect = disconnect;
            }

            public void Disconnect()
            {
                _disconnect(_id);
            }

            public void Dispose()
            {
                Disconnect();
            }
        }
    }
}