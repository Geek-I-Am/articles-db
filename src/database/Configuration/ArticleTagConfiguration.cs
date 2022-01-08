using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTags>
{
    public void Configure(EntityTypeBuilder<ArticleTags> builder)
    {
        builder.HasKey(sc => new { sc.ArticleId, sc.TagId });
    }
}