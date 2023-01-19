using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IssueTracker.Areas.Identity.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IssueTracker.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new IssueTrackerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<IssueTrackerContext>>()))
        {
            // var roleStore = new RoleStore<IssueTrackerRole>(context);
            // var roleManager = new RoleManager<IdentityRole>(context);
            // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IssueTrackerRole>>();
            // serviceScope.ServiceProvider.GetService<RoleM
            
            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IssueTrackerRole role = new IssueTrackerRole();
                role.Name = "Member";
                role.Id = Guid.NewGuid().ToString();
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                IssueTrackerRole role = new IssueTrackerRole();
                role.Name = "Manager";
                role.Id = Guid.NewGuid().ToString();
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            // // Look for any users
            // if (context.AspNetUsers.Any())
            // {
            //     return;   // DB has been seeded
            // }
            // context.AspNetUsers.AddRange(
            //     new AspNetUsers
            //     {
            //         Title = "When Harry Met Sally",
            //         ReleaseDate = DateTime.Parse("1989-2-12"),
            //         Genre = "Romantic Comedy",
            //         Price = 7.99M
            //     }
            // );
            context.SaveChanges();
        }
    }
}