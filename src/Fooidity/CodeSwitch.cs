namespace Fooidity
{
    /// <summary>
    /// A set of cached factory methods for various switch types
    /// </summary>
    public static class CodeSwitch
    {
        /// <summary>
        /// Factory instance used to create code switches, allowing extension methods
        /// to add new factory methods for a single point of creation
        /// </summary>
        public static ICodeSwitchFactory Factory
        {
            get { return Cached.CodeSwitchFactory; }
        }


        static class Cached
        {
            internal static readonly ICodeSwitchFactory CodeSwitchFactory = new CodeSwitchFactory();
        }
    }
}