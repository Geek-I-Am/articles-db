﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geekiam.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:CollationDefinition:case_insensitive_collation", "en-u-ks-primary,en-u-ks-primary,icu,False")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar", maxLength: 65, nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", maxLength: 286, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Permalink = table.Column<string>(type: "varchar", maxLength: 55, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", maxLength: 286, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Permalink = table.Column<string>(type: "varchar", maxLength: 55, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ArticleTagsArticleId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArticleTagsTagId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_ArticleTags_ArticleTagsArticleId_ArticleTagsTagId",
                        columns: x => new { x.ArticleTagsArticleId, x.ArticleTagsTagId },
                        principalTable: "ArticleTags",
                        principalColumns: new[] { "ArticleId", "TagId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Title = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Summary = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Published = table.Column<DateTime>(type: "date", nullable: false),
                    Url = table.Column<string>(type: "varchar", maxLength: 286, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: true),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTagsArticles",
                columns: table => new
                {
                    ArticlesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsTagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTagsArticles", x => new { x.ArticlesId, x.TagsArticleId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ArticleTagsArticles_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTagsArticles_ArticleTags_TagsArticleId_TagsTagId",
                        columns: x => new { x.TagsArticleId, x.TagsTagId },
                        principalTable: "ArticleTags",
                        principalColumns: new[] { "ArticleId", "TagId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoriesId",
                table: "Articles",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                table: "Articles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TagsId",
                table: "Articles",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Url",
                table: "Articles",
                column: "Url",
                unique: true)
                .Annotation("Relational:Collation", new[] { "case_insensitive_collation" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTagsArticles_TagsArticleId_TagsTagId",
                table: "ArticleTagsArticles",
                columns: new[] { "TagsArticleId", "TagsTagId" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Id",
                table: "Authors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true)
                .Annotation("Relational:Collation", new[] { "case_insensitive_collation" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ArticleTagsArticleId_ArticleTagsTagId",
                table: "Tags",
                columns: new[] { "ArticleTagsArticleId", "ArticleTagsTagId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Id",
                table: "Tags",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true)
                .Annotation("Relational:Collation", new[] { "case_insensitive_collation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "ArticleTagsArticles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ArticleTags");
        }
    }
}