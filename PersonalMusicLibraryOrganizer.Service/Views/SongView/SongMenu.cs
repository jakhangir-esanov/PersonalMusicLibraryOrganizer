using PersonalMusicLibraryOrganizer.Service.DTOs.Songs;
using PersonalMusicLibraryOrganizer.Service.Services;

namespace PersonalMusicLibraryOrganizer.Service.Views.SongView;

public class SongMenu
{
    SongService songService = new SongService();

    public void Asosiy()
    {
        while (true)
        {
            Console.WriteLine(@"
1. Create.
2. Update.
3. Delete.
4. GetById.
5. GetAll.
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
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    GetById();
                    break;
                case 5:
                    GetAll();
                    break;
            }
        }
    }

    public async void Create()
    {
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Genre: ");
        string genre = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Year(yyyy-mm-dd): ");
        string year = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. Give song FilePath: ");
        string filePath = Console.ReadLine();
        await Console.Out.WriteLineAsync("5. SingerName: ");
        string singerName = Console.ReadLine();
        await Console.Out.WriteLineAsync("6. SingerId: ");
        long singerId = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("7. AlbumId: ");
        long albumId = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("8. PlaylistId: ");
        long playlistId = long.Parse(Console.ReadLine());

        SongCreationDto dto = new SongCreationDto
        {
            Title = title,
            Genre = genre,
            Year = DateTime.Parse(year),
            FilePath = filePath,
            SingerName = singerName,
            SingerId = singerId,
            AlbumId = albumId,
            PlaylistId = playlistId
        };

        var res = await songService.CreateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Update()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("1. Title: ");
        string title = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. Genre: ");
        string genre = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Year(yyyy-mm-dd): ");
        string year = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. SingerName: ");
        string singerName = Console.ReadLine();
        await Console.Out.WriteLineAsync("5. SingerId: ");
        long singerId = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("6. AlbumId: ");
        long albumId = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("7. PlaylistId: ");
        long playlistId = long.Parse(Console.ReadLine());

        SongUpdateDto dto = new SongUpdateDto
        {
            Id = id,
            Title = title,
            Genre = genre,
            Year = DateTime.Parse(year),
            SingerName = singerName,
            SingerId = singerId,
            AlbumId = albumId,
            PlaylistId = playlistId
        };

        var res = await songService.UpdateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Delete()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await songService.DeleteAsync(id);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetById()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await songService.GetById(id);
        if(res.StatusCode == 200)
            await Console.Out.WriteLineAsync($"Title : {res.Data.Title}\nGenre : {res.Data.Genre}\nYear : {res.Data.Year}\nSingerName : {res.Data.SingerName}\nSingerId : {res.Data.SingerId}\nAlbumId : {res.Data.AlbumId}\nPlaylistId : {res.Data.PlaylistId}\n");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetAll()
    {
        var res = await songService.GetAllAsync();
        if (res.StatusCode == 200)
            foreach (var i in res.Data)
                await Console.Out.WriteLineAsync($"Title : {i.Title} | Genre : {i.Genre} | Year : {i.Year} | SingerName : {i.SingerName} | SingerId : {i.SingerId} | AlbumId : {i.AlbumId} | PlaylistId : {i.PlaylistId}");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }
}
