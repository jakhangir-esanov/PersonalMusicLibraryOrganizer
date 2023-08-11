using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class SongRepository : ISongRepository
{
    private readonly AppDbContext appDbContext;

    public SongRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task CreateAsync(Song song)
    {
        await appDbContext.Songs.AddAsync(song);
    }

    public void Update(Song song)
    {
        appDbContext.Entry(song).State = EntityState.Modified;
    }

    public void Delete(Song song)
    {
        appDbContext.Songs.Remove(song);
    }

    public async Task<Song> GetByIdAsync(long id)
        => await appDbContext.Songs.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public IQueryable<Song> GetAll()
        => appDbContext.Songs.AsNoTracking().AsQueryable();
}
