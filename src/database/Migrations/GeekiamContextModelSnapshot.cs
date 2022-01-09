﻿// <auto-generated />
using System;
using Geekiam.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Geekiam.Database.Migrations
{
    [DbContext(typeof(GeekiamContext))]
    partial class GeekiamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Npgsql:CollationDefinition:case_insensitive_collation", "en-u-ks-primary,en-u-ks-primary,icu,False")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleCategories", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArticleCategoriesArticleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArticleCategoriesCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ArticleCategoriesArticleId", "ArticleCategoriesCategoryId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleTags", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArticleTagsArticleId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArticleTagsTagId")
                        .HasColumnType("uuid");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.HasIndex("ArticleTagsArticleId", "ArticleTagsTagId");

                    b.ToTable("ArticleTags");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Articles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("Published")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(286)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Url")
                        .IsUnique()
                        .UseCollation(new[] { "case_insensitive_collation" });

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Authors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Categories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(286)
                        .HasColumnType("varchar");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique()
                        .UseCollation(new[] { "case_insensitive_collation" });

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("334e7c6a-9779-4018-90d2-7b7f43a8e101"),
                            Created = new DateTime(2022, 1, 9, 21, 56, 13, 668, DateTimeKind.Local).AddTicks(4162),
                            Description = "Software development based articles",
                            Name = "Software Development",
                            Permalink = "software-development"
                        },
                        new
                        {
                            Id = new Guid("334e7c6a-9779-4018-90d2-7b7f43a8e102"),
                            Created = new DateTime(2022, 1, 9, 21, 56, 13, 677, DateTimeKind.Local).AddTicks(3886),
                            Description = "Cryptocurrency related articles",
                            Name = "Cryptocurrency",
                            Permalink = "cryptocurrency"
                        });
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Tags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(286)
                        .HasColumnType("varchar");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique()
                        .UseCollation(new[] { "case_insensitive_collation" });

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("434e7c6a-9779-4018-90d2-7b7f43a8e101"),
                            Created = new DateTime(2022, 1, 9, 21, 56, 13, 679, DateTimeKind.Local).AddTicks(4796),
                            Description = "bitcoin articles",
                            Name = "Bitcoin",
                            Permalink = "bitcoin"
                        },
                        new
                        {
                            Id = new Guid("434e7c6a-9779-4018-90d2-7b7f43a8e102"),
                            Created = new DateTime(2022, 1, 9, 21, 56, 13, 679, DateTimeKind.Local).AddTicks(5090),
                            Description = "Crypto related articles",
                            Name = "Crypto",
                            Permalink = "crypto"
                        });
                });

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleCategories", b =>
                {
                    b.HasOne("Geekiam.Database.Entities.Articles", "Article")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geekiam.Database.Entities.Categories", "Category")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geekiam.Database.Entities.ArticleCategories", null)
                        .WithMany("Articles")
                        .HasForeignKey("ArticleCategoriesArticleId", "ArticleCategoriesCategoryId");

                    b.Navigation("Article");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleTags", b =>
                {
                    b.HasOne("Geekiam.Database.Entities.Articles", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geekiam.Database.Entities.Tags", "Tag")
                        .WithMany("ArticleTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geekiam.Database.Entities.ArticleTags", null)
                        .WithMany("Articles")
                        .HasForeignKey("ArticleTagsArticleId", "ArticleTagsTagId");

                    b.Navigation("Article");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Articles", b =>
                {
                    b.HasOne("Geekiam.Database.Entities.Authors", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleCategories", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.ArticleTags", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Articles", b =>
                {
                    b.Navigation("ArticleCategories");

                    b.Navigation("ArticleTags");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Authors", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Categories", b =>
                {
                    b.Navigation("ArticleCategories");
                });

            modelBuilder.Entity("Geekiam.Database.Entities.Tags", b =>
                {
                    b.Navigation("ArticleTags");
                });
#pragma warning restore 612, 618
        }
    }
}
