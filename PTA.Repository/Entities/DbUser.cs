using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTA.Repository.Entities
{
    [Index(nameof(Username), Name = "UQ_Users_Username", IsUnique = true)]
    public partial class DbUser
    {
        [Key]
        public int UserId { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool IsEnabled { get; set; }

        [Required]
        [StringLength(150)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; } //TODO: Beta version of DB - to change!

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }
    }
}
