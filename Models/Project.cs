using System.ComponentModel.DataAnnotations;
using IssueTracker.Areas.Identity.Data;

namespace IssueTracker.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<IssueTrackerUser>? Team { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Issue>? Issues { get; set; }
}