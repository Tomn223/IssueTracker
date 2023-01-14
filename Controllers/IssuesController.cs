using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Areas.Identity.Data;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IssueTrackerContext _context;

        public IssuesController(IssueTrackerContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
              return _context.Issue != null ? 
                          View(await _context.Issue.ToListAsync()) :
                          Problem("Entity set 'IssueTrackerContext.Issue'  is null.");
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            // var issueViewModel = new IssueViewModel();
            // issueViewModel.Project = _context.Project.Find(TempData["project"]);
            return View(new IssueViewModel());
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IssueViewModel issueViewModel)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(issue);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction(nameof(Index));
            // }
            // return View();
            var issue = new Issue();
            int id = issueViewModel.Id;
            issue.Id = id;
            issue.Title = issueViewModel.Title;
            issue.Description = issueViewModel.Description;
            // issue.Managers.Add(issueViewModel.Manager1);
            // issue.Managers.Add(issueViewModel.Manager2);
            // issue.Managers.Add(issueViewModel.Manager3);
            // issue.Members.Add(issueViewModel.Member1);
            // issue.Members.Add(issueViewModel.Member2);
            // issue.Members.Add(issueViewModel.Member3);
            issue.Status = issueViewModel.Status;
            issue.Priority = issueViewModel.Priority;
            issue.CreatedAt = DateTime.Now;
            issue.FoundAt = issueViewModel.FoundAt;
            issue.ProjectID = (int)TempData["project"];
            var project = _context.Project.Find(TempData["project"]);
            issue.Project = project;
            // issue.Project.Issues.Add(issue);
            // TempData["issue"] = issue.Id;
            _context.Issue.Add(issue);
            _context.SaveChanges();
            // project.Issues = new List<Issue>();
            // project.Issues.Add(issue);
            // _context.SaveChanges();
            // TempData["issue"] = id;
            // TempData["project"] = TempData["project"];
            return RedirectToAction("Details", "Projects", new {id = TempData["project"]});
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,Priority,CreatedAt,FoundAt")] Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
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
            return View(issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Issue == null)
            {
                return Problem("Entity set 'IssueTrackerContext.Issue'  is null.");
            }
            var issue = await _context.Issue.FindAsync(id);
            if (issue != null)
            {
                _context.Issue.Remove(issue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
          return (_context.Issue?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private ActionResult AddIssueFromProj(Project proj)
        {
            var issueViewModel = new Models.Issue { Project = proj };
            return View(issueViewModel);
        }
        public async Task<IActionResult> AddIssueFromProj([Bind("Id,Title,Description,Status,Priority,CreatedAt,FoundAt")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }
    }
}
