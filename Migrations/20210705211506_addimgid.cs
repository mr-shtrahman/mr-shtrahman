using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class addimgid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Img_ImgId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Img_ImgId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ImgId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImgId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ImgId",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgId1",
                table: "Shop",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImgId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgId1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ImgId1",
                table: "Shop",
                column: "ImgId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImgId1",
                table: "Product",
                column: "ImgId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Img_ImgId1",
                table: "Product",
                column: "ImgId1",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Img_ImgId1",
                table: "Shop",
                column: "ImgId1",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Img_ImgId1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Img_ImgId1",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ImgId1",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImgId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImgId1",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ImgId1",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "ImgId",
                table: "Shop",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImgId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ImgId",
                table: "Shop",
                column: "ImgId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImgId",
                table: "Product",
                column: "ImgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Img_ImgId",
                table: "Product",
                column: "ImgId",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Img_ImgId",
                table: "Shop",
                column: "ImgId",
                principalTable: "Img",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
