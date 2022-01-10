using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisations>
{
    public void Configure(EntityTypeBuilder<Organisations> builder)
    {
        builder.ToTable(nameof(Organisations));
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
            
        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();
        
        builder.Property(x => x.Url)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(286)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnType(ColumnTypes.Text);
    }
}