namespace Fooidity
{
    public static class DependentFactoryExtensions
    {

        public static FooId<T, T1> Dependent<T, T1>(this T fooId, FooId<T1> fooId1)
            where T : struct, FooId
            where T1 : struct, FooId
        {
            return new DependentFooId<T, T1>(fooId1);
        }


        public static FooId<T, T1, T2> Dependent<T, T1, T2>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
        {
            return new DependentFooId<T, T1, T2>(fooId1, fooId2);
        }


        public static FooId<T, T1, T2, T3> Dependent<T, T1, T2, T3>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
            where T3 : struct, FooId
        {
            return new DependentFooId<T, T1, T2, T3>(fooId1, fooId2, fooId3);
        }


        public static FooId<T, T1, T2, T3, T4> Dependent<T, T1, T2, T3, T4>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
            where T3 : struct, FooId
            where T4 : struct, FooId
        {
            return new DependentFooId<T, T1, T2, T3, T4>(fooId1, fooId2, fooId3, fooId4);
        }


        public static FooId<T, T1, T2, T3, T4, T5> Dependent<T, T1, T2, T3, T4, T5>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
            where T3 : struct, FooId
            where T4 : struct, FooId
            where T5 : struct, FooId
        {
            return new DependentFooId<T, T1, T2, T3, T4, T5>(fooId1, fooId2, fooId3, fooId4, fooId5);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6> Dependent<T, T1, T2, T3, T4, T5, T6>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
            where T3 : struct, FooId
            where T4 : struct, FooId
            where T5 : struct, FooId
            where T6 : struct, FooId
        {
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7> Dependent<T, T1, T2, T3, T4, T5, T6, T7>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7)
            where T : struct, FooId
            where T1 : struct, FooId
            where T2 : struct, FooId
            where T3 : struct, FooId
            where T4 : struct, FooId
            where T5 : struct, FooId
            where T6 : struct, FooId
            where T7 : struct, FooId
        {
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11, fooId12);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11, fooId12, fooId13);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11, fooId12, fooId13, fooId14);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14, FooId<T15> fooId15)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11, fooId12, fooId13, fooId14, fooId15);
        }


        public static FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Dependent<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this T fooId, FooId<T1> fooId1, FooId<T2> fooId2, FooId<T3> fooId3, FooId<T4> fooId4, FooId<T5> fooId5, FooId<T6> fooId6, FooId<T7> fooId7, FooId<T8> fooId8, FooId<T9> fooId9, FooId<T10> fooId10, FooId<T11> fooId11, FooId<T12> fooId12, FooId<T13> fooId13, FooId<T14> fooId14, FooId<T15> fooId15, FooId<T16> fooId16)
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
            return new DependentFooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(fooId1, fooId2, fooId3, fooId4, fooId5, fooId6, fooId7, fooId8, fooId9, fooId10, fooId11, fooId12, fooId13, fooId14, fooId15, fooId16);
        }

    }
}