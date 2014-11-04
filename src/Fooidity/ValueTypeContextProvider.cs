namespace Fooidity
{
    using System;

    /// <summary>
    /// Supports resolving value type contexts from an input type via a simple delegate access method
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class ValueTypeContextProvider<TInput, TContext> :
        IContextProvider<TInput, TContext>
        where TContext : struct
    {
        readonly Func<TInput, TContext?> _selector;

        public ValueTypeContextProvider(Func<TInput, TContext?> selector)
        {
            _selector = selector;
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
            TContext? switchContext = _selector(input);
            if (switchContext.HasValue)
            {
                context = switchContext.Value;
                return true;
            }

            context = default(TContext);
            return false;
        }
    }
}