namespace Fooidity.Management.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Fooidity.Contracts;
    using Models;


    /// <summary>
    /// This controller is for managing local code features only, and is not part of the Azure property.
    /// Not deprecated, but left as an example for now.
    /// </summary>
    public class FeaturesController :
        Controller
    {
        readonly IQueryHandler<QueryCodeFeatureState, IEnumerable<ICodeFeatureState>> _queryHandler;
        readonly ICommandHandler<UpdateCodeFeatureState> _updateHandler;

        public FeaturesController(IQueryHandler<QueryCodeFeatureState, IEnumerable<ICodeFeatureState>> queryHandler,
            ICommandHandler<UpdateCodeFeatureState> updateHandler)
        {
            _queryHandler = queryHandler;
            _updateHandler = updateHandler;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<ICodeFeatureState> results = await _queryHandler.Execute(new Query(), cancellationToken);

            return View(results.Select(x => new CodeFeatureStateViewModel
            {
                CodeFeatureId = new CodeFeatureId(x.CodeFeatureId),
                Enabled = x.Enabled,
                LastUpdated = x.LastUpdated,
            }));
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Enable(string codeFeatureId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var id = new CodeFeatureId(codeFeatureId);

            await _updateHandler.Execute(new UpdateCommand(id, true), cancellationToken);

            return Redirect("Index");
        }

        public async Task<ActionResult> Disable(string codeFeatureId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var id = new CodeFeatureId(codeFeatureId);

            await _updateHandler.Execute(new UpdateCommand(id, false), cancellationToken);

            return Redirect("Index");
        }

        public ActionResult Details()
        {
            return View("Details", new CodeFeatureStateViewModel());
        }


        class Query :
            QueryCodeFeatureState
        {
        }


        class UpdateCommand :
            UpdateCodeFeatureState
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Guid _commandId;
            readonly bool _enabled;
            readonly DateTime _timestamp;

            public UpdateCommand(CodeFeatureId codeFeatureId, bool enabled)
            {
                _commandId = Guid.NewGuid();
                _timestamp = DateTime.UtcNow;

                _codeFeatureId = codeFeatureId;
                _enabled = enabled;
            }

            public Guid CommandId
            {
                get { return _commandId; }
            }

            public DateTime Timestamp
            {
                get { return _timestamp; }
            }

            public CodeFeatureId CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }
    }
}