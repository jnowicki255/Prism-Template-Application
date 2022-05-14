using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Interfaces.Repos;
using PTA.Services.Database.Interfaces.Providers;
using PTA.Services.Database.Interfaces.Validation;
using System.Threading.Tasks;

namespace PTA.Services.Database.Providers
{
    public class AuthProvider : BaseProvider, IAuthProvider
    {
        public AuthProvider(IRepository repository, IValidationProvider validationProvider)
            : base(repository, validationProvider)
        { }

        public async Task<OperationResult<User>> AuthorizeCredentialsAsync(string username, string secret)
        {
            var result = await repository.AuthorizeCredentialsAsync(username, secret);

            if (result != null)
                return new OperationResult<User>(result);

            return new OperationResult<User>("Bad username or password.", null);
        }
    }
}
