using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Repositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;
using PersonalMusicLibraryOrganizer.Service.DTOs.Songs;
using PersonalMusicLibraryOrganizer.Service.Helpers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Mappers;
using System.Net.Http.Headers;

namespace PersonalMusicLibraryOrganizer.Service.Services;

public class SongService : ISongService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public SongService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Response<SongResultDto>> CreateAsync(SongCreationDto dto)
    {
        var song = await unitOfWork.SongRepository.GetByIdAsync(dto.Id);
        if (song is not null)
            return new Response<SongResultDto>
            {
                StatusCode = 403,
                Message = "Already exist!"
            };

        var mapSong = mapper.Map<Song>(dto);
        await unitOfWork.SongRepository.CreateAsync(mapSong);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<SongResultDto>(mapSong);
        return new Response<SongResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<SongResultDto>> UpdateAsync(SongUpdateDto dto)
    {
        var song = await unitOfWork.SongRepository.GetByIdAsync(dto.Id);
        if (song is null)
            return new Response<SongResultDto>
            {
                StatusCode = 404,
                Message = "Not found!",
            };

        var mapSong = mapper.Map(dto, song);
        unitOfWork.SongRepository.Update(mapSong);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<SongResultDto>(mapSong);
        return new Response<SongResultDto>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var song = await unitOfWork.SongRepository.GetByIdAsync(id);
        if (song is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };
        
        unitOfWork.SongRepository.Delete(song);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = true
        };
    }

    public async Task<Response<SongResultDto>> GetById(long id)
    {
        var song = await unitOfWork.SongRepository.GetByIdAsync(id);
        if (song is null)
            return new Response<SongResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapSong = mapper.Map<SongResultDto>(song);
        return new Response<SongResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = mapSong
        };
    }

    public async Task<Response<IEnumerable<SongResultDto>>> GetAllAsync()
    {
        var song = await unitOfWork.SongRepository.GetAll().ToListAsync();
        if (song.Count == 0)
            return new Response<IEnumerable<SongResultDto>>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var result = new List<SongResultDto>();
        foreach (var item in song)
        {
            var res = mapper.Map<SongResultDto>(item);
            result.Add(res);
        }

        return new Response<IEnumerable<SongResultDto>>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = result
        };
    }
}
