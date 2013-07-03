namespace Fooidity
{
    using System;
    using Autofac;
    using Autofac.Builder;


    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register all FooIds as disabled by default
        /// </summary>
        /// <param name="builder"></param>
        public static void FooIdsDisabledByDefault(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DisabledFooId<>))
                   .As(typeof(FooId<>));
        }

        /// <summary>
        /// Register the specified FooId as enabled in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void Enabled<TFoo>(this ContainerBuilder builder)
            where TFoo : FooId
        {
            builder.RegisterType<EnabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();
        }

        /// <summary>
        /// Enable the FooId in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="container">The container to update</param>
        public static void Enable<TFoo>(this IContainer container)
            where TFoo : FooId
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EnabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();

            builder.Update(container);
        }

        /// <summary>
        /// Disable the FooId in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="container">The container to update</param>
        public static void Disable<TFoo>(this IContainer container)
            where TFoo : FooId
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DisabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();

            builder.Update(container);
        }

        /// <summary>
        /// Register the specified FooId as disabled in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void Disabled<TFoo>(this ContainerBuilder builder)
            where TFoo : FooId
        {
            builder.RegisterType<DisabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();
        }

        public static void RegisterFooId<TFoo>(this ContainerBuilder builder, Func<FooId<TFoo>> fooIdFactory)
            where TFoo : FooId
        {
            builder.Register(context => fooIdFactory())
                   .As<FooId<TFoo>>();
        }

        public static void RegisterFooId<TFoo>(this ContainerBuilder builder,
            Func<IComponentContext, FooId<TFoo>> fooIdFactory)
            where TFoo : FooId
        {
            builder.Register(context => fooIdFactory(context))
                   .As<FooId<TFoo>>();
        }

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterByFooId<TFoo, T>(
            this ContainerBuilder builder,
            Func<IComponentContext, T> enabledFactory, Func<IComponentContext, T> disabledFactory)
            where TFoo : FooId
        {
            return builder.Register(context =>
                {
                    var fooId = context.Resolve<FooId<TFoo>>();
                    return fooId.Enabled
                               ? enabledFactory(context)
                               : disabledFactory(context);
                });
        }

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle>
            RegisterByFooId<TFoo, T, TEnabled, TDisabled>(this ContainerBuilder builder)
            where TFoo : FooId
            where TEnabled : T
            where TDisabled : T
            where T : class
        {
            builder.RegisterType<TEnabled>();
            builder.RegisterType<TDisabled>();

            return builder.Register(context =>
                {
                    var fooId = context.Resolve<FooId<TFoo>>();
                    return fooId.Enabled
                               ? context.Resolve<TEnabled>() as T
                               : context.Resolve<TDisabled>() as T;
                }).As<T>();
        }
    }
}