using System.ComponentModel.DataAnnotations;
using IssueTracker.Areas.Identity.Data;

namespace IssueTracker.Models;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public IssueTrackerUser? Manager1 { get; set; }
    public IssueTrackerUser? Manager2 { get; set; }
    public IssueTrackerUser? Manager3 { get; set; }
    public IssueTrackerUser? Member1 { get; set; }
    public IssueTrackerUser? Member2 { get; set; }
    public IssueTrackerUser? Member3 { get; set; }
    public DateTime CreatedAt { get; set; }
}