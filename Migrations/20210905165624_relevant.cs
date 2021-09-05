using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class relevant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTrip_Product_RelventProductsId",
                table: "ProductTrip");

            migrationBuilder.RenameColumn(
                name: "RelventProductsId",
                table: "ProductTrip",
                newName: "RelevantProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTrip_Product_RelevantProductsId",
                table: "ProductTrip",
                column: "RelevantProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTrip_Product_RelevantProductsId",
                table: "ProductTrip");

            migrationBuilder.RenameColumn(
                name: "RelevantProductsId",
                table: "ProductTrip",
                newName: "RelventProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTrip_Product_RelventProductsId",
                table: "ProductTrip",
                column: "RelventProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
