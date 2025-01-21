using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budica_Andrei_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class AdaugareProprietatiNoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Pacient",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInregistrarii",
                table: "Pacient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ObservatiiMedicale",
                table: "Pacient",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInregistrarii",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "ObservatiiMedicale",
                table: "Pacient");

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Pacient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
