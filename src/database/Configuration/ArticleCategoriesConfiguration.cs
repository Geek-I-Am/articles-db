using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class ArticleCategoriesConfiguration : IEntityTypeConfiguration<ArticleCategories>
{
    public void Configure(EntityTypeBuilder<ArticleCategories> builder)
    {
        builder.HasKey(sc => new { sc.ArticleId, sc.CategoryId });
    }
}