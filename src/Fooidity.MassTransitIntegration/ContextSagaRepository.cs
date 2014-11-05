namespace Fooidity.MassTransitIntegration
{
    using System;
    using System.Collections.Generic;
    using MassTransit;
    using MassTransit.Pipeline;
    using MassTransit.Saga;


    public class ContextSagaRepository<TSaga, TContext> :
        ISagaRepository<TSaga>
        where TSaga : class, ISaga
    {
        readonly ISagaRepository<TSaga> _repository;
        readonly ICodeSwitchContainerScope _scope;

        public ContextSagaRepository(ICodeSwitchContainerScope scope, ISagaRepository<TSaga> repository)
        {
            _scope = scope;
            _repository = repository;
        }

        public IEnumerable<Action<IConsumeContext<TMessage>>> GetSaga<TMessage>(IConsumeContext<TMessage> context, Guid sagaId,
            InstanceHandlerSelector<TSaga, TMessage> selector, ISagaPolicy<TSaga, TMessage> policy) where TMessage : class
        {
            using (CreateContainerScope(context))
            {
                foreach (var handler in _repository.GetSaga(context, sagaId, selector, policy))
                    yield return handler;
            }
        }

        public IEnumerable<Guid> Find(ISagaFilter<TSaga> filter)
        {
            return _repository.Find(filter);
        }

        public IEnumerable<TSaga> Where(ISagaFilter<TSaga> filter)
        {
            return _repository.Where(filter);
        }

        public IEnumerable<TResult> Where<TResult>(ISagaFilter<TSaga> filter, Func<TSaga, TResult> transformer)
        {
            return _repository.Where(filter, transformer);
        }

        public IEnumerable<TResult> Select<TResult>(Func<TSaga, TResult> transformer)
        {
            return _repository.Select(transformer);
        }

        ICodeSwitchContainerScope CreateContainerScope<TMessage>(IConsumeContext<TMessage> context)
            where TMessage : class
        {
            IContextProvider<TMessage, TContext> provider;
            if (_scope.TryResolve(out provider))
            {
                TContext switchContext;
                if (provider.TryGetContext(context.Message, out switchContext))
                    return _scope.CreateContainerScope(switchContext);
            }

            return _scope.CreateContainerScope();
        }
    }
}