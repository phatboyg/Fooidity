namespace Fooidity
{
    using System;
    using Autofac;
    using Autofac.Builder;


    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Register a factory method that is switched by the specified code feature
        /// </summary>
        /// <typeparam name="TFeature">The code feature</typeparam>
        /// <typeparam name="T">The service type</typeparam>
        /// <param name="builder">The container builder</param>
        /// <param name="enabledFactory">Factory to use when switch is enabled</param>
        /// <param name="disabledFactory">Factory to use when switch is disabled</param>
        /// <returns></returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterSwitched<TFeature, T>(
            this ContainerBuilder builder, Func<IComponentContext, T> enabledFactory, Func<IComponentContext, T> disabledFactory)
            where TFeature : struct, ICodeFeature
        {
            return builder.Register(context =>
            {
                var codeSwitch = context.Resolve<ICodeSwitch<TFeature>>();
                return codeSwitch.Enabled
                    ? enabledFactory(context)
                    : disabledFactory(context);
            }).As<T>();
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
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterSwitchedType
            <TFeature, T, TEnabled, TDisabled>(this ContainerBuilder builder)
            where TFeature : struct, ICodeFeature
            where T : class
            where TEnabled : T
            where TDisabled : T
        {
            builder.RegisterType<TEnabled>();
            builder.RegisterType<TDisabled>();

            return builder.Register(context =>
            {
                var codeSwitch = context.Resolve<ICodeSwitch<TFeature>>();

                return codeSwitch.Enabled ? (T)context.Resolve<TEnabled>() : (T)context.Resolve<TDisabled>();
            }).As<T>();
        }
    }
}