using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class SingerRepositroy : ISingerRepository
{
    private readonly AppDbContext appDbContext;

    public SingerRepositroy(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task CreateAsync(Singer singer)
    {
        await appDbContext.Singers.AddAsync(singer);
    }
    public void Update(Singer singer)
    {
        appDbContext.Entry(singer).State = EntityState.Modified;
    }

    public void Delete(Singer singer)
    {
        appDbContext.Singers.Remove(singer);
    }

    public async Task<Singer> GetByIdAsync(long id)
        => await appDbContext.Singers.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public Singer GetByEmail(string email)
       => appDbContext.Singers.FirstOrDefault(x => x.Email.Equals(email));

    public IQueryable<Singer> GetAll()
        => appDbContext.Singers.AsNoTracking().AsQueryable();
}
