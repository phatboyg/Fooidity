namespace Fooidity.Dependents
{
    public class DependentCodeSwitchFactory<T> :
        IDependentCodeSwitchFactory<T>
        where T : struct, CodeFeature
    {
        public CodeSwitch<T, T1> Upon<T1>(CodeSwitch<T1> codeSwitch1)
            where T1 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1>(codeSwitch1);
        }

        public CodeSwitch<T, T1, T2> Upon<T1, T2>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2>(codeSwitch1, codeSwitch2);
        }

        public CodeSwitch<T, T1, T2, T3> Upon<T1, T2, T3>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3>(codeSwitch1, codeSwitch2, codeSwitch3);
        }

        public CodeSwitch<T, T1, T2, T3, T4> Upon<T1, T2, T3, T4>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5> Upon<T1, T2, T3, T4, T5>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6> Upon<T1, T2, T3, T4, T5, T6>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> Upon<T1, T2, T3, T4, T5, T6, T7>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> Upon<T1, T2, T3, T4, T5, T6, T7, T8>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature
            where T8 : struct, CodeFeature
        {
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14, CodeSwitch<T15> codeSwitch15)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14, codeSwitch15);
        }

        public CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(CodeSwitch<T1> codeSwitch1, CodeSwitch<T2> codeSwitch2, CodeSwitch<T3> codeSwitch3, CodeSwitch<T4> codeSwitch4, CodeSwitch<T5> codeSwitch5, CodeSwitch<T6> codeSwitch6, CodeSwitch<T7> codeSwitch7, CodeSwitch<T8> codeSwitch8, CodeSwitch<T9> codeSwitch9, CodeSwitch<T10> codeSwitch10, CodeSwitch<T11> codeSwitch11, CodeSwitch<T12> codeSwitch12, CodeSwitch<T13> codeSwitch13, CodeSwitch<T14> codeSwitch14, CodeSwitch<T15> codeSwitch15, CodeSwitch<T16> codeSwitch16)
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
            return new DependentCodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(codeSwitch1, codeSwitch2, codeSwitch3, codeSwitch4, codeSwitch5, codeSwitch6, codeSwitch7, codeSwitch8, codeSwitch9, codeSwitch10, codeSwitch11, codeSwitch12, codeSwitch13, codeSwitch14, codeSwitch15, codeSwitch16);
        }

    }
}