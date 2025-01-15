using Infrastructure.Database;

namespace Presentation.Extensions;

public static class SeedExtensions
{
    public static async Task SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        await using ApplicationDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        await dbContext.SeedDataAsync(scope);
    }
}
