using Microsoft.EntityFrameworkCore;
using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Properties;
using PTA.Repository.Requests;
using PTA.Repository.Tests.Infrastucture;
using PTA.TestBase;
using PTA.Types.Extensions;
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

        [Fact]
        public async Task CreateUser_UsernameAlreadyUsed_Error()
        {
            //Arrange
            var existingUsers = await fixture.Repository.SearchUsersAsync(new Requests.SearchUserRequest());
            var itemToAdd = PrepareNewUser(username: existingUsers.Value.FirstOrDefault().Username);

            //Act
            var result = await fixture.Repository.CreateUserAsync(itemToAdd);

            //Assert
            ShouldReturnFailureWithErrorMessage(result,
                Resources.CheckErrorList,
                Resources.UserWithUsernameAlreadyExists.Fill(itemToAdd.Username));

        }

        [Fact]
        public async Task DisableUser_ExistingUser_Success()
        {
            // Arrange
            var existingUser = await fixture.DbContext.Users
                .SingleOrDefaultAsync(x => x.Username == "userToDisable");

            // Act
            var result = await fixture.Repository.DisableUserAsync(existingUser.UserId);

            // Assert
            ShouldReturnSuccess(result);
        }

        [Fact]
        public async Task DisableUser_NotExistingUser_Error()
        {
            // Arrange
            var nonExistingUserId = int.MaxValue;

            // Act
            var result = await fixture.Repository.DisableUserAsync(nonExistingUserId);

            // Assert
            ShouldReturnFailureWithErrorMessage(result,
                Resources.CheckErrorList,
                Resources.ItemNotFound);
        }

        [Fact]
        public async Task GetUser_ExistingUser_Success()
        {
            // Arrange
            var existingUser = await fixture.DbContext.Users.FirstOrDefaultAsync();

            // Act
            var result = await fixture.Repository.GetUserAsync(existingUser.UserId);

            // Assert
            ShouldReturnSuccess(result);
            Assert.Equal(existingUser.UserId, result.Value.UserId);
        }

        [Fact]
        public async Task GetUser_NotExistingUser_Error()
        {
            // Arrange
            var notExistingUserId = int.MaxValue;

            // Act
            var result = await fixture.Repository.GetUserAsync(notExistingUserId);

            // Assert
            ShouldReturnFailureWithErrorMessage(result,
                Resources.CheckErrorList,
                Resources.ItemNotFound);
        }

        [Fact]
        public async Task SearchUsers_ExistingUsers_Success()
        {
            // Arrange
            var searchRequest = new SearchUserRequest
            {
                IsEnabled = true,
                IsExpired = false
            };

            // Act
            var result = await fixture.Repository.SearchUsersAsync(searchRequest);

            // Assert
            ShouldReturnSuccess(result);
        }

        [Fact]
        public async Task UpdateUser_ExistingUser_Success()
        {
            // Arrange
            var userToUpdate = await fixture.DbContext.Users.FirstOrDefaultAsync();
            var updatedUser = new UpdatedUser
            {
                UserId = userToUpdate.UserId,
                Email = "changed@mail.com",
                ExpirationDate = new DateTime(2022, 12, 31),
                FirstName = "NewFirstName",
                LastName = "NewLastName",
                IsEnabled = !userToUpdate.IsEnabled,
                Password = "NewPassword",
                Telephone = "NewTelephone",
            };

            // Act
            var result = await fixture.Repository.UpdateUserAsync(updatedUser);
            var dbUser = await fixture.DbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == updatedUser.UserId);

            // Assert
            ShouldReturnSuccess(result);
            Assert.Equal(updatedUser.Email, dbUser.Email);
            Assert.Equal(updatedUser.FirstName, dbUser.FirstName);
            Assert.Equal(updatedUser.LastName, dbUser.LastName);
            Assert.Equal(updatedUser.IsEnabled, dbUser.IsEnabled);
            Assert.Equal(updatedUser.Password, dbUser.Password);
            Assert.Equal(updatedUser.Telephone, dbUser.Telephone);
            Assert.Equal(updatedUser.ExpirationDate, dbUser.ExpirationDate);
        }

        [Fact]
        public async Task UpdateUser_NotExistingUser_Error()
        {
            // Arrange
            var updatedUser = new UpdatedUser
            {
                UserId = int.MaxValue
            };

            // Act
            var result = await fixture.Repository.UpdateUserAsync(updatedUser);

            // Assert
            ShouldReturnFailureWithErrorMessage(result,
                Resources.CheckErrorList,
                Resources.ItemNotFound);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(int.MaxValue, false)]
        public async Task UserExist_Success(int userId, bool exists)
        {
            // Arrange & Act
            var result = await fixture.Repository.UserExistAsync(userId);

            // Assert
            Assert.Equal(exists, result);
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
