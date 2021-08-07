using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class addid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Img_ImgId",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_ImgId",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Shop",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Img",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ImgId",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgId1",
                table: "Trip",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "Img",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Img",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Img",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_ImgId1",
                table: "Trip",
                column: "ImgId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Img_ImgId1",
                table: "Trip",
                column: "ImgId1",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Img_ImgId1",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_ImgId1",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "ImgId1",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Shop",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Img",
                newName: "ProductID");

            migrationBuilder.AlterColumn<string>(
                name: "ImgId",
                table: "Trip",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "Img",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Img",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Img",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_ImgId",
                table: "Trip",
                column: "ImgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Img_ImgId",
                table: "Trip",
                column: "ImgId",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
