namespace Fooidity.Management.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Models;


    /// <summary>
    /// Features identify code that is switched
    /// </summary>
    [RoutePrefix("api/feature")]
    public class CodeFeatureController :
        ApiController
    {
        readonly ICommandHandler<UpdateCodeFeatureState> _updateCommandHandler;

        public CodeFeatureController(ICommandHandler<UpdateCodeFeatureState> updateCommandHandler)
        {
            _updateCommandHandler = updateCommandHandler;
        }

        [HttpPost]
        [Route("{codeFeatureId}/enable")]
        public async Task<CodeFeatureModel> Enable(string codeFeatureId)
        {
            var updateCommand = new UpdateCommand(codeFeatureId, true);

            await _updateCommandHandler.Execute(updateCommand);

            return new CodeFeatureModel
            {
                CodeFeatureId = updateCommand.CodeFeatureId,
                Enabled = updateCommand.Enabled,
            };
        }

        [HttpPost]
        [Route("{codeFeatureId}/disable")]
        public async Task<CodeFeatureModel> Disable(string codeFeatureId)
        {
            var updateCommand = new UpdateCommand(codeFeatureId, false);

            await _updateCommandHandler.Execute(updateCommand);

            return new CodeFeatureModel
            {
                CodeFeatureId = updateCommand.CodeFeatureId,
                Enabled = updateCommand.Enabled,
            };
        }


        class UpdateCommand :
            UpdateCodeFeatureState
        {
            readonly CodeFeatureId _codeFeatureId;
            readonly Guid _commandId;
            readonly bool _enabled;
            readonly DateTime _timestamp;

            public UpdateCommand(string codeFeatureId, bool enabled)
            {
                _codeFeatureId = new CodeFeatureId(codeFeatureId);
                _enabled = enabled;

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

            public CodeFeatureId CodeFeatureId
            {
                get { return _codeFeatureId; }
            }

            public bool Enabled
            {
                get { return _enabled; }
            }
        }


//        public IEnumerable<CodeFeatureModel> Get()
//        {
//            return new[] {new CodeFeatureModel {CodeFeatureId = CodeFeatureMetadata<Feature_NewScreen>.Id}};
//        }
//
//        public CodeFeatureModel Get(string id)
//        {
//            return new CodeFeatureModel {CodeFeatureId = new Uri(id)};
//        }
//
//        public void Post([FromBody] CodeFeatureModel feature)
//        {
//        }
//
//        public void Put(string id, [FromBody] CodeFeatureModel feature)
//        {
//        }
//
//        public void Delete(string id)
//        {
//        }
    }
}