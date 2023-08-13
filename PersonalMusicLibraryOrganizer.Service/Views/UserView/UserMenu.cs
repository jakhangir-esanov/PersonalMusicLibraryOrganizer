using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonalMusicLibraryOrganizer.Service.DTOs.Users;
using PersonalMusicLibraryOrganizer.Service.Security;
using PersonalMusicLibraryOrganizer.Service.Services;

namespace PersonalMusicLibraryOrganizer.Service.Views.UserView;

public class UserMenu
{
    UserService userService = new UserService();

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

        var res = userService.Check(email, password);
        return res.Data;
    }

    public async void Create()
    {
        await Console.Out.WriteLineAsync("1. FirstName: ");
        string firstName = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. LastName: ");
        string lastName = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Email: ");
        string email = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. Password: ");
        string password = Console.ReadLine();

        var hashResult = PasswordHasher.Hash(password);

        UserCreationDto dto = new UserCreationDto
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = hashResult.Password,
            Salt = hashResult.Salt
        };

        var res = await userService.CreateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Update()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteLineAsync("1. FirstName: ");
        string firstName = Console.ReadLine();
        await Console.Out.WriteLineAsync("2. LastName: ");
        string lastName = Console.ReadLine();
        await Console.Out.WriteLineAsync("3. Email: ");
        string email = Console.ReadLine();
        await Console.Out.WriteLineAsync("4. Password: ");
        string password = Console.ReadLine();

        var hashResult = PasswordHasher.Hash(password);

        UserUpdateDto dto = new UserUpdateDto
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = hashResult.Password,
            Salt = hashResult.Salt
        };

        var res = await userService.UpdateAsync(dto);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void Delete()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await userService.DeleteAsync(id);
        await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetById()
    {
        await Console.Out.WriteLineAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var res = await userService.GetByIdAsync(id);
        if(res.StatusCode == 200)
            await Console.Out.WriteLineAsync($"FirstName : {res.Data.FirstName}\nLastName : {res.Data.LastName}\nEmail : {res.Data.Email}\n");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }

    public async void GetAll()
    {
        var res = await userService.GetAllAsync();
        if(res.StatusCode == 200)
            foreach( var i in res.Data)
                await Console.Out.WriteLineAsync($"Id : {i.Id} | FirstName : {i.FirstName} | LastName : {i.LastName} | Email : {i.Email}");
        else
            await Console.Out.WriteLineAsync(res.Message);
    }
}

