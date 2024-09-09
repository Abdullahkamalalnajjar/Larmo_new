using Enigma.String;
using Larmo.Shared.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Larmo.Shared;

public static class DependencyInjection
{
    public static void AddShared(this IServiceCollection services)
    {
        services.ConfigureGenerics();
    }

    private static void ConfigureGenerics(this IServiceCollection services)
    {
        services.AddEnigmaEncryption(options =>
        {
            options.SymmetricKey = "b14ca5898a4e4133bbce2ea2315a1916";
        });

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenRequestPreProcessor(typeof(ValidationProcessor<>));
        });
    }
}
