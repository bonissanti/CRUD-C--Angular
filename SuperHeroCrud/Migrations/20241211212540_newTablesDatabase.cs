using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroCrud.Migrations
{
    /// <inheritdoc />
    public partial class newTablesDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperHeroDB_HeroId",
                table: "HeroesSuperPowersDB");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperPowerDB_SuperPowerId",
                table: "HeroesSuperPowersDB");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperPowerDB",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperHeroDB",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                table: "SuperHeroDB",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 120);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperHeroDB_HeroId",
                table: "HeroesSuperPowersDB",
                column: "HeroId",
                principalTable: "SuperHeroDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperPowerDB_SuperPowerId",
                table: "HeroesSuperPowersDB",
                column: "SuperPowerId",
                principalTable: "SuperPowerDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperHeroDB_HeroId",
                table: "HeroesSuperPowersDB");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperPowerDB_SuperPowerId",
                table: "HeroesSuperPowersDB");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperPowerDB",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperHeroDB",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                table: "SuperHeroDB",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperHeroDB_HeroId",
                table: "HeroesSuperPowersDB",
                column: "HeroId",
                principalTable: "SuperHeroDB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroesSuperPowersDB_SuperPowerDB_SuperPowerId",
                table: "HeroesSuperPowersDB",
                column: "SuperPowerId",
                principalTable: "SuperPowerDB",
                principalColumn: "Id");
        }
    }
}
