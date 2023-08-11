using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly AppDbContext appDbContext;

    public PlaylistRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task CreateAsync(Playlist playlist)
    {
        await appDbContext.Playlists.AddAsync(playlist);
    }

    public void Update(Playlist playlist)
    {
        appDbContext.Entry(playlist).State = EntityState.Modified;
    }

    public void Delete(Playlist playlist)
    {
        appDbContext.Playlists.Remove(playlist);
    }

    public async Task<Playlist> GetByIdAsync(long id)
        => await appDbContext.Playlists.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public IQueryable<Playlist> GetAll()
        => appDbContext.Playlists.AsNoTracking().AsQueryable();
}
