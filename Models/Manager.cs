using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class Manager
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Department { get; set; }
    public ICollection<Member>? Members { get; set; }
    public ICollection<Project>? Projects { get; set; }
    public ICollection<Issue>? Issues { get; set; }
}