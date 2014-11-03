namespace Fooidity.Management
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface ICommandHandler<in T>
    {
        Task Execute(T command, CancellationToken cancellationToken = default(CancellationToken));
    }


    public interface ICommandHandler<in T, TResult>
    {
        Task<TResult> Execute(T command, CancellationToken cancellationToken = default(CancellationToken));
    }
}