using System;

namespace PTA.Contracts.Entities.Common.Users
{
    public class UpdatedUser
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
