using System.ComponentModel.DataAnnotations;
using IssueTracker.Areas.Identity.Data;

namespace IssueTracker.Models;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<String>? Team { get; set; }
    public DateTime CreatedAt { get; set; }
}