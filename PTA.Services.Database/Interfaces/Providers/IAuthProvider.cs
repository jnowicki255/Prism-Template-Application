using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using System.Threading.Tasks;

namespace PTA.Services.Database.Interfaces.Providers
{
    public interface IAuthProvider
    {
        Task<OperationResult<User>> AuthorizeCredentialsAsync(string username, string secret);
    }
}
