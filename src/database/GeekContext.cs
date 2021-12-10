using System.Reflection;
using Geek.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geek.Database
{
    public class GeekContext : DbContext
    {
        public GeekContext(DbContextOptions<GeekContext> options) : base(options)
        {
        }
        
        public DbSet<Articles> Articles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
            modelBuilder.HasCollation("case_insensitive_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}