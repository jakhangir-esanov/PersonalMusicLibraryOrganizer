using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.DAL.IRepositories;

namespace PersonalMusicLibraryOrganizer.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;

    public UnitOfWork()
    {
        this.appDbContext = new AppDbContext();
        AlbumRepository = new AlbumRepository(appDbContext);
        PlaylistRepository = new PlaylistRepository(appDbContext);
        SingerRepository = new SingerRepositroy(appDbContext);
        SongRepository = new SongRepository(appDbContext);
        UserRepository = new UserRepository(appDbContext);
    }
    public IAlbumRepository AlbumRepository { get; }

    public IPlaylistRepository PlaylistRepository { get; }

    public ISingerRepository SingerRepository { get; }

    public ISongRepository SongRepository { get; }

    public IUserRepository UserRepository { get; }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
