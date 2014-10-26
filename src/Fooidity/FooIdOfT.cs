namespace Fooidity
{

    public interface CodeSwitch<T, T1> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
    }

    public interface CodeSwitch<T, T1, T2> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
        where T1 : struct, CodeFeature
        where T2 : struct, CodeFeature
        where T3 : struct, CodeFeature
        where T4 : struct, CodeFeature
        where T5 : struct, CodeFeature
        where T6 : struct, CodeFeature
        where T7 : struct, CodeFeature
        where T8 : struct, CodeFeature
    {
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
        CodeSwitch<T12> Switch12 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
        CodeSwitch<T12> Switch12 { get; }
        CodeSwitch<T13> Switch13 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
        CodeSwitch<T12> Switch12 { get; }
        CodeSwitch<T13> Switch13 { get; }
        CodeSwitch<T14> Switch14 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
        CodeSwitch<T12> Switch12 { get; }
        CodeSwitch<T13> Switch13 { get; }
        CodeSwitch<T14> Switch14 { get; }
        CodeSwitch<T15> Switch15 { get; }
    }

    public interface CodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        CodeSwitch<T>
        where T  : struct, CodeFeature
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
        CodeSwitch<T1> Switch1 { get; }
        CodeSwitch<T2> Switch2 { get; }
        CodeSwitch<T3> Switch3 { get; }
        CodeSwitch<T4> Switch4 { get; }
        CodeSwitch<T5> Switch5 { get; }
        CodeSwitch<T6> Switch6 { get; }
        CodeSwitch<T7> Switch7 { get; }
        CodeSwitch<T8> Switch8 { get; }
        CodeSwitch<T9> Switch9 { get; }
        CodeSwitch<T10> Switch10 { get; }
        CodeSwitch<T11> Switch11 { get; }
        CodeSwitch<T12> Switch12 { get; }
        CodeSwitch<T13> Switch13 { get; }
        CodeSwitch<T14> Switch14 { get; }
        CodeSwitch<T15> Switch15 { get; }
        CodeSwitch<T16> Switch16 { get; }
    }

}