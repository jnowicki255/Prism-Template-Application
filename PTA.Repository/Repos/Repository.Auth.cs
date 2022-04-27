using Microsoft.EntityFrameworkCore;
using PTA.Contracts.Entities.Common.Users;
using System.Threading.Tasks;

namespace PTA.Repository.Repos
{
    public partial class Repository
    {
        public async Task<User> AuthorizeCredentialsAsync(string username, string secret)
        {
            var dbUser = await dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Username == username && x.Password == secret);

            return mapper.Map<User>(dbUser);
        }
    }
}
