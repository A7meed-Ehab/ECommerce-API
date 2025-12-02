using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.Web.Extensions
{
    public static class WebApplicationRegesteration
    {
        public async static Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            var pendingMigrations =await dbContextService.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                dbContextService.Database.Migrate();
            return app;
        }
        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
          await  using var scope = app.Services.CreateAsyncScope();
            var DataInitializerService = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
           await DataInitializerService.InitializeAsync();
            return app;
        }
    }
}