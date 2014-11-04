namespace Fooidity.Management
{
    using System.Threading.Tasks;


    public interface IEventHandler<T>
    {
        Task Handle(Task<T> eventTask);
    }
}