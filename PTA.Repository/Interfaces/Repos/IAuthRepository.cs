using PTA.Contracts.Entities.Common.Users;
using System.Threading.Tasks;

namespace PTA.Repository.Interfaces.Repos
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Checks if user with specified username and password exists.
        /// If true returns found user, otherwise returns error.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        Task<User> AuthorizeCredentialsAsync(string username, string secret);
    }
}
