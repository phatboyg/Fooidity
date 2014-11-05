namespace Fooidity.Client.Configuration
{
    public interface IClientConfigurator
    {
        void Host(string hostAddress);
        void ApplicationKey(string applicationKey);
    }
}