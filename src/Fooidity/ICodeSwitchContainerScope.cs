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
        /// Create a nested container scope
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        ICodeSwitchContainerScope CreateContainerScope<TContext>(TContext context);

        /// <summary>
        /// Try to resolve an object of the specified type, returning that instance if available
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool TryResolve<T>(out T instance);
    }
}