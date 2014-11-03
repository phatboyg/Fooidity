namespace Fooidity.Management.Web.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;


    public class ApplicationViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OrganizationId { get; set; }

        public List<string> Keys { get; set; }

        public List<OrganizationViewModel> Organizations { get; set; }

        public IEnumerable<SelectListItem> OrganizationItems
        {
            get { return Organizations.Select(x => new SelectListItem {Value = x.Id, Text = x.Name}); }
        }
    }
}