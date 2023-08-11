using PersonalMusicLibraryOrganizer.Service.Views.AlbumView;
using PersonalMusicLibraryOrganizer.Service.Views.PlaylistView;
using PersonalMusicLibraryOrganizer.Service.Views.SingerView;
using PersonalMusicLibraryOrganizer.Service.Views.SongView;
using PersonalMusicLibraryOrganizer.Service.Views.UserView;

namespace PersonalMusicLibraryOrganizer.Service.Views;

public class MainMenu
{
    AlbumMenu albumMenu = new AlbumMenu();
    PlaylistMenu playlistMenu = new PlaylistMenu();
    SingerMenu singerMenu = new SingerMenu();
    SongMenu songMenu = new SongMenu();
    UserMenu userMenu = new UserMenu();

    public void Asosiy()
    {
        while (true)
        {
            Console.WriteLine(@"
1. For User.
2. For Singer.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            switch (choice)
            {
                case 1:
                    ForUser();
                    break;
                case 2:
                    ForSinger();
                    break;
            }
        }
    }

    public void ForUser()
    {
        while (true)
        {
            Console.WriteLine(@"
1. LogIn.
2. SignUp.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            if (choice == 1)
            {
                if (userMenu.Check() == true)
                {
                    UserMenu();
                }
            }
            if (choice == 2)
            {
                userMenu.Create();
            }
        }
    }

    public void ForSinger()
    {
        while (true)
        {
            Console.WriteLine(@"
1. LogIn.
2. SignUp.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            if (choice == 1)
            {
                if (singerMenu.Check())
                {
                    SingerMenu();
                }
            }
            if (choice == 2)
            {
                singerMenu.Create();
            }
        }
    }

    public void UserMenu()
    {
        while (true)
        {
            Console.WriteLine(@"
1. User.
2. Playlist.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            switch (choice)
            {
                case 1:
                    userMenu.Asosiy();
                    break;
                case 2:
                    playlistMenu.Asosiy();
                    break;
            }
        }
    }

    public void SingerMenu()
    {
        while (true)
        {
            Console.WriteLine(@"
1. Singer.
2. Album.
3. Playlist.
4. Song.
0. Exit.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;

            Console.Clear();
            switch (choice)
            {
                case 1:
                    singerMenu.Asosiy();
                    break;
                case 2:
                    albumMenu.Asosiy();
                    break;
                case 3:
                    playlistMenu.Asosiy();
                    break;
                case 4:
                    songMenu.Asosiy();
                    break;
            }
        }
    }
}

