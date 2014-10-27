namespace Fooidity.CodeSwitches
{
    using System;
    using Events;


    /// <summary>
    /// A CodeSwitch that can be changed by calling the appropriate method
    /// </summary>
    /// <typeparam name="TFeature">The code feature</typeparam>
    public class ToggleCodeSwitch<TFeature> :
        IToggleCodeSwitch<TFeature>,
        IObservable<CodeSwitchEvaluated>
        where TFeature : struct, CodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;
        bool _toggleEnabled;

        public ToggleCodeSwitch(bool enabled)
        {
            _toggleEnabled = enabled;
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
            _toggleEnabled = true;
        }

        public void Disable()
        {
            _toggleEnabled = false;
        }

        bool Evaluate()
        {
            bool enabled = _toggleEnabled;

            _evaluated.Evaluated(enabled);

            return enabled;
        }
    }
}