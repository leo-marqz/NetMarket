using Api;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Business.Data;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope()){
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try{
                    var context = services.GetRequiredService<MarketplaceDbContext>();
                    await context.Database.MigrateAsync();

                    await LoadInitialData.LoadAsync(context, loggerFactory);
                }
                catch (Exception ex){
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error en el proceso de migracion");
                }
            };

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }

}
