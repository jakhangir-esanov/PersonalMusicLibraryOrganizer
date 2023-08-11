namespace PersonalMusicLibraryOrganizer.Service.DTOs.Singers;

public class SingerResultDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }
}
