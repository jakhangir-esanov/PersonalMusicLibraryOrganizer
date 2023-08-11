using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;

namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface ISongRepository
{
    Task CreateAsync(Song song);
    void Update(Song song);
    void Delete(Song song);
    Task<Song> GetByIdAsync(long id);
    IQueryable<Song> GetAll();
}
