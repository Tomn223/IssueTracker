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
            var roleStore = new RoleStore<IssueTrackerRole>(context);

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleStore.CreateAsync(new IssueTrackerRole("Member"));
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