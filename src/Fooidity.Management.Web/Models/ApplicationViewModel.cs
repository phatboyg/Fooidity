namespace Fooidity.Management.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;


    public class ApplicationViewModel
    {
        [Display(Name = "Application Id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string OrganizationId { get; set; }

        [Display(Name = "Organization")]
        public string OrganizationName { get; set; }

        public List<string> Keys { get; set; }

        public List<OrganizationViewModel> Organizations { get; set; }

        public IEnumerable<SelectListItem> OrganizationItems
        {
            get { return Organizations.Select(x => new SelectListItem {Value = x.Id, Text = x.Name}); }
        }

        public IEnumerable<CodeFeatureStateViewModel> Features { get; set; }
    }
}