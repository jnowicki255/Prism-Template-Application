using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Properties;
using PTA.Repository.Tests.Infrastucture;
using PTA.TestBase;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static PTA.TestBase.Comparator;

namespace PTA.Repository.Tests.Tests
{
    [Collection(TestsCollections.DatabaseTests)]
    public class UsersTests : TestBase.TestBase, IDisposable
    {
        private readonly DatabaseTestFixture fixture;


        public UsersTests(DatabaseTestFixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        { }


        [Fact]
        public async Task CreateUser_AddItem_Success()
        {
            //Arrange
            var itemToAdd = PrepareNewUser();

            //Act
            var result = await fixture.Repository.CreateUserAsync(itemToAdd);

            //Assert
            ShouldReturnSuccess(result);
            ShouldBeGreaterThanZero(result.Value.UserId);
            ComparePropertiesAndThrowIfMismatch(result.Value, itemToAdd);
        }

        [Fact(Skip = "No yet implemented.")]
        public async Task CreateUser_UsernameAlreadyUsed_Error()
        {
            //Arrange
            var existingUsers = await fixture.Repository.SearchUsersAsync(new Requests.SearchUserRequest());
            var itemToAdd = PrepareNewUser(username: existingUsers.FirstOrDefault().Username);

            //Act
            var result = await fixture.Repository.CreateUserAsync(itemToAdd);

            //Assert
            ShouldReturnFailureWithErrorMessage(result,
                Resources.CheckErrorList,
                Resources.UserWithUsernameAlreadyExists);

        }



        private NewUser PrepareNewUser(string username = null, bool isEnabled = true)
        {
            var newUser = SampleData.NewUser;
            newUser.Username = username ?? Guid.NewGuid().ToString();
            newUser.IsEnabled = isEnabled;
            return newUser;
        }
    }
}
