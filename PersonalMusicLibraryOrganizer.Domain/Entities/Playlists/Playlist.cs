using PersonalMusicLibraryOrganizer.Domain.Commons;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;

public sealed class Playlist : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }

    public string UserName { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<Song> Songs { get; set; }
}
