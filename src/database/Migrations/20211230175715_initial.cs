using System;
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
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Title = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    Author = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    Summary = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Published = table.Column<DateTime>(type: "date", nullable: false),
                    Url = table.Column<string>(type: "varchar", maxLength: 286, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => x.Id);
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
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_Id",
                table: "ArticleCategories",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                table: "Articles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Url",
                table: "Articles",
                column: "Url",
                unique: true)
                .Annotation("Relational:Collation", new[] { "case_insensitive_collation" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_Id",
                table: "ArticleTags",
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
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
