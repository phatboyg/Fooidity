namespace Fooidity
{
    /// <summary>
    /// A code feature identifies a switch which can be enabled or disabled. Code features must
    /// be implemented as structs, and should be public to support discoverability.
    /// 
    /// public struct MyFeature : CodeFeature {}
    /// </summary>
    public interface CodeFeature
    {
    }
}