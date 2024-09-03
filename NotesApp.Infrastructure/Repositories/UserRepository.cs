using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Entities;
using NotesApp.Domain.Interfaces.Persistence;

namespace NotesApp.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public async Task<User> AddAsync(User entity)
    {
        var userdata = await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return userdata.Entity;
    }

    public async Task<List<User>> GetAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        return user;
    }
}
