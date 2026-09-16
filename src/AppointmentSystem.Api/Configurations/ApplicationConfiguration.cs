using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddOpenApi();
        services.AddSwaggerGen();
        services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(configurations.GetConnectionString("DefaultConnection"))
        );
        
        return services;
    }
}