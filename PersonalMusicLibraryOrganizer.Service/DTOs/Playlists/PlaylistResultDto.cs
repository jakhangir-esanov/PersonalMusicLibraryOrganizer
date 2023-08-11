using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;

public class PlaylistResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string UserName { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<Song> Songs { get; set; }
}