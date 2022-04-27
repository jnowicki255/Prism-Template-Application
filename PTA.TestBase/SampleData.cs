using PTA.Contracts.Entities.Common.Users;
using System;

namespace PTA.TestBase
{
    public static class SampleData
    {
        public static NewUser NewUser
            => new()
            {
                Username = "sample.user",
                FirstName = "Sample",
                LastName = "User",
                Email = "sample.user@example.com",
                IsEnabled = true,
                Password = Guid.NewGuid().ToString()
            };
    }
}
