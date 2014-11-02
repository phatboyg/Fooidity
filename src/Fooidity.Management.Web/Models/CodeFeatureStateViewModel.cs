namespace Fooidity.Management.Web.Models
{
    using System;


    public class CodeFeatureStateViewModel
    {
        public CodeFeatureId CodeFeatureId { get; set; }
        public bool Enabled { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}