namespace Fooidity.Client.Configuration
{
    public class ClientSettings :
        IClientSettings
    {
        public string HostAddress { get; set; }
        public string ApplicationKey { get; set; }
    }
}