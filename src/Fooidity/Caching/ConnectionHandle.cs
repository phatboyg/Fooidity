namespace Fooidity.Caching
{
    using System;


    public interface ConnectionHandle :
        IDisposable
    {
        void Disconnect();
    }
}