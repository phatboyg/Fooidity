namespace Fooidity.Management.AzureIntegration.UserStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Fooidity.AzureIntegration;
    using Microsoft.AspNet.Identity;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;


    public class TableUserStore<T> :
        IUserLoginStore<T>,
        IUserClaimStore<T>,
        IUserRoleStore<T>,
        IUserPasswordStore<T>,
        IUserSecurityStampStore<T>,
        IUserStore<T>,
        //IQueryableUserStore<T>,
        IUserEmailStore<T>,
        IUserPhoneNumberStore<T>,
        IUserTwoFactorStore<T, string>,
        IUserLockoutStore<T, string>
        where T : UserEntity, new()
    {
        readonly CloudTable _userClaimTable;
        readonly CloudTable _userLoginProviderKeyIndexTable;
        readonly CloudTable _userLoginTable;
        readonly DateTimeOffset _minTableStoreDate = new DateTimeOffset(1753, 1, 1, 0, 0, 0, TimeSpan.FromHours(0));
        readonly CloudTable _userRoleTable;
        readonly CloudTable _userEmailIndexTable;
        readonly CloudTable _userNameIndexTable;
        readonly CloudTable _userTable;

        public TableUserStore(ICloudTableProvider tableProvider,
            string userTableName,
            string userNameIndexTableName,
            string userLoginTableName,
            string userLoginProviderKeyIndexTableName,
            string userClaimTableName,
            string userRoleTableName,
            string userEmailIndexTableName)
        {
            _userTable = tableProvider.GetTable(userTableName);
            _userLoginTable = tableProvider.GetTable(userLoginTableName);
            _userClaimTable = tableProvider.GetTable(userClaimTableName);
            _userRoleTable = tableProvider.GetTable(userRoleTableName);
            _userNameIndexTable = tableProvider.GetTable(userNameIndexTableName);
            _userLoginProviderKeyIndexTable = tableProvider.GetTable(userLoginProviderKeyIndexTableName);
            _userEmailIndexTable = tableProvider.GetTable(userEmailIndexTableName);
        }

        public TableUserStore(ICloudTableProvider tableProvider)
            : this(tableProvider, "authUser", "authUserNameIndex", "authUserLogin", "authUserLoginProviderKeyIndex", "authUserClaim", "authUserRole", "authUserEmailIndex")
        {
        }

        public Task<IList<Claim>> GetClaimsAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException();

            TableQuery<UserClaimEntity> query = new TableQuery<UserClaimEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id));

            return ExecuteQueryAsync(_userClaimTable, query, x => new Claim(x.ClaimType, x.ClaimValue));
        }

        public async Task AddClaimAsync(T user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var tableUserClaim = new UserClaimEntity(user.Id, claim.Type, claim.Value);

            await _userClaimTable.ExecuteAsync(TableOperation.Insert(tableUserClaim));
        }

        public async Task RemoveClaimAsync(T user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var tableUserClaim = new UserClaimEntity(user.Id, claim.Type, claim.Value) {ETag = "*"};

            await _userClaimTable.ExecuteAsync(TableOperation.Delete(tableUserClaim));
        }

        public async Task SetEmailAsync(T user, string email)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("email");

            user.Email = email;
        }

        public Task<string> GetEmailAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.EmailConfirmed);
        }

        public async Task SetEmailConfirmedAsync(T user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.EmailConfirmed = confirmed;
        }

        public async Task<T> FindByEmailAsync(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
                return null;

            TableOperation retrieveIndexOp = TableOperation.Retrieve<UserEmailIndexEntity>(email.ToSha256(), "");
            TableResult indexResult = await _userEmailIndexTable.ExecuteAsync(retrieveIndexOp);
            if (indexResult.Result == null)
                return null;
            var userEmailIndex = (UserEmailIndexEntity)indexResult.Result;
            return await FindByIdAsync(userEmailIndex.UserId);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.LockoutEndDate);
        }

        public Task SetLockoutEndDateAsync(T user, DateTimeOffset lockoutEnd)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (lockoutEnd < _minTableStoreDate)
                lockoutEnd = _minTableStoreDate;
            user.LockoutEndDate = lockoutEnd;
            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            user.AccessFailedCount++;
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            user.AccessFailedCount = 0;
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(T user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            user.LockoutEnabled = enabled;
            return Task.FromResult(0);
        }

        public void Dispose()
        {
        }

        public async Task CreateAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.SetPartitionAndRowKey();

            var userNameIndex = new UserNameIndexEntity(user.UserName.ToSha256(), user.Id);
            TableOperation indexOperation = TableOperation.Insert(userNameIndex);

            try
            {
                await _userNameIndexTable.ExecuteAsync(indexOperation);
            }
            catch (StorageException ex)
            {
                if (ex.RequestInformation.HttpStatusCode == 409)
                    throw new DuplicateUsernameException();

                throw;
            }

            if (!String.IsNullOrWhiteSpace(user.Email))
            {
                var userEmailIndexEntity = new UserEmailIndexEntity(user.Email.ToSha256(), user.Id);
                TableOperation emailIndexOperation = TableOperation.Insert(userEmailIndexEntity);
                try
                {
                    await _userEmailIndexTable.ExecuteAsync(emailIndexOperation);
                }
                catch (StorageException ex)
                {
                    try
                    {
                        userNameIndex.ETag = "*";
                        TableOperation deleteOperation = TableOperation.Delete(userNameIndex);
                        _userNameIndexTable.ExecuteAsync(deleteOperation).Wait();
                    }
                    catch (Exception)
                    {
                        // if we can't delete the index item throw out the exception below
                    }

                    if (ex.RequestInformation.HttpStatusCode == 409)
                        throw new DuplicateEmailException();
                    throw;
                }
            }

            try
            {
                if (user.LockoutEndDate < _minTableStoreDate)
                    user.LockoutEndDate = _minTableStoreDate;

                TableOperation operation = TableOperation.InsertOrReplace(user);
                await _userTable.ExecuteAsync(operation);

                if (user.Logins.Any())
                {
                    var batch = new TableBatchOperation();
                    var loginIndexItems = new List<UserLoginProviderKeyIndexEntity>();
                    foreach (UserLoginEntity login in user.Logins)
                    {
                        login.UserId = user.Id;
                        login.SetPartitionKeyRowKey();
                        batch.InsertOrReplace(login);

                        var loginIndexItem = new UserLoginProviderKeyIndexEntity(user.Id, login.ProviderKey, login.LoginProvider);
                        loginIndexItems.Add(loginIndexItem);
                    }
                    await _userLoginTable.ExecuteBatchAsync(batch);
                    // can't batch the index items as different primary keys
                    foreach (UserLoginProviderKeyIndexEntity loginIndexItem in loginIndexItems)
                        await _userLoginProviderKeyIndexTable.ExecuteAsync(TableOperation.InsertOrReplace(loginIndexItem));
                }
            }
            catch (Exception)
            {
                // attempt to delete the index item - needs work
                userNameIndex.ETag = "*";
                TableOperation deleteOperation = TableOperation.Delete(userNameIndex);
                _userNameIndexTable.ExecuteAsync(deleteOperation).Wait();
                throw;
            }
        }

        public async Task UpdateAsync(T user)
        {
            // assumption here is that a username can't change (if it did we'd need to fix the index)
            if (user == null)
                throw new ArgumentNullException("user");
            user.ETag = "*";
            TableOperation operation = TableOperation.Replace(user);
            await _userTable.ExecuteAsync(operation);
        }

        public async Task DeleteAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            TableOperation operation = TableOperation.Delete(user);
            user.ETag = "*";
            await _userTable.ExecuteAsync(operation);

            //Clean up
            try
            {
                await RemoveFromAllRolesAsync(user);
            }
            catch
            {
            }

            try
            {
                await RemoveAllClaimsAsync(user);
            }
            catch
            {
            }

            try
            {
                await RemoveAllLoginsAsync(user);
            }
            catch
            {
            }

            try
            {
                await RemoveIndices(user);
            }
            catch
            {
            }
        }

        public Task<T> FindByIdAsync(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");
            return Task.Factory.StartNew(() =>
            {
                TableQuery<T> query =
                    new TableQuery<T>().Where(
                        TableQuery.GenerateFilterCondition("PartitionKey",
                            QueryComparisons.Equal, userId)).Take(1);
                IEnumerable<T> results = _userTable.ExecuteQuery(query);
                T result = results.SingleOrDefault();
                if (result != null)
                {
                    result.LazyLoginEvaluator = () =>
                    {
                        Task<IList<UserLoginInfo>> loginInfoTask = GetLoginsAsync(result);
                        loginInfoTask.Wait();
                        IList<UserLoginInfo> loginInfo = loginInfoTask.Result;
                        return loginInfo.Select(x => new UserLoginEntity(result.Id, x.LoginProvider, x.ProviderKey));
                    };
                    result.LazyClaimsEvaluator = () =>
                    {
                        Task<IList<Claim>> claimTask = GetClaimsAsync(result);
                        claimTask.Wait();
                        IList<Claim> loginInfo = claimTask.Result;
                        return loginInfo.Select(x => new UserClaimEntity(result.Id, x.Type, x.Value));
                    };
                    result.LazyRolesEvaluator = () =>
                    {
                        Task<IList<string>> roleTask = GetRolesAsync(result);
                        roleTask.Wait();
                        IList<string> roles = roleTask.Result;
                        return roles.Select(x => new UserRoleEntity(result.Id, x));
                    };
                }

                return result;
            });
        }

        public async Task<T> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            TableQuery<UserNameIndexEntity> indexQuery = new TableQuery<UserNameIndexEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userName.ToSha256())).Take(1);

            IList<UserNameIndexEntity> matches = await ExecuteQueryAsync(_userTable, indexQuery, x => x);
            UserNameIndexEntity userNameIndex = matches.SingleOrDefault();

            if (userNameIndex == null)
                return null;

            TableQuery<T> query = new TableQuery<T>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userNameIndex.UserId)).Take(1);

            return (await ExecuteQueryAsync(_userTable, query, x => x)).SingleOrDefault();
        }

        public async Task AddLoginAsync(T user, UserLoginInfo loginInfo)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (loginInfo == null)
                throw new ArgumentNullException("loginInfo");

            var userLogin = new UserLoginEntity(user.Id, loginInfo.LoginProvider, loginInfo.ProviderKey);
            await _userLoginTable.ExecuteAsync(TableOperation.Insert(userLogin));

            var userLoginProviderKeyIndex = new UserLoginProviderKeyIndexEntity(user.Id, userLogin.ProviderKey, userLogin.LoginProvider);
            await _userLoginProviderKeyIndexTable.ExecuteAsync(TableOperation.InsertOrReplace(userLoginProviderKeyIndex));
        }

        public async Task RemoveLoginAsync(T user, UserLoginInfo loginInfo)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (loginInfo == null)
                throw new ArgumentNullException("loginInfo");

            var userLogin = new UserLoginEntity(user.Id, loginInfo.LoginProvider, loginInfo.ProviderKey)
            {
                ETag = "*"
            };
            await _userLoginTable.ExecuteAsync(TableOperation.Delete(userLogin));

            var userLoginProviderKeyIndex = new UserLoginProviderKeyIndexEntity(user.Id, userLogin.ProviderKey, userLogin.LoginProvider)
            {
                ETag = "*"
            };
            await _userLoginProviderKeyIndexTable.ExecuteAsync(TableOperation.Delete(userLoginProviderKeyIndex));
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            TableQuery<UserLoginEntity> query = new TableQuery<UserLoginEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id)).Take(1);

            return ExecuteQueryAsync(_userLoginTable, query, x => new UserLoginInfo(x.LoginProvider, x.ProviderKey));
        }

        public async Task<T> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var candidateIndex = new UserLoginProviderKeyIndexEntity("", login.ProviderKey, login.LoginProvider);
            TableResult loginProviderKeyIndexResult =
                await
                    _userLoginProviderKeyIndexTable.ExecuteAsync(
                        TableOperation.Retrieve<UserLoginProviderKeyIndexEntity>(candidateIndex.PartitionKey, ""));
            var indexItem = (UserLoginProviderKeyIndexEntity)loginProviderKeyIndexResult.Result;
            if (indexItem == null)
                return null;

            return await FindByIdAsync(indexItem.UserId);
        }

        public async Task SetPasswordHashAsync(T user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;
        }

        public async Task<string> GetPasswordHashAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return user.PasswordHash;
        }

        public Task<bool> HasPasswordAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PasswordHash != null);
        }

        public async Task SetPhoneNumberAsync(T user, string phoneNumber)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException("phoneNumber");

            user.PhoneNumber = phoneNumber;
        }

        public Task<string> GetPhoneNumberAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(T user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task AddToRoleAsync(T user, string role)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentNullException("role");

            var userRole = new UserRoleEntity(user.Id, role);

            await _userRoleTable.ExecuteAsync(TableOperation.Insert(userRole));
        }

        public async Task RemoveFromRoleAsync(T user, string role)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentNullException("role");

            var userRole = new UserRoleEntity(user.Id, role) {ETag = "*"};

            await _userRoleTable.ExecuteAsync(TableOperation.Delete(userRole));
        }

        public Task<IList<string>> GetRolesAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException();

            TableQuery<UserRoleEntity> query = new TableQuery<UserRoleEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id));

            return ExecuteQueryAsync(_userRoleTable, query, x => x.Name);
        }

        public async Task<bool> IsInRoleAsync(T user, string role)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(role))
                throw new ArgumentNullException("role");

            return (await _userRoleTable.ExecuteAsync(TableOperation.Retrieve(user.Id, role.ToSha256()))).Result != null;
        }

        public Task SetSecurityStampAsync(T user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (String.IsNullOrWhiteSpace(stamp))
                throw new ArgumentNullException("stamp");

            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetTwoFactorEnabledAsync(T user, bool enabled)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(T user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult(user.TwoFactorEnabled);
        }

        async Task<IList<TResult>> ExecuteQueryAsync<TQuery, TResult>(CloudTable table, TableQuery<TQuery> query,
            Func<TQuery, TResult> selector)
            where TQuery : class, ITableEntity, new()
        {
            var results = new List<TResult>();

            TableContinuationToken token = null;
            var options = new TableRequestOptions();
            var context = new OperationContext
            {
                ClientRequestID = Guid.NewGuid().ToString(),
            };
            do
            {
                TableQuerySegment<TQuery> result =
                    await table.ExecuteQuerySegmentedAsync(query, token, options, context, default(CancellationToken));

                results.AddRange(result.Select(selector));

                token = result.ContinuationToken;
            }
            while (token != null);

            return results;
        }

        async Task RemoveIndices(T user)
        {
            var userIdIndex = new UserNameIndexEntity(user.UserName.ToSha256(), user.Id) {ETag = "*"};
            var userEmailIndex = new UserEmailIndexEntity(user.Email.ToSha256(), user.Id) {ETag = "*"};

            Task t1 = _userNameIndexTable.ExecuteAsync(TableOperation.Delete(userIdIndex));
            Task t2 = _userEmailIndexTable.ExecuteAsync(TableOperation.Delete(userEmailIndex));

            await Task.WhenAll(t1, t2);
        }

        public async Task RemoveAllLoginsAsync(T user)
        {
            bool error = false;
            var Logins = new List<UserLoginEntity>();
            string partitionKeyQuery = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id);
            TableQuery<UserLoginEntity> query = new TableQuery<UserLoginEntity>().Where(partitionKeyQuery);
            TableQuerySegment<UserLoginEntity> querySegment = null;

            while (querySegment == null || querySegment.ContinuationToken != null)
            {
                querySegment =
                    await _userLoginTable.ExecuteQuerySegmentedAsync(query, querySegment != null ? querySegment.ContinuationToken : null);
                Logins.AddRange(querySegment.Results);
            }

            var batch = new TableBatchOperation();
            var batchIndex = new TableBatchOperation();
            foreach (UserLoginEntity login in Logins)
            {
                login.ETag = "*"; //Delete even if it has changed
                batch.Add(TableOperation.Delete(login));
                var providerKeyIndex = new UserLoginProviderKeyIndexEntity(user.Id, login.ProviderKey, login.LoginProvider);
                providerKeyIndex.ETag = "*";
                batchIndex.Add(TableOperation.Delete(providerKeyIndex));

                if (batch.Count >= 100 || batchIndex.Count >= 100)
                {
                    try
                    {
                        //Try executing as a batch
                        await _userLoginTable.ExecuteBatchAsync(batch);
                        batch.Clear();
                    }
                    catch
                    {
                    }

                    //If a batch wont work, try individually
                    foreach (TableOperation op in batch)
                    {
                        try
                        {
                            await _userLoginTable.ExecuteAsync(op);
                        }
                        catch
                        {
                            error = true;
                        }
                    }

                    //Delete the index individually becase of the partition keys
                    foreach (TableOperation op in batchIndex)
                    {
                        try
                        {
                            await _userLoginProviderKeyIndexTable.ExecuteAsync(op);
                        }
                        catch
                        {
                            error = true;
                        }
                    }

                    batch.Clear();
                    batchIndex.Clear();
                }
            }
            if (batch.Count > 0 || batchIndex.Count > 0)
            {
                try
                {
                    //Try executing as a batch
                    await _userLoginTable.ExecuteBatchAsync(batch);
                    batch.Clear();
                }
                catch
                {
                }

                //If a batch wont work, try individually
                foreach (TableOperation op in batch)
                {
                    try
                    {
                        await _userLoginTable.ExecuteAsync(op);
                    }
                    catch
                    {
                        error = true;
                    }
                }

                //Delete the index individually becase of the partition keys
                foreach (TableOperation op in batchIndex)
                {
                    try
                    {
                        await _userLoginProviderKeyIndexTable.ExecuteAsync(op);
                    }
                    catch
                    {
                        error = true;
                    }
                }
            }

            if (error)
                throw new Exception();
        }

        public async Task RemoveAllClaimsAsync(T user)
        {
            bool error = false;
            var Claims = new List<UserClaimEntity>();
            string partitionKeyQuery = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id);
            TableQuery<UserClaimEntity> query = new TableQuery<UserClaimEntity>().Where(partitionKeyQuery);
            TableQuerySegment<UserClaimEntity> querySegment = null;

            while (querySegment == null || querySegment.ContinuationToken != null)
            {
                querySegment =
                    await _userClaimTable.ExecuteQuerySegmentedAsync(query, querySegment != null ? querySegment.ContinuationToken : null);
                Claims.AddRange(querySegment.Results);
            }

            var batch = new TableBatchOperation();
            foreach (UserClaimEntity claim in Claims)
            {
                claim.ETag = "*"; //Delete even it has changed
                batch.Add(TableOperation.Delete(claim));
                if (batch.Count >= 100)
                {
                    try
                    {
                        //Try executing as a batch
                        await _userClaimTable.ExecuteBatchAsync(batch);
                        batch.Clear();
                    }
                    catch
                    {
                    }


                    //If a batch wont work, try individually
                    foreach (TableOperation op in batch)
                    {
                        try
                        {
                            await _userClaimTable.ExecuteAsync(op);
                        }
                        catch
                        {
                            error = true;
                        }
                    }

                    batch.Clear();
                }
            }
            if (batch.Count > 0)
            {
                try
                {
                    //Try executing as a batch
                    await _userClaimTable.ExecuteBatchAsync(batch);
                    batch.Clear();
                }
                catch
                {
                }


                //If a batch wont work, try individually
                foreach (TableOperation op in batch)
                {
                    try
                    {
                        await _userClaimTable.ExecuteAsync(op);
                    }
                    catch
                    {
                        error = true;
                    }
                }
            }

            if (error)
                throw new Exception();
        }

        public async Task RemoveFromAllRolesAsync(T user)
        {
            bool error = false;
            var Roles = new List<UserRoleEntity>();
            string partitionKeyQuery = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user.Id);
            TableQuery<UserRoleEntity> query = new TableQuery<UserRoleEntity>().Where(partitionKeyQuery);
            TableQuerySegment<UserRoleEntity> querySegment = null;

            while (querySegment == null || querySegment.ContinuationToken != null)
            {
                querySegment =
                    await _userRoleTable.ExecuteQuerySegmentedAsync(query, querySegment != null ? querySegment.ContinuationToken : null);
                Roles.AddRange(querySegment.Results);
            }

            var batch = new TableBatchOperation();
            foreach (UserRoleEntity role in Roles)
            {
                role.ETag = "*"; //Delete even if it has changed
                batch.Add(TableOperation.Delete(role));
                if (batch.Count >= 100)
                {
                    try
                    {
                        //Try executing as a batch
                        await _userRoleTable.ExecuteBatchAsync(batch);
                        batch.Clear();
                    }
                    catch
                    {
                    }

                    //If a batch wont work, try individually
                    foreach (TableOperation op in batch)
                    {
                        try
                        {
                            await _userRoleTable.ExecuteAsync(op);
                        }
                        catch
                        {
                            error = true;
                        }
                    }

                    batch.Clear();
                }
            }
            if (batch.Count > 0)
            {
                try
                {
                    //Try executing as a batch
                    await _userRoleTable.ExecuteBatchAsync(batch);
                    batch.Clear();
                }
                catch
                {
                }

                //If a batch wont work, try individually
                foreach (TableOperation op in batch)
                {
                    try
                    {
                        await _userRoleTable.ExecuteAsync(op);
                    }
                    catch
                    {
                        error = true;
                    }
                }
            }
            if (error)
                throw new Exception();
        }
    }
}