using Microsoft.Extensions.DependencyInjection;
using NotesApp.Domain.Interfaces.Persistence;
using NotesApp.Infrastructure.Repositories;

namespace NotesApp.Infrastructure;

public static class InfrastructureDi
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
