using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Interfaces.Repos;
using PTA.Repository.Requests;
using PTA.Services.Database.Interfaces.Providers;
using PTA.Services.Database.Interfaces.Validation;
using System;
using System.Threading.Tasks;

namespace PTA.Services.Database.Providers
{
    public class UserProvider : BaseProvider, IUserProvider
    {
        private readonly IRepository repository;


        public UserProvider(IRepository repository, IValidationProvider validationProvider)
            : base(validationProvider)
        {
            this.repository = repository;
        }


        public async Task<OperationResult<User>> CreateUserAsync(NewUser newUser)
        {
            var validationResult = validationProvider.Validate(newUser);

            if (!validationResult.IsValid)
            {
                return new OperationResult<User>(validationResult.Errors);
            }

            return await repository.CreateUserAsync(newUser);
        }

        public async Task<BaseOperationResult> DisableUserAsync(int userId)
        {
            var result = await repository.DisableUserAsync(userId);

            if (result != null)
                return BaseOperationResult.SuccessfulOperation;

            return new BaseOperationResult("User not found", null);
        }

        public async Task<OperationResult<User>> GetUserAsync(int userId)
        {
            var result = await repository.GetUserAsync(userId);

            if (result != null)
            {
                return new OperationResult<User>(result);
            }

            return new OperationResult<User>("User not found", null);
        }

        public async Task<OperationResult<User[]>> SearchUsersAsync(SearchUserRequest request)
        {
            var validationResult = validationProvider.Validate(request);
            if (!validationResult.IsValid)
                return new OperationResult<User[]>(validationResult.Errors);

            var result = await repository.SearchUsersAsync(request);

            return new OperationResult<User[]>(result);
        }

        public async Task<BaseOperationResult> UpdateUserAsync(UpdatedUser user)
        {
            return ExecuteIfValidationSucceeded(user, () =>
            {
                return ExecuteIfUserExists(user.UserId, () =>
                {
                    return repository.UpdateUserAsync(user).Result;
                });
            });
        }

        private TResult ExecuteIfUserExists<TResult>(int userId, Func<TResult> action) where TResult : BaseOperationResult
        {
            if (!repository.UserExistAsync(userId).Result)
            {
                return (TResult)Activator.CreateInstance(typeof(TResult), "User not found", null);
            }
            return action();
        }
    }
}
