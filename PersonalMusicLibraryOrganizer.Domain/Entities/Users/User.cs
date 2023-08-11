using PersonalMusicLibraryOrganizer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace PersonalMusicLibraryOrganizer.Domain.Entities.Users;

public sealed class User : Auditable
{
    [MinLength(3), MaxLength(50)]
    public string FirstName { get; set; }
    [MinLength(3), MaxLength(50)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
