namespace Fooidity
{
    public class DisabledCodeSwitch<T> :
        CodeSwitch<T>
        where T : struct, CodeFeature
    {
        bool CodeSwitch<T>.Enabled
        {
            get { return false; }
        }
    }
}