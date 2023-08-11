using PersonalMusicLibraryOrganizer.Domain.Commons;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;

namespace PersonalMusicLibraryOrganizer.Domain.Entities.Albums;

public sealed class Album : Auditable
{
    public string Title { get; set; }
    public DateTime Year { get; set; }

    public string SingerName { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }

    public ICollection<Song> Songs { get; set; }
}
