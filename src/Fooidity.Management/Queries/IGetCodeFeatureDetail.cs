namespace Fooidity.Management.Queries
{
    using System;


    public interface IGetCodeFeatureDetail
    {
        string UserId { get; }

        string ApplicationId { get; }

        Uri CodeFeatureId { get; }
    }
}