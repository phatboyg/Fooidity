namespace Fooidity.Management.AzureIntegration.CommandHandlers
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
        ICommandHandler<ICreateApplicationKey, IOrganizationApplicationKey>
    {
        readonly IQueryHandler<IGetApplication, IUserOrganizationApplication> _getApplication;
        readonly IAzureManagementSettings _settings;
        readonly ICloudTableProvider _tableProvider;

        public CreateApplicationKeyCommandHandler(ICloudTableProvider tableProvider, IAzureManagementSettings settings,
            IQueryHandler<IGetApplication, IUserOrganizationApplication> getApplication)
        {
            _tableProvider = tableProvider;
            _getApplication = getApplication;
            _settings = settings;
        }

        public async Task<IOrganizationApplicationKey> Execute(ICreateApplicationKey command,
            CancellationToken cancellationToken = new CancellationToken())
        {
            IUserOrganizationApplication application =
                await _getApplication.Execute(new GetApplication(command.UserId, command.ApplicationId), cancellationToken);

            CloudTable keyTable = _tableProvider.GetTable(_settings.OrganizationApplicationKeyTableName);

            string key = GenerateKey();

            var keyEntity = new OrganizationApplicationKeyEntity(key, application.OrganizationId, application.OrganizationName,
                command.ApplicationId,
                application.ApplicationName, command.Timestamp);

            await keyTable.ExecuteAsync(TableOperation.Insert(keyEntity), cancellationToken);

            var indexEntity = new KeyOrganizationApplicationIndexEntity(key, application.OrganizationId, application.OrganizationName,
                application.ApplicationId, application.ApplicationName, command.Timestamp);

            CloudTable indexTable = _tableProvider.GetTable(_settings.KeyOrganizationApplicationIndexTableName);

            await indexTable.ExecuteAsync(TableOperation.Insert(indexEntity), cancellationToken);

            return keyEntity;
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
    }
}