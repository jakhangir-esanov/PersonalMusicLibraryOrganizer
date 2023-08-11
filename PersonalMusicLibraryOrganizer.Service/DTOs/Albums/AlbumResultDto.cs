using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Albums;

public class AlbumResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime Year { get; set; }

    public string SingerName { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }

    public ICollection<Song> Songs { get; set; }
}