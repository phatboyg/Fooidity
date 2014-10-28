namespace Fooidity
{
    using System;
    using System.Collections.Generic;
    using Autofac;
    using CodeSwitches;
    using Events;


    public static class CodeSwitchRegistrationExtensions
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
                .OnActivating(x => OnCodeSwitchActivation(x.Context, (IObservable<CodeSwitchEvaluated>)x.Instance));
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
                .OnActivating(x => OnCodeSwitchActivation(x.Context, (IObservable<CodeSwitchEvaluated>)x.Instance));
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
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance));
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
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance));
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
                .OnActivated(x => OnCodeSwitchActivation(x.Context, x.Instance))
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
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance))
                .SingleInstance();

            builder.Update(container);
        }

        /// <summary>
        /// Registers a toggle switch with a shared toggle state 
        /// </summary>
        /// <typeparam name="TFeature">The code feature</typeparam>
        /// <param name="builder">The container builder</param>
        /// <param name="enabled">True if the toggle should be enabled initially</param>
        public static void RegisterToggle<TFeature>(this ContainerBuilder builder, bool enabled = false)
            where TFeature : struct, CodeFeature
        {
            builder.Register(context => new ToggleSwitchState<TFeature>(enabled))
                .As<IToggleSwitchState<TFeature>>()
                .SingleInstance();

            builder.RegisterType<ToggleCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .As<IToggleCodeSwitch<TFeature>>()
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance));
        }

        public static void RegisterCodeSwitch<TFeature>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.RegisterType<CodeFeatureStateCodeSwitch<TFeature>>()
                .As<CodeSwitch<TFeature>>()
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance));
        }

        /// <summary>
        /// Register a context switch for the feature that uses the context to determine if the switch
        /// is enabled for that particular context.
        /// </summary>
        /// <typeparam name="TFeature">The code feature</typeparam>
        /// <typeparam name="TContext">The switch context</typeparam>
        /// <param name="builder"></param>
        public static void RegisterContextSwitch<TFeature, TContext>(this ContainerBuilder builder)
            where TFeature : struct, CodeFeature
        {
            builder.Register(context =>
            {
                // this gives a cleaner error message than a container exception
                TContext switchContext;
                if (!context.TryResolve(out switchContext))
                    throw new ContextSwitchException("The context type was not found: " + typeof(TContext).Name);

                var cache = context.Resolve<ICodeFeatureStateCache>();
                var contextCache = context.Resolve<IContextFeatureStateCache<TContext>>();

                return new ContextFeatureStateCodeSwitch<TFeature, TContext>(cache, contextCache, switchContext);
            })
                .As<CodeSwitch<TFeature>>()
                .OnActivating(x => OnCodeSwitchActivation(x.Context, x.Instance));
        }

        static void OnCodeSwitchActivation(IComponentContext context, IObservable<CodeSwitchEvaluated> observable)
        {
            IEnumerable<IObserver<CodeSwitchEvaluated>> observers;
            if (context.TryResolve(out observers))
            {
                foreach (var observer in observers)
                    observable.Subscribe(observer);
            }
        }
    }
}