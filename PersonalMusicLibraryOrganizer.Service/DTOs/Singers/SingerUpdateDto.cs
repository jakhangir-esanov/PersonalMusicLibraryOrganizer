namespace PersonalMusicLibraryOrganizer.Service.DTOs.Singers;

public class SingerUpdateDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);
    public string Country { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
