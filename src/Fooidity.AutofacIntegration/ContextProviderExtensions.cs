namespace Fooidity.AutofacIntegration
{
    using System;
    using Autofac;


    public static class ContextProviderExtensions
    {
        /// <summary>
        /// Register a default context provider that returns false for any attempts to 
        /// access the context type.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterDefaultContextProvider(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DefaultContextProvider<,>))
                .As(typeof(IContextProvider<,>));
        }

        /// <summary>
        /// Register a context provider for the specified input type and context type
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="builder"></param>
        /// <param name="selector"></param>
        public static void RegisterContextProvider<TInput, TContext>(this ContainerBuilder builder, Func<TInput, TContext?> selector)
            where TContext : struct
        {
            builder.Register(context => new ValueTypeContextProvider<TInput, TContext>(selector))
                .As<IContextProvider<TInput, TContext>>();
        }

        /// <summary>
        /// Register a context provider for the specified input type and context type
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="builder"></param>
        /// <param name="selector"></param>
        public static void RegisterContextProvider<TInput, TContext>(this ContainerBuilder builder, Func<TInput, TContext> selector)
            where TContext : class
        {
            builder.Register(context => new ObjectContextProvider<TInput, TContext>(selector))
                .As<IContextProvider<TInput, TContext>>();
        }
    }
}