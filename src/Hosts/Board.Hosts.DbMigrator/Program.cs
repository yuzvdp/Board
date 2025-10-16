using Microsoft.EntityFrameworkCore;

namespace Board.Hosts.DbMigrator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddServices(hostContext.Configuration);
            }).Build();
            await MigrateAsync(host.Services);
            Console.ReadLine();
        }

        private static async Task MigrateAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<MigrationDbContext>();
            context.Database.EnsureCreated();
            await context.Database.MigrateAsync();
        }
    }
}