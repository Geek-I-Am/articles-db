using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class ArticleTagsConfiguration : IEntityTypeConfiguration<ArticleTags>
{
    public void Configure(EntityTypeBuilder<ArticleTags> builder)
    {
        builder.ToTable(nameof(ArticleTags));
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnType(ColumnTypes.UUID)
            .HasDefaultValueSql(PostgreExtensions.UUIDAlgorithm)
            .IsRequired();

        builder.Property(x => x.ArticleId)
            .HasColumnType(ColumnTypes.UUID)
            .IsRequired();

        builder.Property(x => x.TagId)
            .HasColumnType(ColumnTypes.UUID)
            .IsRequired();
    }
}