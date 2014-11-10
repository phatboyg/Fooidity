namespace Fooidity.Management.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class ManageCodeFeatureViewModel
    {
        [Required]
        public string ApplicationId { get; set; }

        [Required]
        public Uri CodeFeatureId { get; set; }
    }
}