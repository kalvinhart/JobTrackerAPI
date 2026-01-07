using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        JobTrackerDbContext dbContext = scope.ServiceProvider.GetRequiredService<JobTrackerDbContext>();

        dbContext.Database.Migrate();
    }
}