using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;

namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface IAlbumRepository
{
    Task CreateAsync(Album album);
    void Update(Album album);
    void Delete(Album album);
    Task<Album> GetByIdAsync(long id);
    IQueryable<Album> GetAll();
}
