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
    public class ApplicationController :
        Controller
    {
        readonly ICommandHandler<CreateApplication, UserOrganizationApplication> _createApplication;
        readonly IQueryHandler<ListOrganizations, IEnumerable<Organization>> _listOrganizations;
        readonly IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>> _queryHandler;

        public ApplicationController(IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>> queryHandler,
            IQueryHandler<ListOrganizations, IEnumerable<Organization>> listOrganizations,
            ICommandHandler<CreateApplication, UserOrganizationApplication> createApplication)
        {
            _queryHandler = queryHandler;
            _listOrganizations = listOrganizations;
            _createApplication = createApplication;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<UserOrganizationApplication> results =
                await _queryHandler.Execute(new ListApplicationsQuery(User.Identity.GetUserId()), cancellationToken);

            return View(results.Select(x => new ApplicationViewModel
            {
                Id = x.ApplicationId,
                Name = x.ApplicationName,
                OrganizationId = x.OrganizationId,
            }));
        }

        public ActionResult Details(string id)
        {
            return View();
        }

        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            IEnumerable<Organization> results =
                await _listOrganizations.Execute(new ListOrganizationsQuery(User.Identity.GetUserId()), cancellationToken);

            return View(new ApplicationViewModel
            {
                Organizations = results.Select(x => new OrganizationViewModel {Id = x.Id, Name = x.Name}).ToList(),
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                CreateApplication command = new CreateApplicationCommand(User.Identity.GetUserId(), model.OrganizationId, model.Name);

                UserOrganizationApplication application = await _createApplication.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = application.ApplicationId});
            }

            return View();
        }


        class CreateApplicationCommand :
            CreateApplication
        {
            readonly string _applicationName;
            readonly Guid _commandId;
            readonly string _organizationId;
            readonly DateTime _timestamp;
            readonly string _userId;

            public CreateApplicationCommand(string userId, string organizationId, string applicationName)
            {
                _commandId = Guid.NewGuid();
                _timestamp = DateTime.UtcNow;

                _userId = userId;
                _organizationId = organizationId;
                _applicationName = applicationName;
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

            public string OrganizationId
            {
                get { return _organizationId; }
            }

            public string ApplicationName
            {
                get { return _applicationName; }
            }
        }


        class ListApplicationsQuery :
            ListApplications
        {
            readonly string _userId;

            public ListApplicationsQuery(string userId)
            {
                _userId = userId;
            }

            public string UserId
            {
                get { return _userId; }
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