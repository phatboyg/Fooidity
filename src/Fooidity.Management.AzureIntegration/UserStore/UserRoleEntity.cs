namespace Fooidity.Management.AzureIntegration.UserStore
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserRoleEntity :
        TableEntity,
        IRole
    {
        public UserRoleEntity()
        {
        }

        public UserRoleEntity(string userId, string name)
        {
            Id = Guid.NewGuid().ToByteArray().ToBase32();

            UserId = userId;
            Name = name;

            PartitionKey = UserId;
            RowKey = Name.ToSha256();
        }

        public string UserId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}