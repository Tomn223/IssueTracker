using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class Member
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Department { get; set; }
    public ICollection<Manager>? Managers { get; set; }
    public ICollection<Project>? Projects { get; set; }
    public ICollection<Issue>? Issues { get; set; }
}