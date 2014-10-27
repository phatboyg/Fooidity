namespace Fooidity.Dependents
{

    public class DependentCodeSwitch<T, T1> :
        CodeSwitch<T, T1>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1)
        {
            _codeSwitch1 = codeSwitch1;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2> :
        CodeSwitch<T, T1, T2>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2)
        {
            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3> :
        CodeSwitch<T, T1, T2, T3>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3)
        {
            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4> :
        CodeSwitch<T, T1, T2, T3, T4>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4)
        {
            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5> :
        CodeSwitch<T, T1, T2, T3, T4, T5>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5)
        {
            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6)
        {
            _codeSwitch1 = codeSwitch1;
            _codeSwitch2 = codeSwitch2;
            _codeSwitch3 = codeSwitch3;
            _codeSwitch4 = codeSwitch4;
            _codeSwitch5 = codeSwitch5;
            _codeSwitch6 = codeSwitch6;
        }

        public bool Enabled
        {
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
        where T12 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;
        readonly CodeSwitch<T12> _codeSwitch12;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public CodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
        where T12 : struct, CodeFeature
        where T13 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;
        readonly CodeSwitch<T12> _codeSwitch12;
        readonly CodeSwitch<T13> _codeSwitch13;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public CodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public CodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
        where T12 : struct, CodeFeature
        where T13 : struct, CodeFeature
        where T14 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;
        readonly CodeSwitch<T12> _codeSwitch12;
        readonly CodeSwitch<T13> _codeSwitch13;
        readonly CodeSwitch<T14> _codeSwitch14;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public CodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public CodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public CodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
        where T12 : struct, CodeFeature
        where T13 : struct, CodeFeature
        where T14 : struct, CodeFeature
        where T15 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;
        readonly CodeSwitch<T12> _codeSwitch12;
        readonly CodeSwitch<T13> _codeSwitch13;
        readonly CodeSwitch<T14> _codeSwitch14;
        readonly CodeSwitch<T15> _codeSwitch15;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14, CodeSwitch<T15> codeSwitch15)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled && _codeSwitch15.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public CodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public CodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public CodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }

        public CodeSwitch<T15> Switch15
        {
            get { return _codeSwitch15; }
        }
    }

    public class DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        where T : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
        where T9 : struct, CodeFeature
        where T10 : struct, CodeFeature
        where T11 : struct, CodeFeature
        where T12 : struct, CodeFeature
        where T13 : struct, CodeFeature
        where T14 : struct, CodeFeature
        where T15 : struct, CodeFeature
        where T16 : struct, CodeFeature
    {
        readonly CodeSwitch<T1> _codeSwitch1;
        readonly CodeSwitch<T2> _codeSwitch2;
        readonly CodeSwitch<T3> _codeSwitch3;
        readonly CodeSwitch<T4> _codeSwitch4;
        readonly CodeSwitch<T5> _codeSwitch5;
        readonly CodeSwitch<T6> _codeSwitch6;
        readonly CodeSwitch<T7> _codeSwitch7;
        readonly CodeSwitch<T8> _codeSwitch8;
        readonly CodeSwitch<T9> _codeSwitch9;
        readonly CodeSwitch<T10> _codeSwitch10;
        readonly CodeSwitch<T11> _codeSwitch11;
        readonly CodeSwitch<T12> _codeSwitch12;
        readonly CodeSwitch<T13> _codeSwitch13;
        readonly CodeSwitch<T14> _codeSwitch14;
        readonly CodeSwitch<T15> _codeSwitch15;
        readonly CodeSwitch<T16> _codeSwitch16;

        public DependentCodeSwitch(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14, CodeSwitch<T15> codeSwitch15, CodeSwitch<T16> codeSwitch16)
        {
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
            get { return _codeSwitch1.Enabled && _codeSwitch2.Enabled && _codeSwitch3.Enabled && _codeSwitch4.Enabled && _codeSwitch5.Enabled && _codeSwitch6.Enabled && _codeSwitch7.Enabled && _codeSwitch8.Enabled && _codeSwitch9.Enabled && _codeSwitch10.Enabled && _codeSwitch11.Enabled && _codeSwitch12.Enabled && _codeSwitch13.Enabled && _codeSwitch14.Enabled && _codeSwitch15.Enabled && _codeSwitch16.Enabled; }
        }
        
        public CodeSwitch<T1> Switch1
        {
            get { return _codeSwitch1; }
        }

        public CodeSwitch<T2> Switch2
        {
            get { return _codeSwitch2; }
        }

        public CodeSwitch<T3> Switch3
        {
            get { return _codeSwitch3; }
        }

        public CodeSwitch<T4> Switch4
        {
            get { return _codeSwitch4; }
        }

        public CodeSwitch<T5> Switch5
        {
            get { return _codeSwitch5; }
        }

        public CodeSwitch<T6> Switch6
        {
            get { return _codeSwitch6; }
        }

        public CodeSwitch<T7> Switch7
        {
            get { return _codeSwitch7; }
        }

        public CodeSwitch<T8> Switch8
        {
            get { return _codeSwitch8; }
        }

        public CodeSwitch<T9> Switch9
        {
            get { return _codeSwitch9; }
        }

        public CodeSwitch<T10> Switch10
        {
            get { return _codeSwitch10; }
        }

        public CodeSwitch<T11> Switch11
        {
            get { return _codeSwitch11; }
        }

        public CodeSwitch<T12> Switch12
        {
            get { return _codeSwitch12; }
        }

        public CodeSwitch<T13> Switch13
        {
            get { return _codeSwitch13; }
        }

        public CodeSwitch<T14> Switch14
        {
            get { return _codeSwitch14; }
        }

        public CodeSwitch<T15> Switch15
        {
            get { return _codeSwitch15; }
        }

        public CodeSwitch<T16> Switch16
        {
            get { return _codeSwitch16; }
        }
    }

}