namespace Fooidity
{
    using System;


    /// <summary>
    /// Supports returning a context (TContext) from an input (message, model, etc)
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface ContextProvider<TContext>
    {
        Type InputType { get; }

        bool TryGetContext<T>(T input, out TContext context);
    }


    /// <summary>
    /// Supports return a context for the given input type
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public interface ContextProvider<in TInput, TContext> :
        ContextProvider<TContext>
    {
        bool TryGetContext(TInput input, out TContext context);
    }
}