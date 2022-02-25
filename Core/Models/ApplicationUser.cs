using Microsoft.AspNetCore.Identity;

namespace Core.Models {
    public class ApplicationUser : IdentityUser {
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime? RegistrationDate { get; set; }
    }
}