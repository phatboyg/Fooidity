namespace Fooidity.Management.AzureIntegration.UserStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNet.Identity;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;


    public class UserEntity :
        TableEntity,
        IUser
    {
        List<UserClaimEntity> _claims;
        List<UserLoginEntity> _logins;
        List<UserRoleEntity> _roles;

        public UserEntity()
        {
            Id = Guid.NewGuid().ToByteArray().ToBase32();

            SetPartitionAndRowKey();
        }

        public UserEntity(string userName)
            : this()
        {
            UserName = userName;
            SetPartitionAndRowKey();
        }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset LockoutEndDate { get; set; }

        public int AccessFailedCount { get; set; }

        public bool LockoutEnabled { get; set; }

        [NonSerializedTableStore]
        internal Func<IEnumerable<UserRoleEntity>> LazyRolesEvaluator { get; set; }

        [NonSerializedTableStore]
        public ICollection<UserRoleEntity> Roles
        {
            get
            {
                if (_roles == null)
                {
                    if (LazyRolesEvaluator != null)
                        _roles = new List<UserRoleEntity>(LazyRolesEvaluator());
                    else
                        _roles = new List<UserRoleEntity>();
                }
                return _roles;
            }
        }

        [NonSerializedTableStore]
        internal Func<IEnumerable<UserClaimEntity>> LazyClaimsEvaluator { get; set; }

        [NonSerializedTableStore]
        public ICollection<UserClaimEntity> Claims
        {
            get
            {
                if (_claims == null)
                {
                    if (LazyClaimsEvaluator != null)
                        _claims = new List<UserClaimEntity>(LazyClaimsEvaluator());
                    else
                        _claims = new List<UserClaimEntity>();
                }
                return _claims;
            }
        }

        [NonSerializedTableStore]
        internal Func<IEnumerable<UserLoginEntity>> LazyLoginEvaluator { get; set; }

        [NonSerializedTableStore]
        public ICollection<UserLoginEntity> Logins
        {
            get
            {
                if (_logins == null)
                {
                    if (LazyLoginEvaluator != null)
                        _logins = new List<UserLoginEntity>(LazyLoginEvaluator());
                    else
                        _logins = new List<UserLoginEntity>();
                }
                return _logins;
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public void SetPartitionAndRowKey()
        {
            PartitionKey = Id;
            RowKey = Id;
        }

        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            IDictionary<string, EntityProperty> entityProperties = base.WriteEntity(operationContext);
            PropertyInfo[] objectProperties = GetType().GetProperties();

            foreach (PropertyInfo property in from property in objectProperties
                let nonSerializedAttributes = property.GetCustomAttributes(typeof(NonSerializedTableStoreAttribute), false)
                where nonSerializedAttributes.Length > 0
                select property)
                entityProperties.Remove(property.Name);

            return entityProperties;
        }
    }
}