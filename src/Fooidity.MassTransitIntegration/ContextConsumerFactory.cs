namespace Fooidity.MassTransitIntegration
{
    using System;
    using System.Collections.Generic;
    using Magnum.Extensions;
    using MassTransit;
    using MassTransit.Exceptions;
    using MassTransit.Pipeline;


    /// <summary>
    /// Resolves a consumer from the container, first obtaining the context from the message
    /// and adding it to the container to ensure any dependencies are resolved based on the 
    /// context in the message for specific enabled context instances.
    /// </summary>
    /// <typeparam name="TConsumer">The consumer type</typeparam>
    /// <typeparam name="TContext">The context type</typeparam>
    public class ContextConsumerFactory<TConsumer, TContext> :
        IConsumerFactory<TConsumer>
        where TConsumer : class
    {
        readonly ICodeSwitchContainerScope _scope;

        public ContextConsumerFactory(ICodeSwitchContainerScope scope)
        {
            _scope = scope;
        }

        IEnumerable<Action<IConsumeContext<TMessage>>> IConsumerFactory<TConsumer>.GetConsumer<TMessage>(IConsumeContext<TMessage> context,
            InstanceHandlerSelector<TConsumer, TMessage> selector)
        {
            TContext switchContext = default(TContext);

            ContextProvider<TMessage, TContext> provider;
            if (_scope.TryResolve(out provider))
            {
                if (!provider.TryGetContext(context.Message, out switchContext))
                    throw new ContextSwitchException("Failed to retrieve context from message: " + typeof(TMessage).ToShortTypeName());
            }

            using (ICodeSwitchContainerScope innerScope = _scope.CreateContainerScope(switchContext))
            {
                TConsumer consumer;
                if (!innerScope.TryResolve(out consumer))
                {
                    throw new ConfigurationException(string.Format("Unable to resolve type '{0}' from container: ",
                        typeof(TConsumer)));
                }

                foreach (var handler in selector(consumer, context))
                    yield return handler;
            }
        }
    }
}