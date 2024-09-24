using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Repository;

namespace Store.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var IloggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {

                    var context = services.GetRequiredService<StoreDbContext>();

                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, IloggerFactory);

                }
                catch (Exception ex)
                {
                    var logger = IloggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
