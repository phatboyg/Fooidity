namespace Fooidity
{
    using System;


    /// <summary>
    /// Returns a default context for the given input type. Should be registered in the container
    /// as the default generic implementation.
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class DefaultContextProvider<TInput, TContext> :
        ContextProvider<TInput, TContext>
    {
        Type ContextProvider<TContext>.InputType
        {
            get { return typeof(TInput); }
        }

        bool ContextProvider<TContext>.TryGetContext<T>(T input, out TContext context)
        {
            context = default(TContext);
            return false;
        }

        bool ContextProvider<TInput, TContext>.TryGetContext(TInput input, out TContext context)
        {
            context = default(TContext);
            return false;
        }
    }
}