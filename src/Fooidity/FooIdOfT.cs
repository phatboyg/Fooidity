namespace Fooidity
{

    public interface FooId<T, T1> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
    }

    public interface FooId<T, T1, T2> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
    }

    public interface FooId<T, T1, T2, T3> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        FooId<T>
        where T  : struct, FooId
        where T1 : struct, FooId
        where T2 : struct, FooId
        where T3 : struct, FooId
        where T4 : struct, FooId
        where T5 : struct, FooId
        where T6 : struct, FooId
        where T7 : struct, FooId
        where T8 : struct, FooId
    {
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
        FooId<T12> FooId12 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
        FooId<T12> FooId12 { get; }
        FooId<T13> FooId13 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
        FooId<T12> FooId12 { get; }
        FooId<T13> FooId13 { get; }
        FooId<T14> FooId14 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
        FooId<T12> FooId12 { get; }
        FooId<T13> FooId13 { get; }
        FooId<T14> FooId14 { get; }
        FooId<T15> FooId15 { get; }
    }

    public interface FooId<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        FooId<T>
        where T  : struct, FooId
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
        FooId<T1> FooId1 { get; }
        FooId<T2> FooId2 { get; }
        FooId<T3> FooId3 { get; }
        FooId<T4> FooId4 { get; }
        FooId<T5> FooId5 { get; }
        FooId<T6> FooId6 { get; }
        FooId<T7> FooId7 { get; }
        FooId<T8> FooId8 { get; }
        FooId<T9> FooId9 { get; }
        FooId<T10> FooId10 { get; }
        FooId<T11> FooId11 { get; }
        FooId<T12> FooId12 { get; }
        FooId<T13> FooId13 { get; }
        FooId<T14> FooId14 { get; }
        FooId<T15> FooId15 { get; }
        FooId<T16> FooId16 { get; }
    }

}