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
        builder.Property(x => x.Id)
            .HasColumnType(ColumnTypes.UUID)
            .HasDefaultValueSql(PostgreExtensions.UUIDAlgorithm)
            .IsRequired();
        builder.Property(x => x.Created)
            .HasColumnType(ColumnTypes.TimeStamp)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();
            
        builder.Property(x => x.Modified)
            .HasColumnType(ColumnTypes.TimeStamp)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnUpdate();
        builder.HasOne(ac => ac.Article)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(ac => ac.ArticleId);
        
        builder.HasOne(ac => ac.Tag)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(ac => ac.TagId);
    }
}