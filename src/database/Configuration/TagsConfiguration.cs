using Geek.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geek.Database.Configuration;

public class TagsConfiguration : IEntityTypeConfiguration<Tags>
{
    public void Configure(EntityTypeBuilder<Tags> builder)
    {
        builder.ToTable(nameof(Tags));
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnType(ColumnTypes.UUID)
            .HasDefaultValueSql(PostgreExtensions.UUIDAlgorithm)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .UseCollation("case_insensitive_collation")
            .IsUnique();

        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(286)
            .IsRequired();

        builder.Property(x => x.Created)
            .HasColumnType(ColumnTypes.TimeStamp)
            .IsRequired();
    }
}