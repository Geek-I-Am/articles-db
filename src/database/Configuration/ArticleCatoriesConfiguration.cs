using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class ArticleCatoriesConfiguration : IEntityTypeConfiguration<ArticleCategories>
{
    public void Configure(EntityTypeBuilder<ArticleCategories> builder)
    {
        builder.ToTable(nameof(ArticleCategories));

        builder.HasKey(ac => new { ac.ArticleId, ac.CategoryId });

        builder.HasOne(ac => ac.Article)
            .WithMany(a => a.ArticleCategories)
            .HasForeignKey(ac => ac.ArticleId);
        
        builder.HasOne(ac => ac.Category)
            .WithMany(a => a.ArticleCategories)
            .HasForeignKey(ac => ac.CategoryId);
        
    }
}