using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Requests;
using System.Threading.Tasks;

namespace PTA.Services.Database.Interfaces.Providers
{
    /// <summary>
    /// Allows to read or edit users.
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Returns saved users matching criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OperationResult<User[]>> SearchUsersAsync(SearchUserRequest request);

        /// <summary>
        /// Returns single robot with specified id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<OperationResult<User>> GetUserAsync(int userId);

        /// <summary>
        /// Creates a new user definition. 
        /// If succeeded, returns created object otherwise returns error.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<OperationResult<User>> CreateUserAsync(NewUser newUser);

        /// <summary>
        /// Updates user if allowed, otherwise returns error collection.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<BaseOperationResult> UpdateUserAsync(UpdatedUser user);

        /// <summary>
        /// Disables user account if allowed, otherwise returns error collection.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<BaseOperationResult> DisableUserAsync(int userId);
    }
}
