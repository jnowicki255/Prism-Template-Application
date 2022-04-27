using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Requests;
using System.Threading.Tasks;

namespace PTA.Repository.Interfaces.Repos
{
    /// <summary>
    /// DB operations related to managing of users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get saved users matching criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<User[]> SearchUsersAsync(SearchUserRequest request);

        /// <summary>
        /// Get single robot with specified id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(int userId);

        /// <summary>
        /// Create new user.
        /// If succeded, returns created object, otherwise returns error collection.
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
        /// Checks if defined user exists in the database.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> UserExistAsync(int userId);

        /// <summary>
        /// Check if user account has expired and disables it.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<BaseOperationResult> DisableUserAsync(int userId);
    }
}
