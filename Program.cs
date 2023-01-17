using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using IssueTracker.Data;
using Microsoft.AspNetCore.Identity;
using IssueTracker.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IssueTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IssueTrackerContext")
        ?? throw new InvalidOperationException("Connection string 'IssueTrackerContext' not found.")));

builder.Services.AddDefaultIdentity<IssueTrackerUser>(options => 
    options.SignIn.RequireConfirmedAccount = true).AddRoles<IssueTrackerRole>().AddEntityFrameworkStores<IssueTrackerContext>();

// RoleManager = new RoleManager<IssueTrackerRole>(new RoleStore<IssueTrackerRole>(new IssueTrackerContext()));
// var roleresult = RoleManager.Create(new IdentityRole(Admin));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
