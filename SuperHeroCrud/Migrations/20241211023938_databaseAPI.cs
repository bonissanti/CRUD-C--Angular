using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroCrud.Migrations
{
    /// <inheritdoc />
    public partial class databaseAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHeroDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    HeroName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    BirthDate = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperPowerDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowerDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroesSuperPowersDB",
                columns: table => new
                {
                    HeroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SuperPowerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesSuperPowersDB", x => new { x.HeroId, x.SuperPowerId });
                    table.ForeignKey(
                        name: "FK_HeroesSuperPowersDB_SuperHeroDB_HeroId",
                        column: x => x.HeroId,
                        principalTable: "SuperHeroDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HeroesSuperPowersDB_SuperPowerDB_SuperPowerId",
                        column: x => x.SuperPowerId,
                        principalTable: "SuperPowerDB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroesSuperPowersDB_SuperPowerId",
                table: "HeroesSuperPowersDB",
                column: "SuperPowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroesSuperPowersDB");

            migrationBuilder.DropTable(
                name: "SuperHeroDB");

            migrationBuilder.DropTable(
                name: "SuperPowerDB");
        }
    }
}
