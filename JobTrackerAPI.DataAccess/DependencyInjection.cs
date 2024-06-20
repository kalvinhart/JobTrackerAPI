using JobTrackerAPI.DataAccess.Common.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace JobTrackerAPI.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}