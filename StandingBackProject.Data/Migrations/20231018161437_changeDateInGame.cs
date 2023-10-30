using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandingBackProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDateInGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Game",
                newName: "DateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFinish",
                table: "Game",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFinish",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Game",
                newName: "Date");
        }
    }
}
