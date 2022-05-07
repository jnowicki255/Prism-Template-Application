using Microsoft.EntityFrameworkCore;
using PTA.Repository.Entities;
using System;

namespace PTA.Repository.Seeds
{
    public static partial class PtaSeed
    {
        public static void UsersSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>().HasData(
                new DbUser
                {
                    UserId = 1,
                    Username = "tester",
                    Password = "123",
                    Email = "john.wick@example.com",
                    FirstName = "John",
                    LastName = "Wick",
                    Telephone = "666555444",
                    InsertDate = new DateTime(2020, 01, 01),
                    ModifyDate = new DateTime(2020, 01, 01)
                });
        }
    }
}
