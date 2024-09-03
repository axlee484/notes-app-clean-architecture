using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.DTOs;
using NotesApp.Application.Interfaces.Services;

namespace NotesApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    [HttpGet]
    public async Task<List<UserResponse>> Get()
    {
        var users = await _userService.GetAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<UserResponse?> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<UserResponse> Add([FromBody] UserRequest entity)
    {
        var user = await _userService.AddAsync(entity);
        return user;
    }
}
