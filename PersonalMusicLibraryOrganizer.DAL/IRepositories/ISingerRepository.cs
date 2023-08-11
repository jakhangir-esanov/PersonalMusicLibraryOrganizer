using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;

namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface ISingerRepository
{
    Task CreateAsync(Singer singer);
    void Update(Singer singer);
    void Delete(Singer singer);
    Task<Singer> GetByIdAsync(long id);
    IQueryable<Singer> GetAll();
    Singer GetByEmail(string email);
}
