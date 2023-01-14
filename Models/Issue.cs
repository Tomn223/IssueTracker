using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public enum Status 
{
    Unresolved,
    Researching,
    Testing,
    Resolved
}

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<Manager>? Managers { get; set; }
    public ICollection<Member>? Members { get; set; }
    public Status Status { get; set; }
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FoundAt { get; set; }
    public int ProjectID { get; set; }
    public Project Project { get; set; }
}