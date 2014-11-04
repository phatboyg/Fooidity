namespace Fooidity.CodeSwitches
{
    using System;
    using Contracts;


    /// <summary>
    /// A disabled code switch is always disabled
    /// </summary>
    /// <typeparam name="TFeature"></typeparam>
    public class DisabledCodeSwitch<TFeature> :
        ICodeSwitch<TFeature>
        where TFeature : struct, ICodeFeature
    {
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;
        bool _evaluationComplete;

        public DisabledCodeSwitch()
        {
            _evaluated = new CodeSwitchEvaluatedObservable<TFeature>();
        }

        bool ICodeSwitch<TFeature>.Enabled
        {
            get
            {
                if (!_evaluationComplete)
                {
                    _evaluationComplete = true;

                    _evaluated.Evaluated(false);
                }

                return false;
            }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }
    }
}