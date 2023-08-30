using Microsoft.AspNetCore.Identity;

namespace fast_booze.Entities.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreationDate { get; set; }
    }
}