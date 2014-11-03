namespace Fooidity.Management.AzureIntegration.Commands
{
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Fooidity.AzureIntegration;
    using Management.Commands;
    using Management.Queries;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;
    using UserStore;


    public class CreateApplicationKeyCommandHandler :
        ICommandHandler<CreateApplicationKey, OrganizationApplicationKey>
    {
        readonly IQueryHandler<GetApplication, UserOrganizationApplication> _getApplication;
        readonly AzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateApplicationKeyCommandHandler(ICloudTableProvider tableProvider, AzureManagementSettings settings,
            IQueryHandler<GetApplication, UserOrganizationApplication> getApplication)
        {
            _tableProvider = tableProvider;
            _getApplication = getApplication;
            _settings = settings;
        }

        public async Task<OrganizationApplicationKey> Execute(CreateApplicationKey command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            GetApplication query = new GetApplicationQuery(command.UserId, command.ApplicationId);

            UserOrganizationApplication application = await _getApplication.Execute(query, cancellationToken);

            CloudTable appKeyTable = _tableProvider.GetTable(_settings.OrganizationApplicationKeyTableName);

            string key = GenerateKey();

            var appKeyEntity = new OrganizationApplicationKeyEntity(key, application.OrganizationId, application.OrganizationName, command.ApplicationId,
                application.ApplicationName, command.Timestamp);

            await appKeyTable.ExecuteAsync(TableOperation.Insert(appKeyEntity), cancellationToken);

            var indexEntity = new KeyOrganizationApplicationIndexEntity(key, application.OrganizationId, application.OrganizationName,
                application.ApplicationId, application.ApplicationName, command.Timestamp);

            CloudTable indexTable = _tableProvider.GetTable(_settings.KeyOrganizationApplicationIndexTableName);

            await indexTable.ExecuteAsync(TableOperation.Insert(indexEntity), cancellationToken);

            return appKeyEntity;
        }

        string GenerateKey()
        {
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var data = new byte[2048];
                cryptoServiceProvider.GetBytes(data);

                return data.ToSha256();
            }
        }


        class GetApplicationQuery :
            GetApplication
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
    }
}