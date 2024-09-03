using NotesApp.Application.DTOs;
using NotesApp.Application.Interfaces.Services;
using NotesApp.Domain.Entities;
using NotesApp.Domain.Interfaces.Persistence;

namespace NotesApp.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private static string HashPassword(string password)
    {
        return password + "ayush";
    }
    public async Task<UserResponse> AddAsync(UserRequest entity)
    {
        var user = new User
        {
            Email = entity.Email,
            Name = entity.Name,
            HashedPassword = HashPassword(entity.Password)
        };
        var createdUser = await _userRepository.AddAsync(user);
        return new UserResponse(createdUser.Id, createdUser.Name, createdUser.Email);
    }

    public async Task<List<UserResponse>> GetAsync()
    {
        var users = await _userRepository.GetAsync();
        return users.Select(u => new UserResponse(u.Id, u.Name, u.Email)).ToList();
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : new UserResponse(user.Id, user.Name, user.Email);
    }
}
