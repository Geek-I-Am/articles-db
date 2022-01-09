using System.Collections.Immutable;
using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.ToTable(nameof(Articles));
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.HasIndex(x => x.Url)
                .UseCollation("case_insensitive_collation")
                .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnType(ColumnTypes.UUID)
                .HasDefaultValueSql(PostgreExtensions.UUIDAlgorithm)
                .IsRequired();
            
           builder.Property(x => x.Title)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(x => x.Summary)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType(ColumnTypes.Text);

            builder.Property(x => x.Published)
                .HasColumnType(ColumnTypes.Date)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(286)
                .IsRequired();

            builder.Property(x => x.Created)
                .HasColumnType(ColumnTypes.TimeStamp)
                .IsRequired();
        }
    }
}