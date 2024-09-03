namespace NotesApp.Domain.Entities;

public class Note : Base
{

    public required string Title { get; set; }
    public string? Description { get; set; }
    public required User User { get; set; }
    public required int UserId { get; set; }
}
