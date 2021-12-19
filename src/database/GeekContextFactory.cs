using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Geekiam.Database
{
    internal class GeekContextFactory : IDesignTimeDbContextFactory<GeekContext>
    {
        private static IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public GeekContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GeekContext>();
            builder.UseNpgsql(Configuration.GetConnectionString("postgre"));
            return new GeekContext(builder.Options);
        }
    }
}