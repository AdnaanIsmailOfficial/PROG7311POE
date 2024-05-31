using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PROG7311POE.Models
{
    public class RegisterModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<string> RoleList { get; set; } 

        public class InputModel
        {
            
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Role { get; set; } 
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            
            var roles = await _roleManager.Roles.ToListAsync();

           
            RoleList = new List<string>();
            foreach (var role in roles)
            {
                RoleList.Add(role.Name);
            }
        }
    }
}