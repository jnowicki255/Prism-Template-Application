using System;

namespace PTA.Repository.Tests.Infrastucture
{
    public class TestDataSeed
    {
        private readonly PTADbContext context;

        public TestDataSeed(PTADbContext context)
        {
            this.context = context;
        }

        public void InsertData()
        {
            Insert(GetUser("john.wick", "John", "Wick", "john.wick@example.com", "666-777-888", true));
            Insert(GetUser("alice.cooper", "Alice", "Cooper", "alice.cooper@example.com", "666-777-888", false));
            Insert(GetUser("boris.johnson", "Boris", "Johnson", "boris.johnson@example.com", "666-777-888", true));
            Insert(GetUser("expiredUser", "Expired", "User", "expired@user.com", "555-111-222", false, expirationDate: new DateTime(2020, 01, 01)));
            Insert(GetUser("userToDisable", "User", "ToDisable", "to@disable.com", "222", true));
        }

        private void Insert(object entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        private static Entities.DbUser GetUser(string username, string firstName,
            string lastName, string email, string telephone, bool isEnabled, 
            DateTime? insertDate = null, DateTime? modifyDate = null, 
            DateTime? expirationDate = null, DateTime? lastLoginDate = null)
            => new()
            {
                Username = username,
                FirstName = firstName,
                Password = "123",
                LastName = lastName,
                Email = email,
                Telephone = telephone,
                IsEnabled = isEnabled,
                InsertDate = insertDate != null ? insertDate.Value : DateTime.UtcNow,
                ModifyDate = modifyDate != null ? modifyDate.Value : DateTime.UtcNow,
                ExpirationDate = expirationDate,
                LastLoginDate = lastLoginDate,
            };
    }
}
