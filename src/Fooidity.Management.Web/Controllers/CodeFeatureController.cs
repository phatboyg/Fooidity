namespace Fooidity.Management.Web.Controllers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Management.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Queries;


    [Authorize]
    public class CodeFeatureController :
        Controller
    {
        readonly IQueryHandler<IGetCodeFeatureDetail, ICodeFeatureDetail> _getCodeFeatureDetail;

        public CodeFeatureController(IQueryHandler<IGetCodeFeatureDetail, ICodeFeatureDetail> getCodeFeatureDetail)
        {
            _getCodeFeatureDetail = getCodeFeatureDetail;
        }

        public async Task<ActionResult> Details(ManageCodeFeatureViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var getCodeFeatureDetail = new GetCodeFeatureDetail(User.Identity.GetUserId(), model.ApplicationId, model.CodeFeatureId);

                ICodeFeatureDetail detail = await _getCodeFeatureDetail.Execute(getCodeFeatureDetail, cancellationToken);

                return View(new CodeFeatureDetailViewModel
                {
                    ApplicationId = detail.ApplicationId,
                    ApplicationName = detail.ApplicationName,
                    CodeFeatureId = detail.CodeFeatureId,
                    CurrentState = new CodeFeatureStateViewModel
                    {
                        CodeFeatureId = new CodeFeatureId(detail.CurrentState.CodeFeatureId),
                        Enabled = detail.CurrentState.Enabled,
                        LastUpdated = detail.CurrentState.LastUpdated
                    },
                    StateHistory = detail.StateHistory.Select(x => new CodeFeatureStateViewModel
                    {
                        CodeFeatureId = new CodeFeatureId(x.CodeFeatureId),
                        Enabled = x.Enabled,
                        LastUpdated = x.LastUpdated
                    }).ToArray(),
                });
            }

            return RedirectToAction("Index", "Application");
        }
    }
}