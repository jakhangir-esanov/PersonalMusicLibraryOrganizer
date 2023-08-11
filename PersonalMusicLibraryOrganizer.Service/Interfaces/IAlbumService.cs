using PersonalMusicLibraryOrganizer.Service.DTOs.Albums;
using PersonalMusicLibraryOrganizer.Service.Helpers;

namespace PersonalMusicLibraryOrganizer.Service.Interfaces;

public interface IAlbumService
{
    Task<Response<AlbumResultDto>> CreateAsync(AlbumCreationDto dto);
    Task<Response<AlbumResultDto>> UpdateAsync(AlbumUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<AlbumResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<AlbumResultDto>>> GetAllAsync();
}
