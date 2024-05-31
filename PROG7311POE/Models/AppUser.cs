using Microsoft.AspNetCore.Identity;

namespace PROG7311POE.Models
{
    public class AppUser: IdentityUser
    {
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        
    }
}
