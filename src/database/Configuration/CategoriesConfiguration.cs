using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.ToTable(nameof(Categories));
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
        
        builder.Property(x => x.Description)
            .HasColumnType(ColumnTypes.Text);
        
        builder.Property(x => x.Permalink)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(55)
            .IsRequired();

        builder.Property(x => x.Created)
            .HasColumnType(ColumnTypes.TimeStamp)
            .IsRequired();
    }
}