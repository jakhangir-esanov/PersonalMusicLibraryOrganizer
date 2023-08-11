using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Songs;

public class SongResultDto
{
    public long Id { get; set; }
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
