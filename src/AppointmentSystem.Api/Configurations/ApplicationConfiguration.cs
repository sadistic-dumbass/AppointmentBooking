using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Application.Services;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddOpenApi();
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddDatabase(configurations);
        services.AddApplicationServices();
        services.AddInfrastructureServices();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configurations.GetConnectionString("DefaultConnection")
            ));

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        return services;
    }

    private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        return services;
    }
}
