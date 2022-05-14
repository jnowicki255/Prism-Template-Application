using Microsoft.EntityFrameworkCore;
using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Contracts.Properties;
using PTA.Repository.Entities;
using PTA.Repository.Requests;
using PTA.Types.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTA.Repository.Repos
{
    public partial class Repository
    {
        public async Task<OperationResult<User>> CreateUserAsync(NewUser newUser)
        {
            if (await dbContext.Users.AnyAsync(x => x.Username == newUser.Username))
                return new OperationResult<User>(Resources.UserWithUsernameAlreadyExists.Fill(newUser.Username), null);

            var dbUser = mapper.Map<DbUser>(newUser);
            dbContext.Users.Add(dbUser);
            await dbContext.SaveChangesAsync();
            var savedUser = mapper.Map<User>(dbUser);

            return new OperationResult<User>(savedUser);
        }

        public async Task<BaseOperationResult> DisableUserAsync(int userId)
        {
            var dbUser = await dbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == userId);

            if (dbUser == null)
                return new BaseOperationResult(Resources.ItemNotFound);

            dbUser.IsEnabled = false;
            dbUser.ModifyDate = DateTime.Now;

            dbContext.Users.Update(dbUser);
            await dbContext.SaveChangesAsync();

            return BaseOperationResult.SuccessfulOperation;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var dbUser = await dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == userId);
            return mapper.Map<User>(dbUser);
        }

        public async Task<User[]> SearchUsersAsync(SearchUserRequest request)
        {
            var dbUsersQuery = dbContext.Users
                .AsNoTracking();

            if (request.IsEnabled != null)
            {
                dbUsersQuery = dbUsersQuery
                    .Where(x => x.IsEnabled == request.IsEnabled);
            }

            if (request.IsExpired != null)
            {
                if (request.IsExpired.Value)
                {
                    dbUsersQuery = dbUsersQuery
                        .Where(x => x.ExpirationDate < DateTime.UtcNow);
                }
                else
                {
                    dbUsersQuery = dbUsersQuery
                        .Where(x => x.ExpirationDate >= DateTime.UtcNow);
                }
                
            }

            var dbUsers = await dbUsersQuery.ToArrayAsync();
            return mapper.Map<User[]>(dbUsers);
        }

        public async Task<BaseOperationResult> UpdateUserAsync(UpdatedUser user)
        {
            var dbUser = await dbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == user.UserId);

            if (dbUser == null)
                return new BaseOperationResult(Resources.ItemNotFound);

            dbContext.Entry(dbUser).CurrentValues.SetValues(user);
            dbUser.ModifyDate = DateTime.UtcNow;
            await dbContext.SaveChangesAsync();
            return BaseOperationResult.SuccessfulOperation;
        }

        public async Task<bool> UserExistAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(x => x.UserId == userId);
        }
    }
}
