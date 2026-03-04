using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetosAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateToAno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Projetos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Projetos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Projetos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
