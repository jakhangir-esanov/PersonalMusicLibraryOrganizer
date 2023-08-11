using PersonalMusicLibraryOrganizer.Service.DTOs.Singers;
using PersonalMusicLibraryOrganizer.Service.Helpers;

namespace PersonalMusicLibraryOrganizer.Service.Interfaces;

public interface ISingerService
{
    Task<Response<SingerResultDto>> CreateAsync(SingerCreationDto dto);
    Task<Response<SingerResultDto>> UpdateAsync(SingerUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Response<bool> Check(string email, string password);
    Task<Response<SingerResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<SingerResultDto>>> GetAllAsync();
}
