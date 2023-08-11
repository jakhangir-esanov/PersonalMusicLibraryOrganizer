using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void Update(User user);
    void Delete(User user);
    Task<User> GetByIdAsync(long id);
    IQueryable<User> GetAll();
    User GetByEmail(string email);
}
