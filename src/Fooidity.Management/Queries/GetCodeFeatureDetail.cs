namespace Fooidity.Management.Queries
{
    using System;


    public class GetCodeFeatureDetail :
        IGetCodeFeatureDetail
    {
        public GetCodeFeatureDetail(string userId, string applicationId, Uri codeFeatureId)
        {
            UserId = userId;
            ApplicationId = applicationId;
            CodeFeatureId = codeFeatureId;
        }

        public string UserId { get; set; }
        public string ApplicationId { get; set; }
        public Uri CodeFeatureId { get; set; }
    }
}