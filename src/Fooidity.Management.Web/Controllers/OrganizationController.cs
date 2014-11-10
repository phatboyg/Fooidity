namespace Fooidity.Management.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Commands;
    using Management.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Queries;


    [Authorize]
    public class OrganizationController :
        Controller
    {
        readonly ICommandHandler<ICreateOrganization, IOrganization> _createOrganization;
        readonly IQueryHandler<IGetOrganization, IOrganization> _getOrganization;
        readonly IQueryHandler<IListOrganizations, IEnumerable<IOrganization>> _listOrganizations;

        public OrganizationController(ICommandHandler<ICreateOrganization, IOrganization> createOrganization,
            IQueryHandler<IGetOrganization, IOrganization> getOrganization,
            IQueryHandler<IListOrganizations, IEnumerable<IOrganization>> listOrganizations)
        {
            _createOrganization = createOrganization;
            _getOrganization = getOrganization;
            _listOrganizations = listOrganizations;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            IEnumerable<IOrganization> results =
                await _listOrganizations.Execute(new ListOrganizations(User.Identity.GetUserId()), cancellationToken);

            return View(results.Select(x => new OrganizationViewModel
            {
                Id = x.OrganizationId,
                Name = x.OrganizationName,
            }));
        }

        public async Task<ActionResult> Details(string id, CancellationToken cancellationToken)
        {
            IOrganization organization =
                await _getOrganization.Execute(new GetOrganization(User.Identity.GetUserId(), id), cancellationToken);

            return View(new OrganizationViewModel
            {
                Id = organization.OrganizationId,
                Name = organization.OrganizationName,
                CreatedByUserId = organization.CreatedByUserId,
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrganizationViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateOrganization(User.Identity.GetUserId(), model.Name);

                IOrganization organization = await _createOrganization.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = organization.OrganizationId});
            }

            return View();
        }
    }
}