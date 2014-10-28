namespace Fooidity.Metadata
{
    using System;


    public interface IContextMetadata<TContext>
    {
        ContextId Id { get; }

        Type ContextType { get; }
    }
}