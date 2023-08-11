using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;

public class PlaylistUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);


    public string UserName { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}