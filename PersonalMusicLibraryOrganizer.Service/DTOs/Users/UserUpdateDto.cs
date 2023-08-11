using System.ComponentModel.DataAnnotations;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id { get; set; }
    [MinLength(3), MaxLength(50)]
    public string FirstName { get; set; }
    [MinLength(3), MaxLength(50)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);
}
