using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Repositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;
using PersonalMusicLibraryOrganizer.Service.DTOs.Albums;
using PersonalMusicLibraryOrganizer.Service.Helpers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Mappers;

namespace PersonalMusicLibraryOrganizer.Service.Services;

public class AlbumService : IAlbumService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AlbumService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Response<AlbumResultDto>> CreateAsync(AlbumCreationDto dto)
    {
        var album = await unitOfWork.AlbumRepository.GetByIdAsync(dto.Id);
        if (album is not null)
            return new Response<AlbumResultDto>
            {
                StatusCode = 403,
                Message = "Already exist!"
            };

        var mapAlbum = mapper.Map<Album>(dto);
        await unitOfWork.AlbumRepository.CreateAsync(mapAlbum);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<AlbumResultDto>(mapAlbum);
        return new Response<AlbumResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<AlbumResultDto>> UpdateAsync(AlbumUpdateDto dto)
    {
        var album = await unitOfWork.AlbumRepository.GetByIdAsync(dto.Id);
        if (album is null)
            return new Response<AlbumResultDto>
            { 
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapAlbum = mapper.Map(dto, album);
        unitOfWork.AlbumRepository.Update(mapAlbum);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<AlbumResultDto>(mapAlbum);
        return new Response<AlbumResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var album = await unitOfWork.AlbumRepository.GetByIdAsync(id);
        if (album is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        unitOfWork.AlbumRepository.Delete(album);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = true
        };
    }
    public async Task<Response<AlbumResultDto>> GetByIdAsync(long id)
    {
        var album = await unitOfWork.AlbumRepository.GetByIdAsync(id);
        if (album is null)
            return new Response<AlbumResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapAlbum = mapper.Map<AlbumResultDto>(album);
        return new Response<AlbumResultDto>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = mapAlbum
        };
    }

    public async Task<Response<IEnumerable<AlbumResultDto>>> GetAllAsync()
    {
        var album = await unitOfWork.AlbumRepository.GetAll().ToListAsync();
        if (album.Count == 0)
            return new Response<IEnumerable<AlbumResultDto>>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var result = new List<AlbumResultDto>();
        foreach (var item in album)
        {
            var res = mapper.Map<AlbumResultDto>(item);
            result.Add(res);
        }

        return new Response<IEnumerable<AlbumResultDto>>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = result
        };
    }
}
