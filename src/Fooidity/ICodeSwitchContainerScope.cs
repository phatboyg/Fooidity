namespace Fooidity
{
    using System;


    /// <summary>
    /// To switch by context, a container scope needs to be created and then used
    /// to resolve an instance of the consumer.
    /// </summary>
    public interface ICodeSwitchContainerScope :
        IDisposable
    {
        /// <summary>
        /// Create a nested container scope without a resolved context
        /// </summary>
        /// <returns></returns>
        ICodeSwitchContainerScope CreateContainerScope();

        /// <summary>
        /// Create a nested container scope
        /// </summary>
        /// <typeparam name="TContext">The context type</typeparam>
        /// <param name="context">The context to add to the container</param>
        /// <returns></returns>
        ICodeSwitchContainerScope CreateContainerScope<TContext>(TContext context)
            where TContext : class;

        /// <summary>
        /// Try to resolve an object of the specified type, returning that instance if available
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool TryResolve<T>(out T instance)
            where T : class;
    }
}