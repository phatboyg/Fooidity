namespace Fooidity.Management.Web.Controllers
{
    using System;
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
        readonly ICommandHandler<CreateOrganization, Organization> _createOrganization;
        readonly IQueryHandler<GetOrganization, Organization> _getOrganization;
        readonly IQueryHandler<ListOrganizations, IEnumerable<Organization>> _listOrganizations;

        public OrganizationController(ICommandHandler<CreateOrganization, Organization> createOrganization,
            IQueryHandler<GetOrganization, Organization> getOrganization,
            IQueryHandler<ListOrganizations, IEnumerable<Organization>> listOrganizations)
        {
            _createOrganization = createOrganization;
            _getOrganization = getOrganization;
            _listOrganizations = listOrganizations;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            IEnumerable<Organization> results =
                await _listOrganizations.Execute(new ListOrganizationsQuery(User.Identity.GetUserId()), cancellationToken);

            return View(results.Select(x => new OrganizationViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }));
        }

        public async Task<ActionResult> Details(string id, CancellationToken cancellationToken)
        {
            Organization organization =
                await _getOrganization.Execute(new GetOrganizationQuery(User.Identity.GetUserId(), id), cancellationToken);

            return View(new OrganizationViewModel
            {
                Id = organization.Id,
                Name = organization.Name,
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
                var command = new CreateOrganizationCommand(model.Name, User.Identity.GetUserId());

                Organization organization = await _createOrganization.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = organization.Id});
            }

            return View();
        }


        class CreateOrganizationCommand :
            CreateOrganization
        {
            readonly Guid _commandId;
            readonly string _organizationName;
            readonly DateTime _timestamp;
            readonly string _userId;

            public CreateOrganizationCommand(string organizationName, string userId)
            {
                _organizationName = organizationName;
                _userId = userId;

                _commandId = Guid.NewGuid();
                _timestamp = DateTime.UtcNow;
            }

            public Guid CommandId
            {
                get { return _commandId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public string UserId
            {
                get { return _userId; }
            }

            public string OrganizationName
            {
                get { return _organizationName; }
            }
        }


        class GetOrganizationQuery :
            GetOrganization
        {
            readonly string _organizationId;
            readonly string _userId;

            public GetOrganizationQuery(string userId, string organizationId)
            {
                _userId = userId;
                _organizationId = organizationId;
            }

            public string UserId
            {
                get { return _userId; }
            }

            public string OrganizationId
            {
                get { return _organizationId; }
            }
        }


        class ListOrganizationsQuery :
            ListOrganizations
        {
            readonly string _userId;

            public ListOrganizationsQuery(string userId)
            {
                _userId = userId;
            }

            public string UserId
            {
                get { return _userId; }
            }
        }
    }
}