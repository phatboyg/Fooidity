namespace Fooidity
{
    public interface ICodeSwitch<T, T1> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
    }

    public interface ICodeSwitch<T, T1, T2> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
        where T1 : struct, ICodeFeature
        where T2 : struct, ICodeFeature
        where T3 : struct, ICodeFeature
        where T4 : struct, ICodeFeature
        where T5 : struct, ICodeFeature
        where T6 : struct, ICodeFeature
        where T7 : struct, ICodeFeature
        where T8 : struct, ICodeFeature
    {
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
        ICodeSwitch<T12> Switch12 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
        ICodeSwitch<T12> Switch12 { get; }
        ICodeSwitch<T13> Switch13 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
        ICodeSwitch<T12> Switch12 { get; }
        ICodeSwitch<T13> Switch13 { get; }
        ICodeSwitch<T14> Switch14 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
        ICodeSwitch<T12> Switch12 { get; }
        ICodeSwitch<T13> Switch13 { get; }
        ICodeSwitch<T14> Switch14 { get; }
        ICodeSwitch<T15> Switch15 { get; }
    }

    public interface ICodeSwitch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> :
        ICodeSwitch<T>
        where T  : struct, ICodeFeature
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
        ICodeSwitch<T1> Switch1 { get; }
        ICodeSwitch<T2> Switch2 { get; }
        ICodeSwitch<T3> Switch3 { get; }
        ICodeSwitch<T4> Switch4 { get; }
        ICodeSwitch<T5> Switch5 { get; }
        ICodeSwitch<T6> Switch6 { get; }
        ICodeSwitch<T7> Switch7 { get; }
        ICodeSwitch<T8> Switch8 { get; }
        ICodeSwitch<T9> Switch9 { get; }
        ICodeSwitch<T10> Switch10 { get; }
        ICodeSwitch<T11> Switch11 { get; }
        ICodeSwitch<T12> Switch12 { get; }
        ICodeSwitch<T13> Switch13 { get; }
        ICodeSwitch<T14> Switch14 { get; }
        ICodeSwitch<T15> Switch15 { get; }
        ICodeSwitch<T16> Switch16 { get; }
    }
}