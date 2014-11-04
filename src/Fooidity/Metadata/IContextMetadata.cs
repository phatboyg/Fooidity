namespace Fooidity.Metadata
{
    public interface IContextMetadata<TContext>
    {
        ContextId Id { get; }
    }
}