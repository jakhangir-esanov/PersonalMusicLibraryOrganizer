using System.ComponentModel.DataAnnotations;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Users;

public class UserCreationDto
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
}
