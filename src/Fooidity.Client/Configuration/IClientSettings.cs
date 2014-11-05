namespace Fooidity.Client.Configuration
{
    public interface IClientSettings
    {
        string HostAddress { get; }
        string ApplicationKey { get; }
    }
}