using AutoMapper;
using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;
using PersonalMusicLibraryOrganizer.Service.DTOs.Albums;
using PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;
using PersonalMusicLibraryOrganizer.Service.DTOs.Singers;
using PersonalMusicLibraryOrganizer.Service.DTOs.Songs;
using PersonalMusicLibraryOrganizer.Service.DTOs.Users;

namespace PersonalMusicLibraryOrganizer.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Album
        CreateMap<Album, AlbumCreationDto>().ReverseMap();
        CreateMap<AlbumUpdateDto, Album>().ReverseMap();
        CreateMap<AlbumResultDto, Album>().ReverseMap();

        //Playlist
        CreateMap<Playlist, PlaylistCreationDto>().ReverseMap();
        CreateMap<PlaylistUpdateDto, Playlist>().ReverseMap();
        CreateMap<PlaylistResultDto, Playlist>().ReverseMap();

        //Singer
        CreateMap<Singer, SingerCreationDto>().ReverseMap();
        CreateMap<SingerUpdateDto, Singer>().ReverseMap();
        CreateMap<SingerResultDto, Singer>().ReverseMap();

        //Song
        CreateMap<Song, SongCreationDto>().ReverseMap();
        CreateMap<SongUpdateDto, Song>().ReverseMap();
        CreateMap<SongResultDto, Song>().ReverseMap();

        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();
    }
}
