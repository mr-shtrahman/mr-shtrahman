using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class initialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Img",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Img", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false),
                    ImgId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Img_ImgId1",
                        column: x => x.ImgId1,
                        principalTable: "Img",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNum = table.Column<int>(type: "int", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    OpeningSundayTilThursday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningFriday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningSaturday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingSundayTilThursday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingFriday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingSaturday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false),
                    ImgId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_Img_ImgId1",
                        column: x => x.ImgId1,
                        principalTable: "Img",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductShop",
                columns: table => new
                {
                    ProductsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShopsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => new { x.ProductsId, x.ShopsId });
                    table.ForeignKey(
                        name: "FK_ProductShop_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shop_ShopsId",
                        column: x => x.ShopsId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: false),
                    TripType = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosestShopsId = table.Column<int>(type: "int", nullable: false),
                    ClosestShopsId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false),
                    ImgId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Img_ImgId1",
                        column: x => x.ImgId1,
                        principalTable: "Img",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trip_Shop_ClosestShopsId1",
                        column: x => x.ClosestShopsId1,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTrip",
                columns: table => new
                {
                    RelventProductsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTrip", x => new { x.RelventProductsId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_ProductTrip_Product_RelventProductsId",
                        column: x => x.RelventProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTrip_Trip_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorsAttendance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorsAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorsAttendance_Trip_TripId1",
                        column: x => x.TripId1,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImgId1",
                table: "Product",
                column: "ImgId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopsId",
                table: "ProductShop",
                column: "ShopsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTrip_TripsId",
                table: "ProductTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ImgId1",
                table: "Shop",
                column: "ImgId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_ClosestShopsId1",
                table: "Trip",
                column: "ClosestShopsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_ImgId1",
                table: "Trip",
                column: "ImgId1");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorsAttendance_TripId1",
                table: "VisitorsAttendance",
                column: "TripId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShop");

            migrationBuilder.DropTable(
                name: "ProductTrip");

            migrationBuilder.DropTable(
                name: "VisitorsAttendance");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Img");
        }
    }
}
