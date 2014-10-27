namespace Fooidity
{
    using System;
    using Autofac;
    using Autofac.Builder;
    using Autofac.Core;
    using CodeSwitches;
    using Events;


    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// By default, all code switches that are not explicitly registered will use a default implementation
        /// that is disabled.
        /// </summary>
        /// <param name="builder"></param>
        public static void DisableCodeSwitchesByDefault(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DisabledCodeSwitch<>))
                .As(typeof(CodeSwitch<>))
                .SingleInstance();
        }

        /// <summary>
        /// By default, all code switches that are not explicitly registered will use a default implementation
        /// that is enabled.
        /// </summary>
        /// <param name="builder"></param>
        public static void EnableCodeSwitchesByDefault(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EnabledCodeSwitch<>))
                .As(typeof(CodeSwitch<>))
                .SingleInstance();
        }

        /// <summary>
        /// Register the specified CodeSwitch as enabled in the container
        /// </summary>
        /// <typeparam name="TFeature">The CodeSwitch type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void RegisterEnabled<TFeature>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.RegisterType<EnabledCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register the specified CodeSwitch as disabled in the container
        /// </summary>
        /// <typeparam name="TFeature">The CodeSwitch type</typeparam>
        /// <param name="builder">The container builder to register</param>
        public static void RegisterDisabled<TFeature>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.RegisterType<DisabledCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .SingleInstance();
        }

        public static void RegisterToggle<TFeature>(this ContainerBuilder builder, bool enabled = false)
            where TFeature : struct, CodeFeature
        {
            builder.RegisterType<ToggleCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .As<IToggleCodeSwitch<TFeature>>()
                .SingleInstance();
        }

        /// <summary>
        /// Enable the CodeSwitch in the container
        /// </summary>
        /// <typeparam name="TFeature">The CodeSwitch type</typeparam>
        /// <param name="container">The container to update</param>
        public static void Enable<TFeature>(this IContainer container)
            where TFeature : struct, CodeFeature
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EnabledCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .SingleInstance();

            builder.Update(container);
        }

        /// <summary>
        /// Disable the CodeSwitch in the container
        /// </summary>
        /// <typeparam name="TFeature">The CodeSwitch type</typeparam>
        /// <param name="container">The container to update</param>
        public static void Disable<TFeature>(this IContainer container)
            where TFeature : struct, CodeFeature
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DisabledCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .SingleInstance();

            builder.Update(container);
        }

        public static void RegisterFooId<TFeature>(this ContainerBuilder builder,
            Func<CodeSwitch<TFeature>> fooIdFactory)
            where TFeature : struct, CodeFeature
        {
            builder.Register(context => fooIdFactory())
                .As<CodeSwitch<TFeature>>();
        }


        public static void RegisterFooId<TFeature>(this ContainerBuilder builder,
            Func<IComponentContext, CodeSwitch<TFeature>> fooIdFactory)
            where TFeature : struct, CodeFeature
        {
            builder.Register(context => fooIdFactory(context))
                .As<CodeSwitch<TFeature>>();
        }

        public static void EnableCodeSwitchTracker(this ContainerBuilder builder)
        {
            builder.RegisterType<CodeSwitchStateTracker>()
                .InstancePerLifetimeScope();
        }

        public static void RegisterCodeSwitch<TFeature>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.RegisterType<CodeFeatureStateCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .OnActivated(x => OnCodeSwitchActivation(x.Context, x.Instance));
        }

        public static void RegisterContextSwitch<TFeature, TContext>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.Register(context =>
            {
                TContext switchContext;
                if (!context.TryResolve(out switchContext))
                    throw new ArgumentException("The context type was not found: " + typeof(TContext).Name);

                var cache = context.Resolve<ICodeFeatureStateCache>();
                var contextCache = context.Resolve<IContextFeatureStateCache<TContext>>();

                return new ContextFeatureStateCodeSwitch<TFeature, TContext>(cache, contextCache, switchContext);
            })
                .As<CodeSwitch<TFeature>>()
                .OnActivated(x => OnCodeSwitchActivation(x.Context, x.Instance));
        }

        static void OnCodeSwitchActivation(IComponentContext context, IObservable<CodeSwitchEvaluated> observable)
        {
            CodeSwitchStateTracker tracker;
            if (context.TryResolve(out tracker))
                observable.Subscribe(tracker);
        }

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterByFooId<TFeature, T>
            (
            this ContainerBuilder builder,
            Func<IComponentContext, T> enabledFactory, Func<IComponentContext, T> disabledFactory)
            where TFeature : struct, CodeFeature
        {
            return builder.Register(context =>
            {
                var codeSwitch = context.Resolve<CodeSwitch<TFeature>>();
                return codeSwitch.Enabled
                    ? enabledFactory(context)
                    : disabledFactory(context);
            });
        }

        /// <summary>
        /// Register two types that are selectively resolved depending upon the state of the CodeSwitch
        /// </summary>
        /// <typeparam name="TFeature">The CodeSwitch type</typeparam>
        /// <typeparam name="T">The registration type</typeparam>
        /// <typeparam name="TEnabled">The enabled type</typeparam>
        /// <typeparam name="TDisabled">The disable type</typeparam>
        /// <param name="builder">The container builder</param>
        /// <returns>The registration builder for the container, already configured for the specified types</returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterByFooId
            <TFeature, T, TEnabled, TDisabled>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
            where TEnabled : T
            where TDisabled : T
            where T : class
        {
            builder.RegisterType<TEnabled>();
            builder.RegisterType<TDisabled>();

            IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> registerByFooId =
                builder.Register(context =>
                {
                    var codeSwitch = context.Resolve<CodeSwitch<TFeature>>();
                    return codeSwitch.Enabled ? (T)context.Resolve<TEnabled>() : (T)context.Resolve<TDisabled>();
                }).As<T>();

            return registerByFooId;
        }
    }
}