using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Areas.Identity.Data;
using IssueTracker.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication;


namespace IssueTracker.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IssueTrackerContext _context;

        public ProjectsController(IssueTrackerContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return _context.Project != null ? 
                        View(await _context.Project.Include(i => i.Issues).ToListAsync()) :
                        Problem("Entity set 'IssueTrackerContext.Project'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            // ProjectViewModel viewModel = new ProjectViewModel(); 
            project.Issues = _context.Issue.Where(i => i.ProjectID == project.Id).ToList();
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles="Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
        {
            // if (ModelState.IsValid)
            // var _userManager =  new UserManager<IssueTrackerUser>(new UserStore<IssueTrackerUser>(new IssueTrackerContext()));
            // var _userManager = serviceProvider.GetRequiredService<UserManager<IssueTrackerUser>>();
            Project project = new Project();
            project.Id = projectViewModel.Id;
            project.Title = projectViewModel.Title;
            project.Description = projectViewModel.Description;
            string currentUserId = User.Identity.GetUserId();
            // ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            project.Managers.Add(_context.Users.FirstOrDefault(x => x.Id == currentUserId));
            project.CreatedAt = DateTime.Now;
            // project.Issues = new List<Issue>();
            project.CreatedAt = DateTime.Now;
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // }
            // return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedAt")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'IssueTrackerContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Project?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> CreateIssue(int id)
        {
            TempData["project"] = id;
            return RedirectToAction("Create", "Issues");
        }

        public async Task<IActionResult> AddIssue(int id)
        {
            var issue = _context.Issue.Find(TempData["issue"]);
            var project = _context.Project.Find(id);
            if (project.Issues == null){
                project.Issues = new List<Issue>();
            }
            project.Issues.Add(issue);
            _context.Update(project);
            return RedirectToAction("Details", "Projects", new {id = id});
        }
    }
}
