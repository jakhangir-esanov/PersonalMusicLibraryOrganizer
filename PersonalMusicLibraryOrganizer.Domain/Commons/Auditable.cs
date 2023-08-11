namespace PersonalMusicLibraryOrganizer.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(5);
}
