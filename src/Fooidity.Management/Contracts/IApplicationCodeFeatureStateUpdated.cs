namespace Fooidity.Management.Contracts
{
    using System;


    public interface IApplicationCodeFeatureStateUpdated
    {
        /// <summary>
        /// Generated EventId
        /// </summary>
        Guid EventId { get; }

        /// <summary>
        /// When the feature state was updated
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The identifier of the command that enabled the context code feature
        /// </summary>
        Guid? CommandId { get; }

        /// <summary>
        /// The applicationId of the code feature state that was updated
        /// </summary>
        string ApplicationId { get; }

        /// <summary>
        /// The FeatureId that was updated
        /// </summary>
        Uri CodeFeatureId { get; }
    }
}