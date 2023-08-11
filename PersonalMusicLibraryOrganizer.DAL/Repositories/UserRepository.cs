using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task CreateAsync(User user)
    {
        await appDbContext.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        appDbContext.Entry(user).State = EntityState.Modified;
    }

    public void Delete(User user)
    {
        appDbContext.Users.Remove(user);
    }

    public async Task<User> GetByIdAsync(long id)
        => await appDbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

    public User GetByEmail(string email)
       => appDbContext.Users.FirstOrDefault(x => x.Email.Equals(email));

    public IQueryable<User> GetAll()
        => appDbContext.Users.AsNoTracking().AsQueryable();
}
