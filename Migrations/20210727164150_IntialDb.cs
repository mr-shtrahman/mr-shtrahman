using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class IntialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Shop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
