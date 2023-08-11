namespace PersonalMusicLibraryOrganizer.DAL.IRepositories;

public interface IUnitOfWork
{
    IAlbumRepository AlbumRepository { get; }
    IPlaylistRepository PlaylistRepository { get; }
    ISingerRepository SingerRepository { get; }
    ISongRepository SongRepository { get; }
    IUserRepository UserRepository { get; }
    Task SaveAsync();
}
