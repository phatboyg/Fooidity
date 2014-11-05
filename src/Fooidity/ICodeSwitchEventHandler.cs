namespace Fooidity
{
    using System.Threading.Tasks;
    using Contracts;


    public interface ICodeSwitchEventHandler
    {
        Task Handle(ICodeSwitchEvaluated message);
    }
}