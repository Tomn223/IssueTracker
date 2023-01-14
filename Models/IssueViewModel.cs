using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class IssueViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public Manager? Manager1 { get; set; }
    public Manager? Manager2 { get; set; }
    public Manager? Manager3 { get; set; }
    public Member? Member1 { get; set; }
    public Member? Member2 { get; set; }
    public Member? Member3 { get; set; }
    public Status Status { get; set; }
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FoundAt { get; set; }
    public int ProjectID { get; set; }
    public Project Project { get; set; }
}