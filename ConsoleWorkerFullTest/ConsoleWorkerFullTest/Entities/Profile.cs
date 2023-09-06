using System.ComponentModel.DataAnnotations;

namespace ConsoleWorkerFullTest.Entities;

public sealed class Profile
{
    [Key, Required]
    public Guid Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; init; }

    [Required, Range(1, 120)]
    public int Age { get; init; }

    [Required, EmailAddress]
    public string Email { get; init; }

    public Profile(string Name, int Age, string Email)
    {
        this.Name = Name;
        this.Age = Age;
        this.Email = Email;
    }
}
