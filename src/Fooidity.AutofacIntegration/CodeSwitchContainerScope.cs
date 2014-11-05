namespace Fooidity
{
    using Autofac;


    public class CodeSwitchContainerScope :
        ICodeSwitchContainerScope
    {
        readonly ILifetimeScope _scope;

        public CodeSwitchContainerScope(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        public ICodeSwitchContainerScope CreateContainerScope()
        {
            return new CodeSwitchContainerScope(_scope.BeginLifetimeScope());
        }

        public ICodeSwitchContainerScope CreateContainerScope<TContext>(TContext context)
            where TContext : class
        {
            return new CodeSwitchContainerScope(_scope.BeginLifetimeScope(x =>
            {
                x.RegisterInstance(context);
            }));
        }

        public bool TryResolve<T>(out T instance)
            where T : class
        {
            return _scope.TryResolve(out instance);
        }
    }
}