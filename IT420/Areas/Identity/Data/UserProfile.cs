using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IT420.Core
{
    public class UserProfile : IdentityUser
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public bool IsExpert { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public byte[]? userImg { get; set; }
    }
}
