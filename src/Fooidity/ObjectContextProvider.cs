namespace Fooidity
{
    using System;

    /// <summary>
    /// Supports reading context from an input object using a simple delegate. It's prefered that a custom
    /// class similar to this one be created and registered in the container for the required context type.
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class ObjectContextProvider<TInput, TContext> :
        IContextProvider<TInput, TContext>
        where TContext : class
    {
        readonly Func<TInput, TContext> _provider;

        public ObjectContextProvider(Func<TInput, TContext> provider)
        {
            _provider = provider;
        }

        Type IContextProvider<TContext>.InputType
        {
            get { return typeof(TInput); }
        }

        bool IContextProvider<TContext>.TryGetContext<T>(T input, out TContext context)
        {
            var self = this as IContextProvider<TInput, TContext>;
            if (self == null)
                throw new ArgumentException("The input type is not supported: " + typeof(TInput).Name);

            return self.TryGetContext(input, out context);
        }

        bool IContextProvider<TInput, TContext>.TryGetContext(TInput input, out TContext context)
        {
            context = _provider(input);

            return context != null;
        }
    }
}