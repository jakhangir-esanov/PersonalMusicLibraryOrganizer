using Microsoft.EntityFrameworkCore;
using PersonalMusicLibraryOrganizer.Domain.Entities.Albums;
using PersonalMusicLibraryOrganizer.Domain.Entities.Playlists;
using PersonalMusicLibraryOrganizer.Domain.Entities.Singers;
using PersonalMusicLibraryOrganizer.Domain.Entities.Songs;
using PersonalMusicLibraryOrganizer.Domain.Entities.Users;

namespace PersonalMusicLibraryOrganizer.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; } = default!;
    public DbSet<Playlist> Playlists { get; set; } = default!;
    public DbSet<Singer> Singers { get; set; } = default!;
    public DbSet<Song> Songs { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server = DESKTOP-HQ3E7VT\\SQLEXPRESS; Database = MusicLibrary;Trusted_Connection=true; TrustServerCertificate=true; Encrypt=False;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasMany(x => x.Songs)
            .WithOne(x => x.Album)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Playlist>()
            .HasMany(x => x.Songs)
            .WithOne(x => x.Playlist)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Song>()
            .HasOne(t => t.Singer)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
