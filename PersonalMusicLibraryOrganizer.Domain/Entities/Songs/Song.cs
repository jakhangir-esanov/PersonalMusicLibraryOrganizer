using PersonalMusicLibraryOrganizer.Domain.Commons;
using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

namespace PersonalMusicLibraryOrganizer.Domain.Entities.Songs;

public sealed class Song : Auditable
{
    public string Title { get; set; }   
    public string Genre { get; set; }
    public DateTime Year { get; set; }
    public string FilePath { get; set; }

    public string SingerName { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }

    public long AlbumId { get; set; }
    public Album Album { get; set; }

    public long PlaylistId { get; set; }
    public Playlist Playlist { get; set; }
}
