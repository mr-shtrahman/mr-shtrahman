using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Shop");

            migrationBuilder.AddColumn<string>(
                name: "ClosingFriday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosingSaturday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClosingSundayTilThursday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningFriday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningSaturday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningSundayTilThursday",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingFriday",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ClosingSaturday",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ClosingSundayTilThursday",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OpeningFriday",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OpeningSaturday",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OpeningSundayTilThursday",
                table: "Shop");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningTime",
                table: "Shop",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
