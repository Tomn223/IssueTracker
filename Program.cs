using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using IssueTracker.Data;
using Microsoft.AspNetCore.Identity;
using IssueTracker.Areas.Identity.Data;
using IssueTracker.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IssueTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IssueTrackerContext")
        ?? throw new InvalidOperationException("Connection string 'IssueTrackerContext' not found.")));

builder.Services.AddDefaultIdentity<IssueTrackerUser>(options => 
    options.SignIn.RequireConfirmedAccount = true).AddRoles<IssueTrackerRole>().AddEntityFrameworkStores<IssueTrackerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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
