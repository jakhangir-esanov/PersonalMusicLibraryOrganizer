using PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;
using PersonalMusicLibraryOrganizer.Service.Helpers;

namespace PersonalMusicLibraryOrganizer.Service.Interfaces;

public interface IPlaylistService
{
    Task<Response<PlaylistResultDto>> CreateAsync(PlaylistCreationDto dto);
    Task<Response<PlaylistResultDto>> UpdateAsync(PlaylistUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<PlaylistResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<PlaylistResultDto>>> GetAllAsync();
}
