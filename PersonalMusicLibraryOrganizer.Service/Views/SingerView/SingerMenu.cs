using PersonalMusicLibraryOrganizer.Service.DTOs.Singers;
using PersonalMusicLibraryOrganizer.Service.Interfaces;
using PersonalMusicLibraryOrganizer.Service.Security;
using PersonalMusicLibraryOrganizer.Service.Services;

namespace PersonalMusicLibraryOrganizer.Service.Views.SingerView;

public class SingerMenu
{
    SingerService singerService = new SingerService();

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

    public bool Check()
    {
        Console.WriteLine("1. Enter email: ");
        string email = Console.ReadLine();
        Console.WriteLine("2. Enter password: ");
        string password = Console.ReadLine();

        var res = singerService.Check(email, password);
        return res.Data;
    }


    public async void Create()
    {
        await Console.Out.WriteLineAsync("1. FullName: ");
        string fullName = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. DateOfBirth(yyyy-mm-dd): ");
        string dateOfBirth = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Country: ");
        string country = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. Email: ");
        string email = Console.ReadLine();
        await Console.Out.WriteLineAsync("5. Password: ");
        string password = Console.ReadLine();
        
        var hashResult = PasswordHasher.Hash(password);

        SingerCreationDto dto = new SingerCreationDto
        {
            FullName = fullName,
            DateOfBirth = DateTime.Parse(dateOfBirth),
            Country = country,
            Email = email,
            Password = hashResult.Password,
            Salt = hashResult.Salt
        };

        var res = await singerService.CreateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Update()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("1. FullName: ");
        string fullName = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. DateOfBirth(yyyy-mm-dd): ");
        string dateOfBirth = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Country: ");
        string country = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. Email: ");
        string email = Console.ReadLine();
        await Console.Out.WriteLineAsync("5. Password: ");
        string password = Console.ReadLine();

        var hashResult = PasswordHasher.Hash(password);

        SingerUpdateDto dto = new SingerUpdateDto
        {
            Id = id,
            FullName = fullName,
            DateOfBirth = DateTime.Parse(dateOfBirth),
            Country = country,
            Email = email,
            Password = hashResult.Password,
            Salt = hashResult.Salt
        };

        var res = await singerService.UpdateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Delete()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await singerService.DeleteAsync(id);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetById()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await singerService.GetByIdAsync(id);
        if(res.StatusCode == 200)
            await Console.Out.WriteLineAsync($"FullName : {res.Data.FullName}\nDateOfBirth : {res.Data.DateOfBirth}\nCountry : {res.Data.Country}\nEmail : {res.Data.Email}");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetAll()
    {
        var res = await singerService.GetAllAsync();
        if(res.StatusCode == 200)
            foreach( var i in res.Data)
                await Console.Out.WriteLineAsync($"FullName : {i.FullName} | DateOfBirth : {i.DateOfBirth} | Country : {i.Country} | Email : {i.Email}");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }
}
