using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.Service.Services;
using PersonalMusicLibraryOrganizer.Service.DTOs.Playlists;
using NAudio.Wave;

namespace PersonalMusicLibraryOrganizer.Service.Views.PlaylistView;

public class PlaylistMenu
{
    PlaylistService playlistService = new PlaylistService();
    SongService songService = new SongService();
    AppDbContext dbContext = new AppDbContext();
    public void Asosiy()
    {
        while (true)
        {
            Console.WriteLine(@"
1. Create.
2. PlaylistMusics.
3. PlayMusic.
4. Update.
5. Delete.
6. GetById.
7. GetAll.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            switch (choice)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    GetAllP();
                    break;
                case 3:
                    MusicPlay();
                    break;
                case 4:
                    Update();
                    break;
                case 5:
                    Delete();
                    break;
                case 6:
                    GetById();
                    break;
                case 7:
                    GetAll();
                    break;
            }
        }
    }

    public async void GetAllP()
    {
        var res = await dbContext.Songs.Include(t => t.Playlist).ToListAsync();
        
        if(res.Count == 0)
        foreach (var i in res)
            await Console.Out.WriteLineAsync($"Id : {i.Id} | Title : {i.Title}");
        else
            await Console.Out.WriteLineAsync("Nothing found!");
    }

    public async void Create()
    {
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Description: ");
        string description = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. UserName: ");
        string userName = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. UserId: ");
        long userId = long.Parse(Console.ReadLine());

        PlaylistCreationDto dto = new PlaylistCreationDto
        {
            Title = title,
            Description = description,
            UserName = userName,
            UserId = userId
        };

        var res = await playlistService.CreateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Update()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Description: ");
        string description = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. UserName: ");
        string userName = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. UserId: ");
        long userId = long.Parse(Console.ReadLine());

        PlaylistUpdateDto dto = new PlaylistUpdateDto
        {
            Id = id,
            Title = title,
            Description = description,
            UserName = userName,
            UserId = userId
        };

        var res = await playlistService.UpdateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Delete()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await playlistService.DeleteAsync(id);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetById()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await playlistService.GetByIdAsync(id);
        if (res.StatusCode == 200)
            await Console.Out.WriteLineAsync($"Title : {res.Data.Title}\nDescription : {res.Data.Description}\nUserName : {res.Data.UserName}\nUserId : {res.Data.UserId}\n");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetAll()
    {
        var res = await playlistService.GetAllAsync();

        if (res.StatusCode == 200)
            foreach (var i in res.Data)
                await Console.Out.WriteLineAsync($"Title : {i.Title} | Description : {i.Description} | UserName : {i.UserName} | UserId : {i.UserId}");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void MusicPlay()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());


        var result = await songService.GetById(id);


        if (result is not null)
        {
            string filePath = result.Data.FilePath; 

            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                Console.WriteLine("Playing music... Press any key to stop.");
                Console.ReadKey();

                outputDevice.Stop();
            }
        }
    }
}
