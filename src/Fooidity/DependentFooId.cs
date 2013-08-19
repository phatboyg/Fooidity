namespace Fooidity
{

    public class DependentFooId<T, T1> :
        FooId<T, T1>
        where T : struct, FooId
        where T1 : struct, FooId
    {
        readonly FooId<T1> _fooId1;

        public DependentFooId(FooId<T1> fooId1)
        {
            _fooId1 = fooId1;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }
    }

    public class DependentFooId<T, T1, T2> :
        FooId<T, T1, T2>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }
    }

    public class DependentFooId<T, T1, T2, T3> :
        FooId<T, T1, T2, T3>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4> :
        FooId<T, T1, T2, T3, T4>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5> :
        FooId<T, T1, T2, T3, T4, T5>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6> :
        FooId<T, T1, T2, T3, T4, T5, T6>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
        where T12 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;
        readonly FooId<T12> _fooId12;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
            _fooId12 = fooId12;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled && _fooId12.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }

        public FooId<T12> FooId12
        {
            get { return _fooId12; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
        where T12 : struct, FooId
        where T13 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;
        readonly FooId<T12> _fooId12;
        readonly FooId<T13> _fooId13;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
            _fooId12 = fooId12;
            _fooId13 = fooId13;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled && _fooId12.Enabled && _fooId13.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }

        public FooId<T12> FooId12
        {
            get { return _fooId12; }
        }

        public FooId<T13> FooId13
        {
            get { return _fooId13; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
        where T12 : struct, FooId
        where T13 : struct, FooId
        where T14 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;
        readonly FooId<T12> _fooId12;
        readonly FooId<T13> _fooId13;
        readonly FooId<T14> _fooId14;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
            _fooId12 = fooId12;
            _fooId13 = fooId13;
            _fooId14 = fooId14;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled && _fooId12.Enabled && _fooId13.Enabled && _fooId14.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }

        public FooId<T12> FooId12
        {
            get { return _fooId12; }
        }

        public FooId<T13> FooId13
        {
            get { return _fooId13; }
        }

        public FooId<T14> FooId14
        {
            get { return _fooId14; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
        where T12 : struct, FooId
        where T13 : struct, FooId
        where T14 : struct, FooId
        where T15 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;
        readonly FooId<T12> _fooId12;
        readonly FooId<T13> _fooId13;
        readonly FooId<T14> _fooId14;
        readonly FooId<T15> _fooId15;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14, FooId<T15> fooId15)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
            _fooId12 = fooId12;
            _fooId13 = fooId13;
            _fooId14 = fooId14;
            _fooId15 = fooId15;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled && _fooId12.Enabled && _fooId13.Enabled && _fooId14.Enabled && _fooId15.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }

        public FooId<T12> FooId12
        {
            get { return _fooId12; }
        }

        public FooId<T13> FooId13
        {
            get { return _fooId13; }
        }

        public FooId<T14> FooId14
        {
            get { return _fooId14; }
        }

        public FooId<T15> FooId15
        {
            get { return _fooId15; }
        }
    }

    public class DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        where T : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
        where T9 : struct, FooId
        where T10 : struct, FooId
        where T11 : struct, FooId
        where T12 : struct, FooId
        where T13 : struct, FooId
        where T14 : struct, FooId
        where T15 : struct, FooId
        where T16 : struct, FooId
    {
        readonly FooId<T1> _fooId1;
        readonly FooId<T2> _fooId2;
        readonly FooId<T3> _fooId3;
        readonly FooId<T4> _fooId4;
        readonly FooId<T5> _fooId5;
        readonly FooId<T6> _fooId6;
        readonly FooId<T7> _fooId7;
        readonly FooId<T8> _fooId8;
        readonly FooId<T9> _fooId9;
        readonly FooId<T10> _fooId10;
        readonly FooId<T11> _fooId11;
        readonly FooId<T12> _fooId12;
        readonly FooId<T13> _fooId13;
        readonly FooId<T14> _fooId14;
        readonly FooId<T15> _fooId15;
        readonly FooId<T16> _fooId16;

        public DependentFooId(FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14, FooId<T15> fooId15, FooId<T16> fooId16)
        {
            _fooId1 = fooId1;
            _fooId2 = fooId2;
            _fooId3 = fooId3;
            _fooId4 = fooId4;
            _fooId5 = fooId5;
            _fooId6 = fooId6;
            _fooId7 = fooId7;
            _fooId8 = fooId8;
            _fooId9 = fooId9;
            _fooId10 = fooId10;
            _fooId11 = fooId11;
            _fooId12 = fooId12;
            _fooId13 = fooId13;
            _fooId14 = fooId14;
            _fooId15 = fooId15;
            _fooId16 = fooId16;
        }

        public bool Enabled
        {
            get { return _fooId1.Enabled && _fooId2.Enabled && _fooId3.Enabled && _fooId4.Enabled && _fooId5.Enabled && _fooId6.Enabled && _fooId7.Enabled && _fooId8.Enabled && _fooId9.Enabled && _fooId10.Enabled && _fooId11.Enabled && _fooId12.Enabled && _fooId13.Enabled && _fooId14.Enabled && _fooId15.Enabled && _fooId16.Enabled; }
        }
        
        public FooId<T1> FooId1
        {
            get { return _fooId1; }
        }

        public FooId<T2> FooId2
        {
            get { return _fooId2; }
        }

        public FooId<T3> FooId3
        {
            get { return _fooId3; }
        }

        public FooId<T4> FooId4
        {
            get { return _fooId4; }
        }

        public FooId<T5> FooId5
        {
            get { return _fooId5; }
        }

        public FooId<T6> FooId6
        {
            get { return _fooId6; }
        }

        public FooId<T7> FooId7
        {
            get { return _fooId7; }
        }

        public FooId<T8> FooId8
        {
            get { return _fooId8; }
        }

        public FooId<T9> FooId9
        {
            get { return _fooId9; }
        }

        public FooId<T10> FooId10
        {
            get { return _fooId10; }
        }

        public FooId<T11> FooId11
        {
            get { return _fooId11; }
        }

        public FooId<T12> FooId12
        {
            get { return _fooId12; }
        }

        public FooId<T13> FooId13
        {
            get { return _fooId13; }
        }

        public FooId<T14> FooId14
        {
            get { return _fooId14; }
        }

        public FooId<T15> FooId15
        {
            get { return _fooId15; }
        }

        public FooId<T16> FooId16
        {
            get { return _fooId16; }
        }
    }

}