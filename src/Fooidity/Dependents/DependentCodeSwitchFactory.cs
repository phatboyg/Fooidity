namespace Fooidity.Dependents
{
    public class DependentCodeSwitchFactory<T> :
        IDependentCodeSwitchFactory<T>
        where T : struct, ICodeFeature
    {
        public ICodeSwitch<T, T1> Upon<T1>(ICodeSwitch<T1> codeSwitch1)
            where T1 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1>(codeSwitch1);
        }

        public ICodeSwitch<T, T1, T2> Upon<T1, T2>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2>(codeSwitch1, codeSwitch2);
        }

        public ICodeSwitch<T, T1, T2, T3> Upon<T1, T2, T3>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3>(codeSwitch1, codeSwitch2, codeSwitch3);
        }

        public ICodeSwitch<T, T1, T2, T3, T4> Upon<T1, T2, T3, T4>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5> Upon<T1, T2, T3, T4, T5>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6> Upon<T1, T2, T3, T4, T5, T6>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> Upon<T1, T2, T3, T4, T5, T6, T7>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> Upon<T1, T2, T3, T4, T5, T6, T7, T8>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature
            where T8 : struct, ICodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14, ICodeSwitch<T15> codeSwitch15)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14, codeSwitch15);
        }

        public ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ICodeSwitch<T1> codeSwitch1, ICodeSwitch<T2> codeSwitch2, ICodeSwitch<T3> codeSwitch3, ICodeSwitch<T4> codeSwitch4, ICodeSwitch<T5> codeSwitch5, ICodeSwitch<T6> codeSwitch6, ICodeSwitch<T7> codeSwitch7, ICodeSwitch<T8> codeSwitch8, ICodeSwitch<T9> codeSwitch9, ICodeSwitch<T10> codeSwitch10, ICodeSwitch<T11> codeSwitch11, ICodeSwitch<T12> codeSwitch12, ICodeSwitch<T13> codeSwitch13, ICodeSwitch<T14> codeSwitch14, ICodeSwitch<T15> codeSwitch15, ICodeSwitch<T16> codeSwitch16)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14, codeSwitch15, codeSwitch16);
        }

    }
}