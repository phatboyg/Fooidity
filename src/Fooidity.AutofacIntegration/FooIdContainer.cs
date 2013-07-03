namespace Fooidity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using Autofac;
    using Autofac.Core;
    using Autofac.Core.Lifetime;
    using Autofac.Core.Resolving;

    public class AutofacFooIdContainer :
        FooIdContainer
    {
        internal static readonly object SwitchLifetimeScopeTag = "fooIdLifetime";
        //readonly SwitchId _defaultSwitchId = new SwitchId("Default");
        //readonly ISwitchSelectionStrategy _selectionStrategy;
        readonly Hashtable _switchLifetimeScopes = new Hashtable();

        bool _disposed;
        IContainer _parentContainer;

        public AutofacFooIdContainer(IContainer parentContainer /*ISwitchSelectionStrategy selectionStrategy*/)
        {
            _parentContainer = parentContainer;
//            _selectionStrategy = selectionStrategy;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        public IContainer ParentContainer
        {
            get { return _parentContainer; }
        }

//        public ILifetimeScope GetSwitchScope(SwitchId switchId)
//        {
//            object switchScope = _switchLifetimeScopes[switchId];
//            if (switchScope == null)
//            {
//                lock (_switchLifetimeScopes.SyncRoot)
//                {
//                    switchScope = _switchLifetimeScopes[switchId];
//                    if (switchScope == null)
//                    {
//                        switchScope = _parentContainer.BeginLifetimeScope(SwitchLifetimeScopeTag);
//                        _switchLifetimeScopes[switchId] = switchScope;
//                    }
//                }
//            }
//            return (ILifetimeScope)switchScope;
//        }
//
//        public void ConfigureSwitch(SwitchId switchId, Action<ContainerBuilder> configurationAction)
//        {
//            if (configurationAction == null)
//                throw new ArgumentNullException("configurationAction");
//
//            lock (_switchLifetimeScopes.SyncRoot)
//            {
//                // The check and [potential] scope creation are locked here to
//                // ensure atomicity. We don't want to check and then have another
//                // thread create the lifetime scope behind our backs.
//                if (_switchLifetimeScopes.ContainsKey(switchId))
//                {
//                    throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
//                        "The switch has already been configured: {0}", switchId));
//                }
//                _switchLifetimeScopes[switchId] = ParentContainer.BeginLifetimeScope(SwitchLifetimeScopeTag,
//                    configurationAction);
//            }
//        }

        ILifetimeScope GetCurrentSwitchScope()
        {
            return _parentContainer;
//            SwitchId switchId;
//            if (_selectionStrategy.TryGetSwitchId(out switchId))
//                return GetSwitchScope(switchId);
//
//            return GetSwitchScope(_defaultSwitchId);
        }

        ~AutofacFooIdContainer()
        {
            Dispose(false);
        }

        void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                lock (_switchLifetimeScopes.SyncRoot)
                {
                    foreach (ILifetimeScope scope in _switchLifetimeScopes.Values)
                        scope.Dispose();
                }

                _parentContainer.Dispose();
            }

            lock (_switchLifetimeScopes.SyncRoot)
            {
                _switchLifetimeScopes.Clear();
            }

            _parentContainer = null;

            _disposed = true;
        }
    }


    public interface FooIdContainer :
        IContainer
    {
    }
}