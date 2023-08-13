using NAudio.Wave;
using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.DAL.Contexts;
using PersonalMusicLibraryOrganizer.Service.Services;
using PersonalMusicLibraryOrganizer.Service.DTOs.Albums;
using PersonalMusicLibraryOrganizer.Service.Views.SingerView;

namespace PersonalMusicLibraryOrganizer.Service.Views.AlbumView;

public class AlbumMenu
{
    SingerMenu singerMenu = new SingerMenu();
    AlbumService albumService = new AlbumService();
    AppDbContext dbContext = new AppDbContext();
    SongService songService = new SongService();
    public void Asosiy()
    {
        while (true)
        {
            Console.WriteLine(@"
1. Create.
2. AlbumMusics.
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
                    GetAllA();
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

    public async void GetAllA()
    {
        var res = await dbContext.Songs.Include(t => t.Album).ToListAsync();

        if (res.Count != 0)
            foreach (var i in res)
                await Console.Out.WriteLineAsync($"Id : {i.Id} | Title : {i.Title}");
        else
            await Console.Out.WriteLineAsync("Nothing found!");
    }
    public async void Create()
    {
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Year(yyyy-mm-dd): ");
        string year = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. SingerName: ");
        string singerName = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. SingerId: ");
        long stringId = long.Parse(Console.ReadLine());

        AlbumCreationDto dto = new AlbumCreationDto
        {
            Title = title,
            Year = DateTime.Parse(year),
            SingerName = singerName,
            SingerId = stringId
        };

        var res = await albumService.CreateAsync(dto);
        if (res.StatusCode == 404)
        {
            Console.WriteLine("Bunday Singer mavjud emas!");
            await Console.Out.WriteLineAsync("Mavjud Singerlar: ");
            singerMenu.GetAll();
        }
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Update()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Year(yyyy-mm-dd): ");
        string year = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. SingerName: ");
        string singerName = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. SingerId: ");
        long stringId = long.Parse(Console.ReadLine());

        AlbumUpdateDto dto = new AlbumUpdateDto
        {
            Id = id,
            Title = title,
            Year = DateTime.Parse(year),
            SingerName = singerName,
            SingerId = stringId
        };

        var res = await albumService.UpdateAsync(dto);
        Console.WriteLine(res.Message);
    }

    public async void Delete()
    {
        await Console.Out.WriteLineAsync("1. Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await albumService.DeleteAsync(id);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetById()
    {
        await Console.Out.WriteLineAsync("1. Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await albumService.GetByIdAsync(id);
        if (res.StatusCode == 200)
            await Console.Out.WriteLineAsync($"Title : {res.Data.Title}\nYear : {res.Data.Year}\nSingerName : {res.Data.SingerName}\nSingerId : {res.Data.SingerId}");
        else
            Console.WriteLine(res.Message);
    }

    public async void GetAll()
    {
        var res = await albumService.GetAllAsync();
        if (res.StatusCode == 200)
            foreach (var i in res.Data)
                await Console.Out.WriteLineAsync($"Id : {i.Id} | Title : {i.Title} | Year : {i.Year} | SingerName : {i.SingerName} | SingerId : {i.SingerId}");
        else
            Console.WriteLine(res.Message);
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
