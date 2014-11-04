namespace Fooidity.Dependents
{
    public interface IDependentCodeSwitchFactory<T>
        where T : struct, ICodeFeature
    {
        ICodeSwitch<T, T1> Upon<T1>(ICodeSwitch<T1> fooId1)
            where T1 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2> Upon<T1, T2>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3> Upon<T1, T2, T3>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4> Upon<T1, T2, T3, T4>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5> Upon<T1, T2, T3, T4, T5>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6> Upon<T1, T2, T3, T4, T5, T6>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> Upon<T1, T2, T3, T4, T5, T6, T7>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> Upon<T1, T2, T3, T4, T5, T6, T7, T8>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature
            where T8 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature
            where T8 : struct, ICodeFeature
            where T9 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10)
            where T1 : struct, ICodeFeature
            where T2 : struct, ICodeFeature
            where T3 : struct, ICodeFeature
            where T4 : struct, ICodeFeature
            where T5 : struct, ICodeFeature
            where T6 : struct, ICodeFeature
            where T7 : struct, ICodeFeature
            where T8 : struct, ICodeFeature
            where T9 : struct, ICodeFeature
            where T10 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11)
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
            where T11 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11, ICodeSwitch<T12> fooId12)
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
            where T12 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11, ICodeSwitch<T12> fooId12, ICodeSwitch<T13> fooId13)
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
            where T13 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11, ICodeSwitch<T12> fooId12, ICodeSwitch<T13> fooId13, ICodeSwitch<T14> fooId14)
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
            where T14 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11, ICodeSwitch<T12> fooId12, ICodeSwitch<T13> fooId13, ICodeSwitch<T14> fooId14, ICodeSwitch<T15> fooId15)
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
            where T15 : struct, ICodeFeature;

        ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Upon<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ICodeSwitch<T1> fooId1, ICodeSwitch<T2> fooId2, ICodeSwitch<T3> fooId3, ICodeSwitch<T4> fooId4, ICodeSwitch<T5> fooId5, ICodeSwitch<T6> fooId6, ICodeSwitch<T7> fooId7, ICodeSwitch<T8> fooId8, ICodeSwitch<T9> fooId9, ICodeSwitch<T10> fooId10, ICodeSwitch<T11> fooId11, ICodeSwitch<T12> fooId12, ICodeSwitch<T13> fooId13, ICodeSwitch<T14> fooId14, ICodeSwitch<T15> fooId15, ICodeSwitch<T16> fooId16)
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
            where T16 : struct, ICodeFeature;
    }
}