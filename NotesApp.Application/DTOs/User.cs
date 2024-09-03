namespace NotesApp.Application.DTOs;

public record UserRequest(string Name, string Email, string Password);
public record UserResponse(int Id, string Name, string Email);
