using PersonalMusicLibraryOrganizer.Service.DTOs.Songs;
using PersonalMusicLibraryOrganizer.Service.Helpers;

namespace PersonalMusicLibraryOrganizer.Service.Interfaces;

public interface ISongService
{
    Task<Response<SongResultDto>> CreateAsync(SongCreationDto dto);
    Task<Response<SongResultDto>> UpdateAsync(SongUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<SongResultDto>> GetById(long id);
    Task<Response<IEnumerable<SongResultDto>>> GetAllAsync();
}
