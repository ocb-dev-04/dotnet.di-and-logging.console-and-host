using System.ComponentModel.DataAnnotations;

namespace ConsoleWorkerFullTest.Entities;

public sealed class Profile
{
    [Key, Required]
    public Guid Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, Range(1, 120)]
    public int Age { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
}
