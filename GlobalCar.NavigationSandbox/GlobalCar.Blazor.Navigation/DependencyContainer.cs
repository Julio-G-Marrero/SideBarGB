using Microsoft.Extensions.DependencyInjection;

namespace GlobalCar.Blazor.Navigation;

public static class DependencyContainer
{
    public static IServiceCollection AddNavigationComponents(this IServiceCollection services)
    {
        return services;
    }
}
