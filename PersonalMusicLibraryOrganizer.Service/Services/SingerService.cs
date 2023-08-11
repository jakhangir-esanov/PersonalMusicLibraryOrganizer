using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Repositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;
using PersonalMusicLibraryOrganizer.Service.DTOs.Singers;
using PersonalMusicLibraryOrganizer.Service.Helpers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Mappers;
using PersonalMusicLibraryOrganizer.Service.Security;

namespace PersonalMusicLibraryOrganizer.Service.Services;

public class SingerService : ISingerService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public SingerService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Response<SingerResultDto>> CreateAsync(SingerCreationDto dto)
    {
        var singer = await unitOfWork.SingerRepository.GetByIdAsync(dto.Id);
        if (singer is not null)
            return new Response<SingerResultDto>
            {
                StatusCode = 403,
                Message = "Already exist!"
            };

        var mapSinger = mapper.Map<Singer>(dto);
        await unitOfWork.SingerRepository.CreateAsync(mapSinger);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<SingerResultDto>(mapSinger);
        return new Response<SingerResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }
    public async Task<Response<SingerResultDto>> UpdateAsync(SingerUpdateDto dto)
    {
        var singer = await unitOfWork.SingerRepository.GetByIdAsync(dto.Id);
        if (singer is null)
            return new Response<SingerResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapSinger = mapper.Map(dto, singer);
        unitOfWork.SingerRepository.Update(mapSinger);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<SingerResultDto>(mapSinger);
        return new Response<SingerResultDto>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var singer = await unitOfWork.SingerRepository.GetByIdAsync(id);
        if (singer is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        unitOfWork.SingerRepository.Delete(singer);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = true
        };
    }

    public Response<bool> Check(string email, string password)
    {
        var singer = unitOfWork.SingerRepository.GetByEmail(email);
        if (singer is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        var result = PasswordHasher.Verify(password, singer.Password, singer.Salt);
        if (result is false)
            return new Response<bool>
            {
                StatusCode = 400,
                Message = "Password is not correct!",
                Data = false
            };

        return new Response<bool>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = true
        };
    }

    public async Task<Response<SingerResultDto>> GetByIdAsync(long id)
    {
        var singer = await unitOfWork.SingerRepository.GetByIdAsync(id);
        if (singer is null)
            return new Response<SingerResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapSinger = mapper.Map<SingerResultDto>(singer);
        return new Response<SingerResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = mapSinger
        };
    }

    public async Task<Response<IEnumerable<SingerResultDto>>> GetAllAsync()
    {
        var singer = await unitOfWork.SingerRepository.GetAll().ToListAsync();
        if (singer.Count == 0)
            return new Response<IEnumerable<SingerResultDto>>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var result = new List<SingerResultDto>();
        foreach (var item in singer)
        {
            var res = mapper.Map<SingerResultDto>(item);
            result.Add(res);
        }

        return new Response<IEnumerable<SingerResultDto>>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = result
        };
    }
}
