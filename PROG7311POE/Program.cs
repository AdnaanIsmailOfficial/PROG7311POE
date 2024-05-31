using Microsoft.EntityFrameworkCore;
using PROG7311POE.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

SeedRoles(app.Services).Wait(); // Seed roles

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


async Task SeedRoles(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

       
        var roleNames = new[] { "Farmer", "Employee" };

        foreach (var roleName in roleNames)
        {
            
            var roleExist = await roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}