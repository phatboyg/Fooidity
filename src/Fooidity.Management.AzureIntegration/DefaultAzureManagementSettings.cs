namespace Fooidity.Management.AzureIntegration
{
    public class DefaultAzureManagementSettings :
        AzureManagementSettings
    {
        public string UserApplicationIndexTableName
        {
            get { return "userAppIndex"; }
        }

        public string OrganizationApplicationKeyTableName
        {
            get { return "orgAppKey"; }
        }

        public string KeyOrganizationApplicationIndexTableName
        {
            get { return "keyApp"; }
        }

        public string ApplicationCodeFeatureTableName
        {
            get { return "appCodeFeature"; }
        }

        public string ApplicationTableName
        {
            get { return "app"; }
        }

        public string OrganizationTableName
        {
            get { return "org"; }
        }

        public string UserTableName
        {
            get { return "authUser"; }
        }

        public string OrganizationUserTableName
        {
            get { return "orgUser"; }
        }

        public string UserOrganizationIndexTableName
        {
            get { return "userOrgIndex"; }
        }

        public string OrganizationApplicationIndexTableName
        {
            get { return "orgAppIndex"; }
        }
    }
}