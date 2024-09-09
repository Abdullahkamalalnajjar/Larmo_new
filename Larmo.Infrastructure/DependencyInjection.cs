using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using Larmo.Infrastructure.Context;
using Larmo.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Larmo.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureContext(configuration);
        services.ConfigureGenerics();
        services.ConfigureIdentity();
    }

    private static void ConfigureGenerics(this IServiceCollection services)
    {
        services.AddScoped<IOperationRepository, OperationRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped(typeof(IIdentityRepository<>), typeof(IdentityRepository<>));
    }

    private static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    private static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<string>>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
    }
}
