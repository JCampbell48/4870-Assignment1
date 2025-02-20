using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Data;

public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Seed roles first
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "Contributor", NormalizedName = "CONTRIBUTOR" }
        );
    }

    // Seeding users with UserManager
    public static async Task SeedUsersAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Ensure "Admin" role exists
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Ensure "Contributor" role exists
        if (!await roleManager.RoleExistsAsync("Contributor"))
        {
            await roleManager.CreateAsync(new IdentityRole("Contributor"));
        }

        // Create admin user
        if (await userManager.FindByNameAsync("a@a.a") == null)
        {
            var adminUser = new User
            {
                UserName = "a@a.a",
                FirstName = "John",
                LastName = "Smith",
                IsApproved = true
            };

            var result = await userManager.CreateAsync(adminUser, "P@$$w0rd");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Create contributor user
        if (await userManager.FindByNameAsync("b@b.b") == null)
        {
            var contributorUser = new User
            {
                UserName = "b@b.b",
                FirstName = "Michael",
                LastName = "Brown",
                IsApproved = true
            };

            var result = await userManager.CreateAsync(contributorUser, "P@$$w0rd");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(contributorUser, "Contributor");
            }
        }
    }
}
