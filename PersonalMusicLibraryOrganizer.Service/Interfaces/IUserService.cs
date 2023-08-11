using PersonalMusicLibraryOrganizer.Service.DTOs.Users;
using PersonalMusicLibraryOrganizer.Service.Helpers;

namespace PersonalMusicLibraryOrganizer.Service.Interfaces;

public interface IUserService
{
    Task<Response<UserResultDto>> CreateAsync(UserCreationDto dto);
    Task<Response<UserResultDto>> UpdateAsync(UserUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Response<bool> Check(string email, string password);
    Task<Response<UserResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<UserResultDto>>> GetAllAsync();
}
