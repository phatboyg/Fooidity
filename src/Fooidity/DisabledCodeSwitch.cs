namespace Fooidity
{
    /// <summary>
    /// A disabled code switch is always disabled
    /// </summary>
    /// <typeparam name="T"></typeparam>
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