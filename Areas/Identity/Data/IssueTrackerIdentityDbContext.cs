using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Areas.Identity.Data;

public class IssueTrackerUser : IdentityUser {
    [PersonalData]
    public string? FirstName { get; set; }
    [PersonalData]
    public string? LastName { get; set; }
    [PersonalData]
    public DateTime CreatedAt { get; set; }
}

public class IssueTrackerContext : IdentityDbContext<IssueTrackerUser>
{
    public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<IssueTracker.Models.Admin> Admin { get; set; } = default!;

    public DbSet<IssueTracker.Models.Manager> Manager { get; set; } = default!;

    public DbSet<IssueTracker.Models.Member> Member { get; set; } = default!;

    public DbSet<IssueTracker.Models.Issue> Issue { get; set; } = default!;

    public DbSet<IssueTracker.Models.Project> Project { get; set; } = default!;
}
