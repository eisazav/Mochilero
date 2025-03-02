using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hiker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    HikerElements = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HikerElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikerElements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HikerElements",
                columns: new[] { "Id", "Calories", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 3, null, null, null, "E1", 5 },
                    { 2, 5, null, null, null, "E2", 3 },
                    { 3, 2, null, null, null, "E3", 5 },
                    { 4, 8, null, null, null, "E4", 1 },
                    { 5, 3, null, null, null, "E5", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hiker");

            migrationBuilder.DropTable(
                name: "HikerElements");
        }
    }
}
