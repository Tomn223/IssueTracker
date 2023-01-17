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

public enum RoleTitle {
    admin,
    manager,
    member
}

public class IssueTrackerRole : IdentityRole {
    public RoleTitle RoleTitle { get; set; }
}

public class IssueTrackerContext : IdentityDbContext<IssueTrackerUser, IssueTrackerRole, string>
{
    public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options)
        : base(options)
    {
    }

    public DbSet<IssueTracker.Models.Admin> Admin { get; set; } = default!;

    public DbSet<IssueTracker.Models.Manager> Manager { get; set; } = default!;

    public DbSet<IssueTracker.Models.Member> Member { get; set; } = default!;

    public DbSet<IssueTracker.Models.Issue> Issue { get; set; } = default!;

    public DbSet<IssueTracker.Models.Project> Project { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<IssueTracker.Models.Issue>()
            .HasOne<IssueTracker.Models.Project>(i => i.Project)
            .WithMany(p => p.Issues).HasForeignKey(i => i.ProjectID);

        builder.Entity<IssueTracker.Models.Project>()
            .HasMany<IssueTracker.Models.Issue>(p => p.Issues)
            .WithOne(i => i.Project)
            .HasForeignKey(i => i.ProjectID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
