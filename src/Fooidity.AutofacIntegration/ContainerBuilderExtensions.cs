namespace Fooidity
{
    using System;
    using Autofac;
    using Autofac.Builder;


    public static class ContainerBuilderExtensions
    {
        public static void RegisterEnabled<TFoo>(this ContainerBuilder builder)
            where TFoo : FooId
        {
            RegisterFooId(builder, context => FooIds.Enabled<TFoo>());
        }

        public static void RegisterDisabled<TFoo>(this ContainerBuilder builder)
            where TFoo : FooId
        {
            RegisterFooId(builder, context => FooIds.Disabled<TFoo>());
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