using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace API.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityAuthentication(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<JobTrackerDbContext>()
            .AddApiEndpoints();

        return services;
    }

    public static IEndpointRouteBuilder UseIdentityAuthentication(this IEndpointRouteBuilder app)
    {
        app.MapIdentityApi<User>();

        return app;
    }
}