
using NotesApp.Application.Interfaces.Services;
using NotesApp.Application.Services;
using NotesApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddInfrastructure();
var app = builder.Build();
app.MapControllers();
app.Run();
