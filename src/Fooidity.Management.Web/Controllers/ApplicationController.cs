namespace Fooidity.Management.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Commands;
    using Fooidity.Contracts;
    using Management.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Queries;


    [Authorize]
    public class ApplicationController :
        Controller
    {
        readonly ICommandHandler<CreateApplication, UserOrganizationApplication> _createApplication;
        readonly ICommandHandler<CreateApplicationKey, OrganizationApplicationKey> _createApplicationKey;
        readonly ICommandHandler<IUpdateApplicationCodeFeatureState> _updateApplicationCodeFeatureState;
        readonly IQueryHandler<GetApplication, UserOrganizationApplication> _getApplication;
        readonly IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>> _getApplications;
        readonly IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> _listApplicationCodeFeatures;
        readonly IQueryHandler<ListApplicationKeys, IEnumerable<OrganizationApplicationKey>> _listApplicationKeys;
        readonly IQueryHandler<ListOrganizations, IEnumerable<Organization>> _listOrganizations;

        public ApplicationController(IQueryHandler<ListApplications, IEnumerable<UserOrganizationApplication>> getApplications,
            IQueryHandler<ListOrganizations, IEnumerable<Organization>> listOrganizations,
            ICommandHandler<CreateApplication, UserOrganizationApplication> createApplication,
            IQueryHandler<GetApplication, UserOrganizationApplication> getApplication,
            IQueryHandler<ListApplicationKeys, IEnumerable<OrganizationApplicationKey>> listApplicationKeys,
            ICommandHandler<CreateApplicationKey, OrganizationApplicationKey> createApplicationKey,
            IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> listApplicationCodeFeatures, ICommandHandler<IUpdateApplicationCodeFeatureState> updateApplicationCodeFeatureState)
        {
            _getApplications = getApplications;
            _listOrganizations = listOrganizations;
            _createApplication = createApplication;
            _getApplication = getApplication;
            _listApplicationKeys = listApplicationKeys;
            _createApplicationKey = createApplicationKey;
            _listApplicationCodeFeatures = listApplicationCodeFeatures;
            _updateApplicationCodeFeatureState = updateApplicationCodeFeatureState;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<UserOrganizationApplication> results =
                await _getApplications.Execute(new ListApplicationsQuery(User.Identity.GetUserId()), cancellationToken);

            return View(results.Select(x => new ApplicationViewModel
            {
                Id = x.ApplicationId,
                Name = x.ApplicationName,
                OrganizationId = x.OrganizationId,
            }));
        }

        public async Task<ActionResult> Details(string id, CancellationToken cancellationToken)
        {
            var query = new GetApplicationQuery(User.Identity.GetUserId(), id);

            UserOrganizationApplication application = await _getApplication.Execute(query, cancellationToken);

            IEnumerable<OrganizationApplicationKey> applicationKeys = await _listApplicationKeys.Execute(query, cancellationToken);

            IEnumerable<ICodeFeatureState> codeFeatures =
                await _listApplicationCodeFeatures.Execute(new ListApplicationCodeFeatures(User.Identity.GetUserId(), id),
                    cancellationToken);

            return View(new ApplicationViewModel
            {
                Id = application.ApplicationId,
                Name = application.ApplicationName,
                OrganizationId = application.OrganizationId,
                Keys = applicationKeys.Select(x => x.Key).ToList(),
                Features = codeFeatures.ToList(),
            });
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

        public async Task<ActionResult> CreateKey(CreateApplicationKeyViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateApplicationKeyCommand(User.Identity.GetUserId(), model.OrganizationId, model.ApplicationId);

                OrganizationApplicationKey key = await _createApplicationKey.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = model.ApplicationId});
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Enable(EnableCodeFeatureViewModel model, CancellationToken cancellationToken)
        {
            return await UpdateCodeFeatureState(model, cancellationToken, true);
        }

        public async Task<ActionResult> Disable(EnableCodeFeatureViewModel model, CancellationToken cancellationToken)
        {
            return await UpdateCodeFeatureState(model, cancellationToken, false);
        }

        async Task<ActionResult> UpdateCodeFeatureState(EnableCodeFeatureViewModel model, CancellationToken cancellationToken, bool enabled)
        {
            if (ModelState.IsValid)
            {
                var codeFeatureId = new Uri(model.CodeFeatureId);
                var timestamp = DateTime.UtcNow;

                var command = new UpdateApplicationCodeFeatureState(model.ApplicationId, codeFeatureId, enabled, timestamp);

                await _updateApplicationCodeFeatureState.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = model.ApplicationId});
            }

            return RedirectToAction("Index");
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


        class CreateApplicationKeyCommand :
            CreateApplicationKey
        {
            readonly string _applicationId;
            readonly Guid _commandId;
            readonly string _organizationId;
            readonly DateTime _timestamp;
            readonly string _userId;

            public CreateApplicationKeyCommand(string userId, string organizationId, string applicationId)
            {
                _commandId = Guid.NewGuid();
                _timestamp = DateTime.UtcNow;

                _userId = userId;
                _organizationId = organizationId;
                _applicationId = applicationId;
            }

            public string ApplicationId
            {
                get { return _applicationId; }
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
        }


        class GetApplicationQuery :
            GetApplication,
            ListApplicationKeys
        {
            readonly string _applicationId;
            readonly string _userId;

            public GetApplicationQuery(string userId, string applicationId)
            {
                _userId = userId;
                _applicationId = applicationId;
            }

            public string UserId
            {
                get { return _userId; }
            }

            public string ApplicationId
            {
                get { return _applicationId; }
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