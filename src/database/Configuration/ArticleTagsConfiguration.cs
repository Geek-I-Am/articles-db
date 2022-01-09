using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class ArticleTagsConfiguration : IEntityTypeConfiguration<ArticleTags>
{
    public void Configure(EntityTypeBuilder<ArticleTags> builder)
    {
        builder.ToTable(nameof(ArticleTags));

        builder.HasKey(ac => new { ac.ArticleId, ac.TagId });
        
        builder.HasOne(ac => ac.Article)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(ac => ac.ArticleId);
        
        builder.HasOne(ac => ac.Tag)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(ac => ac.TagId);
    }
}