using Microsoft.EntityFrameworkCore;
using RailWayModelLibrary.RailWayEnums;
using System.ComponentModel.DataAnnotations;

namespace RailWayModelLibrary.Entities.Base
{
    [Index(nameof(Email), IsUnique = true)]
   
    public class Person: EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsLock { get; set; }
        public int NTry { get; set; }
        public DateTime LastLogin { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}
