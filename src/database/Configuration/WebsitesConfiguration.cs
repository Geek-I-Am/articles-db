using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class WebsitesConfiguration : IEntityTypeConfiguration<Websites>
{
    public void Configure(EntityTypeBuilder<Websites> builder)
    {
        builder.ToTable(nameof(Websites));
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
        builder.Property(x => x.Created)
            .HasColumnType(ColumnTypes.TimeStamp)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();
            
        builder.Property(x => x.Modified)
            .HasColumnType(ColumnTypes.TimeStamp)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnUpdate();
            
        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();
        
        builder.Property(x => x.Url)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(286)
            .IsRequired();
        
       
        
        builder.Property(x => x.Active)
            .HasColumnType(ColumnTypes.Boolean)
            .HasDefaultValue(true)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Moderate)
            .HasColumnType(ColumnTypes.Boolean)
            .HasDefaultValue(true)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Active)
            .HasColumnType(ColumnTypes.Boolean)
            .IsRequired();
        
        builder.Property(x => x.Moderate)
            .HasColumnType(ColumnTypes.Boolean)
            .IsRequired();
        
        
        builder.HasIndex(x => x.Url)
            .UseCollation("case_insensitive_collation")
            .IsUnique();
        
    
    }
}