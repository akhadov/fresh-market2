using FreshMarket.Application.Common.Interfaces;
using FreshMarket.WebApi.Services;

namespace FreshMarket.WebApi;

public static class DependencyInjection
{
    public static void AddWebApi(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddEndpointsApiExplorer();

    }
}