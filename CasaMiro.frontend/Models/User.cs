using System;
using System.ComponentModel.DataAnnotations;

namespace CasaMiro.frontend.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public required string FullName { get; set; }

    [EmailAddress, MaxLength(255)]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public required string Role { get; set; } // Administrator, Front Desk Staff, etc.

    public string? LotNumber { get; set; } // For subdivision residents

    [Phone]
    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
