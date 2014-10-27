namespace Fooidity.Caching
{
    public interface ContextKeyProvider<in TContext>
    {
        string GetKey(TContext context);
    }
}