using Geek.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geek.Database.Configuration;

public class ArticleCategoriesConfiguration : IEntityTypeConfiguration<ArticleCategories>
{
    public void Configure(EntityTypeBuilder<ArticleCategories> builder)
    {
        builder.ToTable(nameof(ArticleCategories));
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

        builder.Property(x => x.CategoryId)
            .HasColumnType(ColumnTypes.UUID)
            .IsRequired();
    }
}