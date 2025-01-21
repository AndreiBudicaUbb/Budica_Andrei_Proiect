using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budica_Andrei_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class TabelePacPlataProgTer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prenume",
                table: "Pacient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(type: "int", nullable: false),
                    DataPlata = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    MetodaPlata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarDocument = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Observatii = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StatusPlata = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plata_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terapeut",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Specializare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapeut", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(type: "int", nullable: false),
                    TerapeutID = table.Column<int>(type: "int", nullable: false),
                    DataOra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Observatii = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programare_Terapeut_TerapeutID",
                        column: x => x.TerapeutID,
                        principalTable: "Terapeut",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plata_PacientID",
                table: "Plata",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_PacientID",
                table: "Programare",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_TerapeutID",
                table: "Programare",
                column: "TerapeutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Terapeut");

            migrationBuilder.DropColumn(
                name: "Prenume",
                table: "Pacient");
        }
    }
}
