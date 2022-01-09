using System;
using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

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
            new Tags
            {
                Id = Guid.Parse("434e7c6a-9779-4018-90d2-7b7f43a8e101"), Name = "Bitcoin", Permalink = "bitcoin",
                Description = "bitcoin articles", Created = DateTime.Now
            },
            new Tags
            {
                Id = Guid.Parse("434e7c6a-9779-4018-90d2-7b7f43a8e102"), Name = "Crypto",
                Permalink = "crypto", Description = "Crypto related articles", Created = DateTime.Now
            }
        );
    }
}