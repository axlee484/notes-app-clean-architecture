namespace NotesApp.Domain.Entities;

public class User : Base
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string HashedPassword { get; set; }
    public List<Note>? Notes { get; set; }
}
