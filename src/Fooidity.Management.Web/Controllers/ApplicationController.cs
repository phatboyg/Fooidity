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
        readonly ICommandHandler<ICreateApplication, IUserOrganizationApplication> _createApplication;
        readonly ICommandHandler<ICreateApplicationKey, IOrganizationApplicationKey> _createApplicationKey;
        readonly ICommandHandler<IUpdateApplicationCodeFeatureState> _updateApplicationCodeFeatureState;
        readonly IQueryHandler<IGetApplication, IUserOrganizationApplication> _getApplication;
        readonly IQueryHandler<IListApplications, IEnumerable<IUserOrganizationApplication>> _getApplications;
        readonly IQueryHandler<IListApplicationCodeFeatures, IEnumerable<ICodeFeatureState>> _listApplicationCodeFeatures;
        readonly IQueryHandler<IListApplicationKeys, IEnumerable<IOrganizationApplicationKey>> _listApplicationKeys;
        readonly IQueryHandler<IListOrganizations, IEnumerable<IOrganization>> _listOrganizations;

        public ApplicationController(IQueryHandler<IListApplications, IEnumerable<IUserOrganizationApplication>> getApplications,
            IQueryHandler<IListOrganizations, IEnumerable<IOrganization>> listOrganizations,
            ICommandHandler<ICreateApplication, IUserOrganizationApplication> createApplication,
            IQueryHandler<IGetApplication, IUserOrganizationApplication> getApplication,
            IQueryHandler<IListApplicationKeys, IEnumerable<IOrganizationApplicationKey>> listApplicationKeys,
            ICommandHandler<ICreateApplicationKey, IOrganizationApplicationKey> createApplicationKey,
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
            IEnumerable<IUserOrganizationApplication> results =
                await _getApplications.Execute(new ListApplications(User.Identity.GetUserId()), cancellationToken);

            return View(results.Select(x => new ApplicationViewModel
            {
                Id = x.ApplicationId,
                Name = x.ApplicationName,
                OrganizationId = x.OrganizationId,
                OrganizationName = x.OrganizationName,
            }));
        }

        public async Task<ActionResult> Details(string id, CancellationToken cancellationToken)
        {
            var userId = User.Identity.GetUserId();

            IUserOrganizationApplication application = 
                await _getApplication.Execute(new GetApplication(userId, id), cancellationToken);

            IEnumerable<IOrganizationApplicationKey> applicationKeys =
                await _listApplicationKeys.Execute(new ListApplicationKeys(userId, id), cancellationToken);

            IEnumerable<ICodeFeatureState> codeFeatures =
                await _listApplicationCodeFeatures.Execute(new ListApplicationCodeFeatures(userId, id),
                    cancellationToken);

            return View(new ApplicationViewModel
            {
                Id = application.ApplicationId,
                Name = application.ApplicationName,
                OrganizationId = application.OrganizationId,
                OrganizationName = application.OrganizationName,
                Keys = applicationKeys.Select(x => x.Key).ToList(),
                Features = codeFeatures.Select(x => new CodeFeatureStateViewModel
                {
                    CodeFeatureId = new CodeFeatureId(x.CodeFeatureId),
                    Enabled = x.Enabled,
                    LastUpdated = x.LastUpdated,
                }).ToList(),
            });
        }

        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            IEnumerable<IOrganization> results =
                await _listOrganizations.Execute(new ListOrganizations(User.Identity.GetUserId()), cancellationToken);

            return View(new ApplicationViewModel
            {
                Organizations = results.Select(x => new OrganizationViewModel {Id = x.OrganizationId, Name = x.OrganizationName}).ToList(),
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                ICreateApplication command = new CreateApplication(User.Identity.GetUserId(), model.OrganizationId, model.Name, DateTime.UtcNow, Guid.NewGuid());

                IUserOrganizationApplication application = await _createApplication.Execute(command, cancellationToken);

                return RedirectToAction("Details", new {id = application.ApplicationId});
            }

            return View();
        }

        public async Task<ActionResult> CreateKey(CreateApplicationKeyViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateApplicationKey(User.Identity.GetUserId(), model.OrganizationId, model.ApplicationId, DateTime.UtcNow,
                    Guid.NewGuid());

                IOrganizationApplicationKey key = await _createApplicationKey.Execute(command, cancellationToken);

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
    }
}