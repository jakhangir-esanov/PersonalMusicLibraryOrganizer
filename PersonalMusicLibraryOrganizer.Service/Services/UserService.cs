using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Repositories;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;
using PersonalMusicLibraryOrganizer.Service.DTOs.Users;
using PersonalMusicLibraryOrganizer.Service.Helpers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Mappers;
using PersonalMusicLibraryOrganizer.Service.Security;

namespace PersonalMusicLibraryOrganizer.Service.Services;

public class UserService : IUserService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }


    public async Task<Response<UserResultDto>> CreateAsync(UserCreationDto dto)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(dto.Id);
        if (user is not null)
            return new Response<UserResultDto>
            {
                StatusCode = 403,
                Message = "Already exist!"
            };

        var mapUser = mapper.Map<User>(dto);
        await unitOfWork.UserRepository.CreateAsync(mapUser);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<UserResultDto>(mapUser);
        return new Response<UserResultDto>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }
    public async Task<Response<UserResultDto>> UpdateAsync(UserUpdateDto dto)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(dto.Id);
        if (user is null)
            return new Response<UserResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var mapUser = mapper.Map(dto, user);
        unitOfWork.UserRepository.Update(mapUser);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<UserResultDto>(mapUser);
        return new Response<UserResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (user is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        unitOfWork.UserRepository.Delete(user);
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
        var user = unitOfWork.UserRepository.GetByEmail(email);
        if (user is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found!",
                Data = false
            };

        var res = PasswordHasher.Verify(password, user.Password, user.Salt);
        if (res is false)
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

    public async Task<Response<UserResultDto>> GetByIdAsync(long id)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (user is null)
            return new Response<UserResultDto>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var res = mapper.Map<UserResultDto>(user);
        return new Response<UserResultDto>
        {
            StatusCode = 200,
            Message = "Successful!",
            Data = res
        };
    }

    public async Task<Response<IEnumerable<UserResultDto>>> GetAllAsync()
    {
        var user = await unitOfWork.UserRepository.GetAll().ToListAsync();
        if (user.Count == 0)
            return new Response<IEnumerable<UserResultDto>>
            {
                StatusCode = 404,
                Message = "Not found!"
            };

        var result = new List<UserResultDto>();
        foreach (var item in user)
        {
            var res = mapper.Map<UserResultDto>(item);
            result.Add(res);
        }

        return new Response<IEnumerable<UserResultDto>>
        { 
            StatusCode = 200,
            Message = "Successful!",
            Data = result
        };
    }
}
