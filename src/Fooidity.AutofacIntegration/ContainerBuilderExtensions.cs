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
        public static void RegisterDisabledByDefault(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DisabledFooId<>))
                   .As(typeof(FooId<>))
                   .SingleInstance();
        }

        /// <summary>
        /// Register all FooIds as enabled by default
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterEnabledByDefault(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EnabledFooId<>))
                   .As(typeof(FooId<>))
                   .SingleInstance();
        }

        /// <summary>
        /// Register the specified FooId as enabled in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void RegisterEnabled<TFoo>(this ContainerBuilder builder)
            where TFoo : struct, FooId
        {
            builder.RegisterType<EnabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();
        }

        /// <summary>
        /// Register the specified FooId as disabled in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void RegisterDisabled<TFoo>(this ContainerBuilder builder)
            where TFoo : struct, FooId
        {
            builder.RegisterType<DisabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();
        }

        /// <summary>
        /// Enable the FooId in the container
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <param name="container">The container to update</param>
        public static void Enable<TFoo>(this IContainer container)
            where TFoo : struct, FooId
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
            where TFoo : struct, FooId
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DisabledFooId<TFoo>>()
                   .As<FooId<TFoo>>()
                   .SingleInstance();

            builder.Update(container);
        }

        public static void RegisterFooId<TFoo>(this ContainerBuilder builder, Func<FooId<TFoo>> fooIdFactory)
            where TFoo : struct, FooId
        {
            builder.Register(context => fooIdFactory())
                   .As<FooId<TFoo>>();
        }

        public static void RegisterFooId<TFoo>(this ContainerBuilder builder,
            Func<IComponentContext, FooId<TFoo>> fooIdFactory)
            where TFoo : struct, FooId
        {
            builder.Register(context => fooIdFactory(context))
                   .As<FooId<TFoo>>();
        }

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterByFooId<TFoo, T>(
            this ContainerBuilder builder,
            Func<IComponentContext, T> enabledFactory, Func<IComponentContext, T> disabledFactory)
            where TFoo : struct, FooId
        {
            return builder.Register(context =>
                {
                    var fooId = context.Resolve<FooId<TFoo>>();
                    return fooId.Enabled
                               ? enabledFactory(context)
                               : disabledFactory(context);
                });
        }

        /// <summary>
        /// Register two types that are selectively resolved depending upon the state of the FooId
        /// </summary>
        /// <typeparam name="TFoo">The FooId type</typeparam>
        /// <typeparam name="T">The registration type</typeparam>
        /// <typeparam name="TEnabled">The enabled type</typeparam>
        /// <typeparam name="TDisabled">The disable type</typeparam>
        /// <param name="builder">The container builder</param>
        /// <returns>The registration builder for the container, already configured for the specified types</returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterByFooId
            <TFoo, T, TEnabled, TDisabled>(this ContainerBuilder builder)
            where TFoo : struct, FooId
            where TEnabled : T
            where TDisabled : T
            where T : class
        {
            builder.RegisterType<TEnabled>();
            builder.RegisterType<TDisabled>();

            IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> registerByFooId =
                builder.Register(context =>
                    {
                        var fooId = context.Resolve<FooId<TFoo>>();
                        return fooId.Enabled ? (T)context.Resolve<TEnabled>() : (T)context.Resolve<TDisabled>();
                    }).As<T>();

            return registerByFooId;
        }
    }
}