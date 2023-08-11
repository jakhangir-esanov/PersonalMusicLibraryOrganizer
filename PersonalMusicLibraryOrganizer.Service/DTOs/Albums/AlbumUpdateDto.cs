using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

namespace PersonalMusicLibraryOrganizer.Service.DTOs.Albums;

public class AlbumUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime Year { get; set; }

    public string SingerName { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }
}

