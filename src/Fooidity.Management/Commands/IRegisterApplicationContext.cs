namespace Fooidity.Management.Commands
{
    public interface IRegisterApplicationContext
    {
        string ApplicationId { get; }

        string ContextId { get; }
    }
}