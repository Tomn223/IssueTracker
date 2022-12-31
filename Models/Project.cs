using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<Manager>? Managers { get; set; }
    public ICollection<Member>? Members { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Issue>? Issues { get; set; }
}