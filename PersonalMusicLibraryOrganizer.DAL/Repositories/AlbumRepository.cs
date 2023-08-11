using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly AppDbContext appDbContext;

    public AlbumRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task CreateAsync(Album album)
    {
        await appDbContext.Albums.AddAsync(album);
    }

    public void Update(Album album)
    {
        appDbContext.Entry(album).State = EntityState.Modified;
    }

    public void Delete(Album album)
    {
        appDbContext.Albums.Remove(album);
    }

    public async Task<Album> GetByIdAsync(long id)
        => await appDbContext.Albums.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public IQueryable<Album> GetAll()
        => appDbContext.Albums.AsNoTracking().AsQueryable();
}
