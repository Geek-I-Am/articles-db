using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Authors>
{
    public void Configure(EntityTypeBuilder<Authors> builder)
    {
        builder.ToTable(nameof(Authors));
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id)
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
        
        builder.Property(x => x.FirstName)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(65)
            .IsRequired();
        
        builder.Property(x => x.Biography)
            .HasColumnType(ColumnTypes.Text);
        
       
        
    }
}