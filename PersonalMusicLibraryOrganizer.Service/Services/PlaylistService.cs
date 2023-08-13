using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Repositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;
using PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;
using PersonalMusicLibraryOrganizer.Service.Helpers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Mappers;

namespace PersonalMusicLibraryOrganizer.Service.Services;

public class PlaylistService : IPlaylistService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PlaylistService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Response<PlaylistResultDto>> CreateAsync(PlaylistCreationDto dto)
    {
        var playlist = await unitOfWork.PlaylistRepository.GetByIdAsync(dto.Id);
        if (playlist is not null)
            return new Response<PlaylistResultDto>
            { 
                StatusCode = 403,
                Message = "Already exist!"
            };

        var user = await unitOfWork.UserRepository.GetByIdAsync(dto.UserId);
        if (user is null)
            return new Response<PlaylistResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapPlaylist = mapper.Map<Playlist>(dto);
        await unitOfWork.PlaylistRepository.CreateAsync(mapPlaylist);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<PlaylistResultDto>(mapPlaylist);
        return new Response<PlaylistResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<PlaylistResultDto>> UpdateAsync(PlaylistUpdateDto dto)
    {
        var playlist = await unitOfWork.PlaylistRepository.GetByIdAsync(dto.Id);
        if (playlist is null)
            return new Response<PlaylistResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapPlaylist = mapper.Map(dto, playlist);
        unitOfWork.PlaylistRepository.Update(mapPlaylist);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<PlaylistResultDto>(mapPlaylist);
        return new Response<PlaylistResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var playlist = await unitOfWork.PlaylistRepository.GetByIdAsync(id);
        if (playlist is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        unitOfWork.PlaylistRepository.Delete(playlist);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = true
        };
    }

    public async Task<Response<PlaylistResultDto>> GetByIdAsync(long id)
    {
        var playlist = await unitOfWork.PlaylistRepository.GetByIdAsync(id);
        if (playlist is null)
            return new Response<PlaylistResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapPlaylist = mapper.Map<PlaylistResultDto>(playlist);
        return new Response<PlaylistResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = mapPlaylist
        };
    }

    public async Task<Response<IEnumerable<PlaylistResultDto>>> GetAllAsync()
    {
        var playlist = await unitOfWork.PlaylistRepository.GetAll().ToListAsync();
        if (playlist.Count == 0)
            return new Response<IEnumerable<PlaylistResultDto>>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var result = new List<PlaylistResultDto>();
        foreach (var item in playlist)
        {
            var res = mapper.Map<PlaylistResultDto>(item);
            result.Add(res);
        };

        return new Response<IEnumerable<PlaylistResultDto>>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = result
        };
    }
}
