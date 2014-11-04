namespace Fooidity.Dependents
{
    using System;
    using CodeSwitches;
    using Contracts;

    public class DependentCodeSwitch<T, T1> :
        ICodeSwitch<T, T1>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2> :
        ICodeSwitch<T, T1, T2>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3> :
        ICodeSwitch<T, T1, T2, T3>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4> :
        ICodeSwitch<T, T1, T2, T3, T4>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5> :
        ICodeSwitch<T, T1, T2, T3, T4, T5>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
        where T12 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;
        readonly ICodeSwitch<T12> _codeSwitch12;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
            _codeSwitch12 = codeSwitch12;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public ICodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
        where T12 : struct, ICodeFeature
        where T13 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;
        readonly ICodeSwitch<T12> _codeSwitch12;
        readonly ICodeSwitch<T13> _codeSwitch13;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
            _codeSwitch12 = codeSwitch12;
            _codeSwitch13 = codeSwitch13;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public ICodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public ICodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
        where T12 : struct, ICodeFeature
        where T13 : struct, ICodeFeature
        where T14 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;
        readonly ICodeSwitch<T12> _codeSwitch12;
        readonly ICodeSwitch<T13> _codeSwitch13;
        readonly ICodeSwitch<T14> _codeSwitch14;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
            _codeSwitch12 = codeSwitch12;
            _codeSwitch13 = codeSwitch13;
            _codeSwitch14 = codeSwitch14;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public ICodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public ICodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public ICodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
        where T12 : struct, ICodeFeature
        where T13 : struct, ICodeFeature
        where T14 : struct, ICodeFeature
        where T15 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;
        readonly ICodeSwitch<T12> _codeSwitch12;
        readonly ICodeSwitch<T13> _codeSwitch13;
        readonly ICodeSwitch<T14> _codeSwitch14;
        readonly ICodeSwitch<T15> _codeSwitch15;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14, ICodeSwitch<T15> codeSwitch15)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
            _codeSwitch12 = codeSwitch12;
            _codeSwitch13 = codeSwitch13;
            _codeSwitch14 = codeSwitch14;
            _codeSwitch15 = codeSwitch15;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled && _codeSwitch15.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public ICodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public ICodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public ICodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }

        public ICodeSwitch<T15> Switch15
        {
            get { return _codeSwitch15; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        where T : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
        where T9 : struct, ICodeFeature
        where T10 : struct, ICodeFeature
        where T11 : struct, ICodeFeature
        where T12 : struct, ICodeFeature
        where T13 : struct, ICodeFeature
        where T14 : struct, ICodeFeature
        where T15 : struct, ICodeFeature
        where T16 : struct, ICodeFeature
    {
        readonly Lazy<bool> _enabled;
        readonly CodeSwitchEvaluatedObservable<T> _evaluated;
        readonly ICodeSwitch<T1> _codeSwitch1;
        readonly ICodeSwitch<T2> _codeSwitch2;
        readonly ICodeSwitch<T3> _codeSwitch3;
        readonly ICodeSwitch<T4> _codeSwitch4;
        readonly ICodeSwitch<T5> _codeSwitch5;
        readonly ICodeSwitch<T6> _codeSwitch6;
        readonly ICodeSwitch<T7> _codeSwitch7;
        readonly ICodeSwitch<T8> _codeSwitch8;
        readonly ICodeSwitch<T9> _codeSwitch9;
        readonly ICodeSwitch<T10> _codeSwitch10;
        readonly ICodeSwitch<T11> _codeSwitch11;
        readonly ICodeSwitch<T12> _codeSwitch12;
        readonly ICodeSwitch<T13> _codeSwitch13;
        readonly ICodeSwitch<T14> _codeSwitch14;
        readonly ICodeSwitch<T15> _codeSwitch15;
        readonly ICodeSwitch<T16> _codeSwitch16;

        public DependentCodeSwitch(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14, ICodeSwitch<T15> codeSwitch15, ICodeSwitch<T16> codeSwitch16)
        {
            _evaluated = new CodeSwitchEvaluatedObservable<T>();
            _enabled = new Lazy<bool>(Evaluate);

            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
            _codeSwitch7 = codeSwitch7;
            _codeSwitch8 = codeSwitch8;
            _codeSwitch9 = codeSwitch9;
            _codeSwitch10 = codeSwitch10;
            _codeSwitch11 = codeSwitch11;
            _codeSwitch12 = codeSwitch12;
            _codeSwitch13 = codeSwitch13;
            _codeSwitch14 = codeSwitch14;
            _codeSwitch15 = codeSwitch15;
            _codeSwitch16 = codeSwitch16;
        }

        public bool Enabled
        {
            get { return _enabled.Value; }
        }

        public IDisposable Subscribe(IObserver<ICodeSwitchEvaluated> observer)
        {
            return _evaluated.Connect(observer);
        }

        bool Evaluate()
        {
            bool enabled = GetEnabled();

            _evaluated.Evaluated(enabled);

            return enabled;
        }

        bool GetEnabled()
        {
            return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled && _codeSwitch15.Enabled && _codeSwitch16.Enabled;
        }
        
        public ICodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public ICodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public ICodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public ICodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public ICodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public ICodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public ICodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public ICodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public ICodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public ICodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public ICodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public ICodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public ICodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public ICodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }

        public ICodeSwitch<T15> Switch15
        {
            get { return _codeSwitch15; }
        }

        public ICodeSwitch<T16> Switch16
        {
            get { return _codeSwitch16; }
        }
    }

}