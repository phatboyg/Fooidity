namespace Fooidity.AutofacIntegration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Autofac;
    using Autofac.Core;
    using Autofac.Core.Lifetime;
    using Autofac.Core.Resolving;


    public class AutofacFooIdContainer<TFoo> :
        FooIdContainer<TFoo>
        where TFoo : struct, ICodeFeature
    {
        readonly Lazy<ILifetimeScope> _disabled;
        readonly Lazy<ILifetimeScope> _enabled;
        readonly ILifetimeScope _parent;
        Action<ContainerBuilder> _configureDisabled;
        Action<ContainerBuilder> _configureEnabled;
        bool _disposed;

        public AutofacFooIdContainer(ILifetimeScope parentScope)
        {
            _parent = parentScope;

            _enabled =
                new Lazy<ILifetimeScope>(
                    () => { return _parent.BeginLifetimeScope(Statics.LifetimeScopeTag, _configureEnabled); },
                    LazyThreadSafetyMode.ExecutionAndPublication);

            _disabled =
                new Lazy<ILifetimeScope>(
                    () => { return _parent.BeginLifetimeScope(Statics.LifetimeScopeTag, _configureDisabled); },
                    LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public ILifetimeScope ParentLifetimeScope
        {
            get { return _parent; }
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_enabled.IsValueCreated)
                _enabled.Value.Dispose();

            if (_disabled.IsValueCreated)
                _disabled.Value.Dispose();

            _disposed = true;
        }

        public object ResolveComponent(IComponentRegistration registration, IEnumerable<Parameter> parameters)
        {
            return GetCurrentSwitchScope().ResolveComponent(registration, parameters);
        }

        public IComponentRegistry ComponentRegistry
        {
            get { return GetCurrentSwitchScope().ComponentRegistry; }
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            return GetCurrentSwitchScope().BeginLifetimeScope();
        }

        public ILifetimeScope BeginLifetimeScope(object tag)
        {
            return GetCurrentSwitchScope().BeginLifetimeScope(tag);
        }

        public ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            return GetCurrentSwitchScope().BeginLifetimeScope(configurationAction);
        }

        public ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
        {
            return GetCurrentSwitchScope().BeginLifetimeScope(tag, configurationAction);
        }

        public IDisposer Disposer
        {
            get { return GetCurrentSwitchScope().Disposer; }
        }

        public object Tag
        {
            get { return GetCurrentSwitchScope().Tag; }
        }

        /// <summary>
        /// Fired when a new scope based on the current scope is beginning.
        /// </summary>
        public event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning
        {
            add { GetCurrentSwitchScope().ChildLifetimeScopeBeginning += value; }

            remove { GetCurrentSwitchScope().ChildLifetimeScopeBeginning -= value; }
        }

        /// <summary>
        /// Fired when this scope is ending.
        /// </summary>
        public event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding
        {
            add { GetCurrentSwitchScope().CurrentScopeEnding += value; }

            remove { GetCurrentSwitchScope().CurrentScopeEnding -= value; }
        }

        /// <summary>
        /// Fired when a resolve operation is beginning in this scope.
        /// </summary>
        public event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning
        {
            add { GetCurrentSwitchScope().ResolveOperationBeginning += value; }

            remove { GetCurrentSwitchScope().ResolveOperationBeginning -= value; }
        }

        public ILifetimeScope DisabledLifetimeScope
        {
            get { return _disabled.Value; }
        }

        public ILifetimeScope EnabledLifetimeScope
        {
            get { return _enabled.Value; }
        }

        public void ConfigureEnabled(Action<ContainerBuilder> configurationAction)
        {
            if (configurationAction == null)
                throw new ArgumentNullException("configurationAction");

            if (_enabled.IsValueCreated)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                    "The enabled container for {0} has already been configured.", Statics.LifetimeScopeTag));
            }

            _configureEnabled = configurationAction;
        }

        public void ConfigureDisabled(Action<ContainerBuilder> configurationAction)
        {
            if (configurationAction == null)
                throw new ArgumentNullException("configurationAction");

            if (_disabled.IsValueCreated)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                    "The disabled container for {0} has already been configured.", Statics.LifetimeScopeTag));
            }

            _configureDisabled = configurationAction;
        }

        ILifetimeScope GetCurrentSwitchScope()
        {
            var fooId = _parent.Resolve<ICodeSwitch<TFoo>>();

            return fooId.Enabled ? EnabledLifetimeScope : DisabledLifetimeScope;
        }


        internal static class Statics
        {
            public static readonly object LifetimeScopeTag = typeof(TFoo).FullName;
        }
    }
}