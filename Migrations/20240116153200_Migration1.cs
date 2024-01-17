using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestiuneRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mese",
                columns: table => new
                {
                    MasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Capacitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mese", x => x.MasaId);
                });

            migrationBuilder.CreateTable(
                name: "ProduseMeniu",
                columns: table => new
                {
                    ProdusMeniuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduseMeniu", x => x.ProdusMeniuId);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comenzi_Mese_MasaId",
                        column: x => x.MasaId,
                        principalTable: "Mese",
                        principalColumn: "MasaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervari",
                columns: table => new
                {
                    RezervareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRezervare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumarPersoane = table.Column<int>(type: "int", nullable: false),
                    MasaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervari", x => x.RezervareId);
                    table.ForeignKey(
                        name: "FK_Rezervari_Mese_MasaId",
                        column: x => x.MasaId,
                        principalTable: "Mese",
                        principalColumn: "MasaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticoleComandate",
                columns: table => new
                {
                    ArticolComandatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProdusMeniuId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticoleComandate", x => x.ArticolComandatId);
                    table.ForeignKey(
                        name: "FK_ArticoleComandate_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticoleComandate_ProduseMeniu_ProdusMeniuId",
                        column: x => x.ProdusMeniuId,
                        principalTable: "ProduseMeniu",
                        principalColumn: "ProdusMeniuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mese",
                columns: new[] { "MasaId", "Capacitate", "Numar" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 6, 2 },
                    { 3, 6, 3 },
                    { 4, 6, 4 },
                    { 5, 6, 5 },
                    { 6, 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticoleComandate_ComandaId",
                table: "ArticoleComandate",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticoleComandate_ProdusMeniuId",
                table: "ArticoleComandate",
                column: "ProdusMeniuId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_MasaId",
                table: "Comenzi",
                column: "MasaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervari_MasaId",
                table: "Rezervari",
                column: "MasaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticoleComandate");

            migrationBuilder.DropTable(
                name: "Rezervari");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "ProduseMeniu");

            migrationBuilder.DropTable(
                name: "Mese");
        }
    }
}
