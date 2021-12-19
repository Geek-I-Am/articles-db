using System.Reflection;
using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geekiam.Database
{
    public class GeekContext : DbContext
    {
        public GeekContext(DbContextOptions<GeekContext> options) : base(options)
        {
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ArticleTags> ArticleTags { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension(PostgreExtensions.UUIDGenerator);
            modelBuilder.HasCollation("case_insensitive_collation", "en-u-ks-primary", "icu",
                false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}