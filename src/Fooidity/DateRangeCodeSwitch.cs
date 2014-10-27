namespace Fooidity
{
    using System;


    public class DateRangeCodeSwitch<T> :
        CodeSwitch<T>
        where T : struct, CodeFeature
    {
        readonly Func<DateTime> _currentTime;
        readonly bool _enabled;
        readonly DateTime? _enabledFromDate;
        readonly DateTime? _enabledToDate;

        public DateRangeCodeSwitch(bool enabled,
            DateTime? enabledFromDate,
            DateTime? enabledToDate,
            Func<DateTime> currentTime)
        {
            _enabled = enabled;
            _enabledFromDate = enabledFromDate;
            _enabledToDate = enabledToDate;
            _currentTime = currentTime;
        }

        public bool Enabled
        {
            get
            {
                if (!_enabled)
                    return false;

                DateTime now = _currentTime();

                if (_enabledFromDate.HasValue && (now < _enabledFromDate.Value))
                    return false;

                if (_enabledToDate.HasValue && (now >= _enabledToDate.Value))
                    return false;

                return true;
            }
        }
    }
}