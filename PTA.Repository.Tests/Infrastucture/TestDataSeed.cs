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
        }

        private void Insert(object entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        private static Entities.DbUser GetUser(string username, string firstName,
            string lastName, string email, string telephone, bool isEnabled)
            => new()
            {
                Username = username,
                FirstName = firstName,
                Password = "123",
                LastName = lastName,
                Email = email,
                Telephone = telephone,
                IsEnabled = isEnabled,
                InsertDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };
    }
}
