using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models;

public class Admin
{
    public int Id { get; set; }
    public User? User { get; set; }
}