namespace PersonalMusicLibraryOrganizer.Service.DTOs.Singers;

public class SingerCreationDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}
