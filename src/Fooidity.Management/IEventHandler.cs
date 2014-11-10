namespace Fooidity.Management
{
    using System.Threading.Tasks;

    /// <summary>
    /// Event handlers handle a specific input event type and are dependencies of classes
    /// that produce events
    /// </summary>
    /// <typeparam name="T">The event type</typeparam>
    public interface IEventHandler<T>
    {
        Task Handle(Task<T> eventTask);
    }
}