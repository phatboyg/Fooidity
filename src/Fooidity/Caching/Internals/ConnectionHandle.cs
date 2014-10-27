namespace Fooidity.Caching.Internals
{
    using System;


    interface ConnectionHandle :
        IDisposable
    {
        void Disconnect();
    }
}