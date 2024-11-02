using B3.CalculoRendimentos.Api.Application;
using B3.CalculoRendimentos.Domain.Services;

namespace B3.CalculoRendimentos.Api.Config;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Application
        services.AddScoped<ICalculoRendimentoUseCase, CalculoRendimentoUseCase>();

        // Domain
        services.AddScoped<ICalculoRendimentoService, CalculoRendimentoCdbService>();
    }
}