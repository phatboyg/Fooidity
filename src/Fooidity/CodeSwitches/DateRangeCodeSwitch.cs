namespace Fooidity.CodeSwitches
{
    using System;
    using Events;


    public class DateRangeCodeSwitch<TFeature> :
        IToggleCodeSwitch<TFeature>,
        IObservable<CodeSwitchEvaluated>
        where TFeature : struct, CodeFeature
    {
        readonly CurrentTimeProvider _currentTimeProvider;
        readonly Lazy<bool> _enabled;
        readonly DateTime? _enabledFrom;
        readonly DateTime? _enabledTo;
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;
        bool _switchEnabled;

        public DateRangeCodeSwitch(bool switchEnabled, DateTime? enabledFrom, DateTime? enabledTo,
            CurrentTimeProvider currentTimeProvider)
        {
            _switchEnabled = switchEnabled;
            _enabledFrom = enabledFrom;
            _enabledTo = enabledTo;
            _currentTimeProvider = currentTimeProvider;
            _evaluated = new CodeSwitchEvaluatedObservable<TFeature>();
            _enabled = new Lazy<bool>(Evaluate);
        }

        public IDisposable Subscribe(IObserver<CodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public void Enable()
        {
            _switchEnabled = true;
        }

        public void Disable()
        {
            _switchEnabled = false;
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            if (!_switchEnabled)
                return false;

            DateTime now = _currentTimeProvider();

            if (_enabledFrom.HasValue && (now < _enabledFrom.Value))
                return false;

            if (_enabledTo.HasValue && (now >= _enabledTo.Value))
                return false;

            return true;
        }
    }
}