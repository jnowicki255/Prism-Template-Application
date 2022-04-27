using Microsoft.EntityFrameworkCore;
using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Contracts.Properties;
using PTA.Repository.Entities;
using PTA.Repository.Requests;
using PTA.Types.Extensions;
using System;
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

        public Task<User[]> SearchUsersAsync(SearchUserRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateUserAsync(UpdatedUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExistAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(x => x.UserId == userId);
        }
    }
}
