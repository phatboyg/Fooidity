namespace Fooidity.Management.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class CodeFeatureStateViewModel
    {
        [Display(Name = "Code Feature Id")]
        public CodeFeatureId CodeFeatureId { get; set; }
        
        public bool Enabled { get; set; }

        [Display(Name = "Updated")]
        public DateTime LastUpdated { get; set; }
    }
}