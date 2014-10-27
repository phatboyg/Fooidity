namespace Fooidity
{
    /// <summary>
    /// Used to convert context to a key, for storage purposes
    /// </summary>
    /// <typeparam name="TContext">The context type</typeparam>
    public interface ContextKeyProvider<in TContext>
    {
        /// <summary>
        /// Return a key for the specified context, used to correlate the context to a 
        /// saved feature state configuration for that context.
        /// </summary>
        /// <param name="context">The context to convert</param>
        /// <returns>The resulting key type</returns>
        string GetKey(TContext context);
    }
}