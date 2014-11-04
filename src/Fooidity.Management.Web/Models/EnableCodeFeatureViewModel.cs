namespace Fooidity.Management.Web.Models
{
    using System.ComponentModel.DataAnnotations;


    public class EnableCodeFeatureViewModel
    {
        [Required]
        public string ApplicationId { get; set; }

        [Required]
        public string CodeFeatureId { get; set; }
    }
}