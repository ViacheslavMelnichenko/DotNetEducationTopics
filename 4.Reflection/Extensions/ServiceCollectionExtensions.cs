using System.Reflection;
using _4.Reflection.Attributes;
using _4.Reflection.Modules;

namespace _4.Reflection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AutoRegisterServicesFromAssembly(this IServiceCollection services)
    {
        var autoRegisteredServices = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => Attribute.IsDefined(type, typeof(AutoRegisterAttribute)))
            .ToList();

        foreach (var autoRegisteredService in autoRegisteredServices)
        {
            var attribute = Attribute.GetCustomAttribute(autoRegisteredService, typeof(AutoRegisterAttribute)) as AutoRegisterAttribute;

            if (attribute == null)
            {
                continue;
            }

            switch (attribute.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(autoRegisteredService);
                    break;

                case ServiceLifetime.Scoped:
                    services.AddScoped(autoRegisteredService);
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(autoRegisteredService);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return services;
    }

    public static IServiceCollection AutoRegisterModulesFromAssembly(this IServiceCollection services)
    {
        var modules = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type =>
                type.GetMethods()
                    .Any(m => m is {Name: nameof(IModule.AddServices), IsStatic: true} 
                              && type.IsClass))
            .ToList();

        foreach (var module in modules)
        {
            services.AddSingleton(module);
        }

        return services;
    }
}