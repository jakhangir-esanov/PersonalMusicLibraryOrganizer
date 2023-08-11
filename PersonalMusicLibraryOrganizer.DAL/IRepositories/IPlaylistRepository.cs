using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;

namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface IPlaylistRepository
{
    Task CreateAsync(Playlist playlist);
    void Update(Playlist playlist);
    void Delete(Playlist playlist);
    Task<Playlist> GetByIdAsync(long id);
    IQueryable<Playlist> GetAll();
}
