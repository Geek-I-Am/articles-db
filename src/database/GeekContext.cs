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
        public DbSet<Tags> Tags { get; set; }
        public DbSet<ArticleTags> ArticleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
            modelBuilder.HasCollation("case_insensitive_collation", "en-u-ks-primary", "icu",
                false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}