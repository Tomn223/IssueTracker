using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class ProjectViewModel
{
    public IEnumerable<Project> Projects { get; set; }
    public IEnumerable<Issue> Issues { get; set; }
}