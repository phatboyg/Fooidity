namespace Fooidity.CodeSwitches
{
    /// <summary>
    /// A code switch that is always on
    /// </summary>
    /// <typeparam name="T">The code feature type</typeparam>
    public class EnabledCodeSwitch<T> :
        CodeSwitch<T>
        where T : struct, CodeFeature
    {
        bool CodeSwitch<T>.Enabled
        {
            get { return true; }
        }
    }
}