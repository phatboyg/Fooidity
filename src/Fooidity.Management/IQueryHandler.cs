namespace Fooidity.Management
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IQueryHandler<in T, TResult>
    {
        Task<TResult> Execute(T query, CancellationToken cancellationToken = default(CancellationToken));
    }
}