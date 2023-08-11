using PersonalMusicLibraryOrganizer.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

public sealed class Singer : Auditable
{
    [MinLength(3), MaxLength(50)]
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
