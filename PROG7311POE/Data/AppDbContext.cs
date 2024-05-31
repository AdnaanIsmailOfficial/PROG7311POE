using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG7311POE.Models;

namespace PROG7311POE.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

    }
}

