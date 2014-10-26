namespace Fooidity
{
    public interface IDependentCodeSwitchFactory<T>
        where T : struct, CodeFeature
    {
        CodeSwitch<T, T1> Upon<T1>(CodeSwitch<T1> fooId1)
            where T1 : struct, CodeFeature;

        CodeSwitch<T, T1, T2> Upon<T1, T2>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3> Upon<T1, T2, T3>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4> Upon<T1, T2, T3, T4>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5> Upon<T1, T2, T3, T4, T5>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6> Upon<T1, T2, T3, T4, T5, T6>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> Upon<T1, T2, T3, T4, T5, T6, T7>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> Upon<T1, T2, T3, T4, T5, T6, T7, T8>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature
            where T8 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature
            where T8 : struct, CodeFeature
            where T9 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10)
            where T1 : struct, CodeFeature
            where T2 : struct, CodeFeature
            where T3 : struct, CodeFeature
            where T4 : struct, CodeFeature
            where T5 : struct, CodeFeature
            where T6 : struct, CodeFeature
            where T7 : struct, CodeFeature
            where T8 : struct, CodeFeature
            where T9 : struct, CodeFeature
            where T10 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11)
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
            where T11 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11, CodeSwitch<T12> fooId12)
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
            where T12 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11, CodeSwitch<T12> fooId12, CodeSwitch<T13> fooId13)
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
            where T13 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11, CodeSwitch<T12> fooId12, CodeSwitch<T13> fooId13, CodeSwitch<T14> fooId14)
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
            where T14 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11, CodeSwitch<T12> fooId12, CodeSwitch<T13> fooId13, CodeSwitch<T14> fooId14, CodeSwitch<T15> fooId15)
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
            where T15 : struct, CodeFeature;

        CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(CodeSwitch<T1> fooId1, CodeSwitch<T2> fooId2, CodeSwitch<T3> fooId3, CodeSwitch<T4> fooId4, CodeSwitch<T5> fooId5, CodeSwitch<T6> fooId6, CodeSwitch<T7> fooId7, CodeSwitch<T8> fooId8, CodeSwitch<T9> fooId9, CodeSwitch<T10> fooId10, CodeSwitch<T11> fooId11, CodeSwitch<T12> fooId12, CodeSwitch<T13> fooId13, CodeSwitch<T14> fooId14, CodeSwitch<T15> fooId15, CodeSwitch<T16> fooId16)
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
            where T16 : struct, CodeFeature;
    }
}