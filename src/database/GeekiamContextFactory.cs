using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Geekiam.Database
{
    internal class GeekiamContextFactory : IDesignTimeDbContextFactory<GeekiamContext>
    {
        private static IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public GeekiamContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GeekiamContext>();
            builder.UseNpgsql(Configuration.GetConnectionString("postgre"));
            return new GeekiamContext(builder.Options);
        }
    }
}