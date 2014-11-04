namespace Fooidity.CodeSwitches
{
    using System;
    using Contracts;


    /// <summary>
    /// A code switch that is always on
    /// </summary>
    /// <typeparam name="TFeature">The code feature type</typeparam>
    public class EnabledCodeSwitch<TFeature> :
        ICodeSwitch<TFeature>
        where TFeature : struct, ICodeFeature
    {
        readonly CodeSwitchEvaluatedObservable<TFeature> _evaluated;
        bool _evaluationComplete;

        public EnabledCodeSwitch()
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

                    _evaluated.Evaluated(true);
                }

                return true;
            }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }
    }
}