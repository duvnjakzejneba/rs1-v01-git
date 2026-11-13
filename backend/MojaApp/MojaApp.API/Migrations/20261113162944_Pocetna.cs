using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MojaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class Pocetna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpstinaRodjenjaId = table.Column<int>(type: "int", nullable: true),
                    DatumRodjenja = table.Column<DateOnly>(type: "date", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlikaStudenta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studenti_Opstina_OpstinaRodjenjaId",
                        column: x => x.OpstinaRodjenjaId,
                        principalTable: "Opstina",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "Id", "BrojIndeksa", "DatumKreiranja", "DatumRodjenja", "Ime", "OpstinaRodjenjaId", "Prezime", "SlikaStudenta" },
                values: new object[,]
                {
                    { 1, "IB200161", new DateTime(2026, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2002, 4, 29), "Zejneba", null, "Duvnjak-Beso", null },
                    { 2, "IB200162", new DateTime(2026, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amer", null, "Beso", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_OpstinaRodjenjaId",
                table: "Studenti",
                column: "OpstinaRodjenjaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Opstina");
        }
    }
}
