using System;
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
        
        builder.HasData(
            new Categories {Id = Guid.Parse("334e7c6a-9779-4018-90d2-7b7f43a8e101"), Name = "Software Development", Permalink = "software-development", Description = "Software development based articles", Created = DateTime.Now},
            new Categories {Id = Guid.Parse("334e7c6a-9779-4018-90d2-7b7f43a8e102"), Name = "Cryptocurrency", Permalink = "cryptocurrency",Description = "Cryptocurrency related articles", Created = DateTime.Now}
               
        );
    }
}