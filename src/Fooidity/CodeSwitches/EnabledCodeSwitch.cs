namespace Fooidity.CodeSwitches
{
    using System;
    using Events;


    /// <summary>
    /// A code switch that is always on
    /// </summary>
    /// <typeparam name="TFeature">The code feature type</typeparam>
    public class EnabledCodeSwitch<TFeature> :
        CodeSwitch<TFeature>,
        IObservable<CodeSwitchEvaluated>
        where TFeature : struct, CodeFeature
    {
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;
        bool _evaluationComplete;

        public EnabledCodeSwitch()
        {
            _evaluated = new CodeSwitchEvaluatedObservable<TFeature>();
        }

        bool CodeSwitch<TFeature>.Enabled
        {
            get
            {
                if (!_evaluationComplete)
                {
                    _evaluationComplete = true;

                    _evaluated.Evaluated(true);
                }

                return true;
            }
        }

        public IDisposable Subscribe(IObserver<CodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }
    }
}