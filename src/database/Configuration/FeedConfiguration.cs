using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geekiam.Database.Configuration;

public class FeedConfiguration : IEntityTypeConfiguration<Feeds>
{
    public void Configure(EntityTypeBuilder<Feeds> builder)
    {
        builder.ToTable(nameof(Feeds));
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
        
        builder.HasIndex(x => x.Url)
            .UseCollation("case_insensitive_collation")
            .IsUnique();
        
        builder.Property(x => x.Title)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();
        
    

        builder.HasOne(x => x.Website)
            .WithMany(x => x.Feeds)
            .HasForeignKey(x => x.WebsiteID);
    }
}