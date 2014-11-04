namespace Fooidity
{
    using System;


    /// <summary>
    /// Supports returning a context (TContext) from an input (message, model, etc)
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IContextProvider<TContext>
    {
        Type InputType { get; }

        bool TryGetContext<T>(T input, out TContext context);
    }


    /// <summary>
    /// Supports return a context for the given input type
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public interface IContextProvider<in TInput, TContext> :
        IContextProvider<TContext>
    {
        bool TryGetContext(TInput input, out TContext context);
    }
}