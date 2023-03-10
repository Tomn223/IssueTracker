using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    public DateTime CreatedAt { get; set; }
}