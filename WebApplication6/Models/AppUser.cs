using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
  
        public bool IsReminded{ get; set; }
    }
}
