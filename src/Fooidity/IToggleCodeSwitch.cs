namespace Fooidity
{
    /// <summary>
    /// Control a toggle fooId, allowing it to be enabled or disabled
    /// </summary>
    public interface IToggleCodeSwitch<TFeature> :
        ICodeSwitch<TFeature>
        where TFeature : struct, ICodeFeature
    {
        /// <summary>
        /// Enable the fooId
        /// </summary>
        void Enable();

        /// <summary>
        /// Disable the fooId
        /// </summary>
        void Disable();
    }
}