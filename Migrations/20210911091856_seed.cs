using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mr_shtrahman.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNum = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    OpeningSundayTilThursday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningFriday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningSaturday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingSundayTilThursday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingFriday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingSaturday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    TripType = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductShop",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => new { x.ShopId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductShop_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Img",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Img", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Img_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Img_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Img_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTrip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTrip", x => new { x.TripId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductTrip_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTrip_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorsAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorsAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorsAttendance_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Img",
                columns: new[] { "Id", "Description", "ProductId", "ShopId", "Src", "TripId" },
                values: new object[,]
                {
                    { 1, "bags", null, null, "~/Assets/categories/bags.jpg", null },
                    { 42, "carmel-caves", null, null, "~/Assets/trips/north/carmel-caves.jpg", null },
                    { 43, "dishon", null, null, "~/Assets/trips/north/dishon.jpg", null },
                    { 44, "golan", null, null, "~/Assets/trips/north/golan.jpg", null },
                    { 45, "golan-amphitheater", null, null, "~/Assets/trips/north/golan-amphitheater.jpg", null },
                    { 46, "hula-valley", null, null, "~/Assets/trips/north/hula-valley.jpg", null },
                    { 48, "meitsar", null, null, "~/Assets/trips/north/meitsar.jpg", null },
                    { 49, "miron", null, null, "~/Assets/trips/north/miron.jpg", null },
                    { 50, "orvim", null, null, "~/Assets/trips/north/orvim.jpg", null },
                    { 51, "rosh-pina", null, null, "~/Assets/trips/north/rosh-pina.jpg", null },
                    { 52, "saar", null, null, "~/Assets/trips/north/saar.jpg", null },
                    { 53, "shofet", null, null, "~/Assets/trips/north/shofet.jpg", null },
                    { 54, "tanur", null, null, "~/Assets/trips/north/tanur.jpg", null },
                    { 67, "backpack4", null, null, "~/Assets/products/bags/backpack4.jpg", null },
                    { 68, "backpack5", null, null, "~/Assets/products/bags/backpack5.jpg", null },
                    { 69, "backpack5", null, null, "~/Assets/products/bags/backpack5.jpg", null },
                    { 70, "bag1", null, null, "~/Assets/products/bags/bag1.jpg", null },
                    { 71, "bag2", null, null, "~/Assets/products/bags/bag2.jpg", null },
                    { 73, "bag4", null, null, "~/Assets/products/bags/bag4.jpg", null },
                    { 75, "bag6", null, null, "~/Assets/products/bags/bag6.jpg", null },
                    { 76, "bag7", null, null, "~/Assets/products/bags/bag7.jpg", null },
                    { 77, "bag8", null, null, "~/Assets/products/bags/bag8.jpg", null },
                    { 79, "bag", null, null, "~/Assets/products/bags/bag10.jpg", null },
                    { 81, "chair2", null, null, "~/Assets/products/camping/chair2.jpg", null },
                    { 82, "chair3", null, null, "~/Assets/products/camping/chair3.jpg", null },
                    { 83, "cooking1", null, null, "~/Assets/products/camping/cooking1.jpg", null },
                    { 85, "cooking3", null, null, "~/Assets/products/camping/cooking3.jpg", null },
                    { 90, "coat2", null, null, "~/Assets/products/clothing/coat2.jpg", null },
                    { 91, "coat3", null, null, "~Assets/products/clothing/coat3.jpg", null },
                    { 92, "coat4", null, null, "~/Assets/products/clothing/coat4.jpg", null },
                    { 41, "bonim", null, null, "~/Assets/trips/north/bonim.jpg", null },
                    { 40, "binyamina", null, null, "~/Assets/trips/north/binyamina.jpg", null },
                    { 78, "bag9", null, null, "~/Assets/products/bags/bag9.jpg", null },
                    { 38, "acre", null, null, "~/Assets/trips/north/acre.jpg", null },
                    { 39, "afek", null, null, "~/Assets/trips/north/afek.jpg", null },
                    { 2, "camping", null, null, "~/Assets/categories/camping.jpg", null },
                    { 3, "clothes", null, null, "~/Assets/categories/clothes.jpg", null },
                    { 4, "gadgets", null, null, "~/Assets/categories/gadgets.jpg", null },
                    { 5, "shoes", null, null, "~/Assets/categories/shoes.jpg", null },
                    { 6, "clothes", null, null, "~/Assets/categories/soldiers.jpg", null },
                    { 8, "bashor", null, null, "~/Assets/trips/south/bashor.jpg", null },
                    { 10, "gov", null, null, "~/Assets/trips/south/gov.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Img",
                columns: new[] { "Id", "Description", "ProductId", "ShopId", "Src", "TripId" },
                values: new object[,]
                {
                    { 13, "peres", null, null, "~/Assets/trips/south/peres.jpg", null },
                    { 16, "red-canyon", null, null, "~/Assets/trips/south/red-canyon.jpg", null },
                    { 17, "shivta", null, null, "~/Assets/trips/south/shivta.jpg", null },
                    { 18, "timna", null, null, "~/Assets/trips/south/timna.jpg", null },
                    { 19, "vardit-canyon", null, null, "~/Assets/trips/south/vardit-canyon.jpg", null },
                    { 20, "zeelim", null, null, "~/Assets/trips/south/zeelim.jpg", null },
                    { 15, "rahaf", null, null, "~/Assets/trips/south/rahaf.jpg", null },
                    { 23, "caesarea", null, null, "~/Assets/trips/center/caesarea.jpg", null },
                    { 37, "shfela", null, null, "~/Assets/trips/center/shfela.jpg", null },
                    { 107, "shaananim", null, null, "~/Assets/trips/center/shaananim.jpg", null },
                    { 22, "britania", null, null, "~/Assets/trips/center/britania.jpg", null },
                    { 35, "roses-garden", null, null, "~/Assets/trips/center/roses-garden.jpg", null },
                    { 34, "rishon-letzion", null, null, "~/Assets/trips/center/rishon-letzion.jpg", null },
                    { 32, "palmahim", null, null, "~/Assets/trips/center/palmahim.jpg", null },
                    { 31, "gadgets", null, null, "~/Assets/trips/center/alexander.jpg", null },
                    { 36, "salit", null, null, "~/Assets/trips/center/salit.jpg", null },
                    { 29, "king-george", null, null, "~/Assets/trips/center/king-george.jpg", null },
                    { 108, "carmila", null, null, "~/Assets/trips/center/carmila.jpg", null },
                    { 27, "jaffa", null, null, "~/Assets/trips/center/jaffa.jpg", null },
                    { 26, "gamzo", null, null, "~/Assets/trips/center/gamzo.jpg", null },
                    { 24, "david-garden", null, null, "~/Assets/trips/center/david-garden.jpg", null },
                    { 30, "mahne-yehuda", null, null, "~/Assets/trips/center/mahne-yehuda.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Color", "Description", "Details", "ImgId", "Name", "Price", "Rating", "Size" },
                values: new object[,]
                {
                    { 15, 3, "Gray", "Comes with a set of walking sticks and an amazing support for your back.", "", 72, "Hiking Bag", 860.0, (short)5, 3 },
                    { 16, 3, "Blue", "You won't even feel that's it's there!", "", 74, "Backpack", 650.0, (short)4, 3 },
                    { 17, 2, "Black", "Give your legs some rest while toasting some marshmellows.", "", 80, "Camping chair", 80.0, (short)5, 3 },
                    { 18, 2, "Blue", "Have a great time with your family, making memories with a dinner under the moonlight.", "", 84, "Cooking set", 60.0, (short)3, 3 },
                    { 21, 1, "Brown", "The most comforatble pants, with zippers to adjust length on a hot weather!", "", 94, "Hiking pants", 190.0, (short)5, 0 },
                    { 20, 1, "Brown", "Stay warm at your next hike, with this great coat.", "", 93, "Heavy Coat", 240.0, (short)5, 0 },
                    { 22, 2, "Blue", "Feel at home with our soft, warm collection of sleeping bags.", "", 86, "Sleeping Bag", 140.0, (short)2, 3 },
                    { 23, 2, "Blue", "Our best sleeping bag ever, now back in more colors!", "", 87, "Sleeping Bag", 250.0, (short)5, 3 },
                    { 14, 3, "Gray", "The most comfortable backpack in vibrant colors.", "", 66, "Backpack", 150.0, (short)3, 3 },
                    { 24, 2, "Yellow", "Sleep better than ever, anywhere, anytime.", "", 88, "Sleeping Bag", 140.0, (short)4, 3 },
                    { 19, 1, "Red", "Stay warm at your next hike, with this great coat.", "", 89, "Light Coat", 320.0, (short)5, 1 },
                    { 13, 3, "Blue", "Support your back while exploring the world.", "", 65, "Backpack", 230.0, (short)5, 3 },
                    { 8, 5, "Red", "Lost yours at the bus? Ww got you.", "", 103, "Beret", 15.0, (short)2, 3 },
                    { 11, 5, "White", "Basic T-Shirt to wear under uniform.", "", 106, "White Shirt", 30.0, (short)3, 3 },
                    { 10, 5, "Silver", "Cook, fix and protect yourself. All with one device.", "", 105, "Leatherman", 200.0, (short)4, 3 },
                    { 9, 5, "Black", "The great watch everyone's talking about. Get it at our shops with a discount!", "", 104, "G-Shock", 360.0, (short)5, 3 },
                    { 25, 5, "Blue", "Don't settle for the rusty old belt you got.", "", 102, "Uniform Belt", 35.0, (short)3, 3 },
                    { 7, 4, "Gold", "Go classy with this vintage compass, while getting to your destination fast and safely.", "", 101, " Vintage Compass", 320.0, (short)3, 3 },
                    { 6, 4, "Green", "Protect your equipmment the way it deserves.", "", 100, "Camera Bag", 500.0, (short)4, 3 },
                    { 5, 4, "Blue", "The device that will save you from the heat and scare the mosquitos away. A must-have for every camp!", "", 99, "Portable AC", 640.0, (short)3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Color", "Description", "Details", "ImgId", "Name", "Price", "Rating", "Size" },
                values: new object[,]
                {
                    { 4, 0, "Black", "The beloved Israeli sandals for hiking, entering the water and looking like a nerd.", "", 98, "Shoresh Sandals", 300.0, (short)5, 2 },
                    { 3, 0, "Red", "The beloved Israeli sandals for hiking, entering the water and looking like a nerd.", "", 97, "Shoresh Sandals", 300.0, (short)5, 0 },
                    { 2, 0, "Brown", "Best shoes to feel like your floating while running.", "", 96, "Running Shoes", 470.0, (short)2, 1 },
                    { 1, 0, "Brown", "Most sought after for a reason. Everything you love about our Original boots, turned up to max.", "", 95, "Blandston", 250.0, (short)5, 2 },
                    { 12, 3, "Orange", "The most comfortable backpack in vibrant colors.", "", 64, "Backpack", 150.0, (short)3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "City", "ClosingFriday", "ClosingSaturday", "ClosingSundayTilThursday", "ImgId", "Lat", "Lon", "Name", "OpeningFriday", "OpeningSaturday", "OpeningSundayTilThursday", "PhoneNum", "Rating", "Street", "StreetNum" },
                values: new object[,]
                {
                    { 9, 1, null, null, "22:00", 63, 31.75206, 35.186990000000002, "Malcha Mall", null, null, "09:30", " 0529402794", (short)4, "Derech Agudat Sport Beitar", 1 },
                    { 8, 12, "15:00", "22:00", "21:00", 62, 32.790529999999997, 35.008139999999997, "Ofer Grand Mall", "09:00", "10:30", "09:30", "0548688480", (short)2, "Derech Simha Golan", 54 },
                    { 7, 12, "15:00", "22:00", "21:30", 61, 32.810029999999998, 35.057259999999999, "Haifa Hutsot HaMifrats", "09:00", "10:30", "09:30", "0546883166", (short)5, "Hahoreshet", 10 },
                    { 5, 7, "14:00", "22:00", "21:00", 59, 31.81062, 34.661859999999997, "Ashdod TOP Center", "09:00", "20:30", "10:00", "0586108143", (short)3, "HaOrgim St", 7 },
                    { 6, 3, "15:00", null, "21:30", 60, 31.243659999999998, 34.810850000000002, "Be'er Sheva BIG", "09:00", null, "09:30", "0586235348", (short)3, "Derekh Hebron", 21 },
                    { 3, 5, "15:00", "22:00", "21:00", 57, 32.101739999999999, 35.16968, "Ariel Mega-Or Center", "09:00", "11:00", "09:30", "0539108486", (short)4, "Ha-Banai street", 6 },
                    { 2, 4, "15:00", "22:00", "21:00", 56, 29.571110000000001, 34.955860000000001, "BIG Center", "09:00", "20:30", "09:30", "0586339938", (short)2, "Ha-Mutsar st", 13 },
                    { 1, 2, "15:00", "22:00", "21:00", 55, 31.996449999999999, 34.780529999999999, "Zahav Mall", "09:00", "10:30", "09:30", "0536245372", (short)5, "David Saharov st", 21 },
                    { 4, 7, "14:00", null, "20:30", 58, 31.777660000000001, 34.663760000000003, "Ashdod BIG", "09:00", null, "10:00", "0586106734", (short)5, "Derech HaRakevet", 1 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "Id", "Destination", "Details", "Difficulty", "ImgId", "Lat", "Location", "Lon", "Name", "Price", "Rating", "TripType" },
                values: new object[,]
                {
                    { 10, 8, "Dramatic geological feature & 40 - km - long erosion landform of Israel's Negev desert.", 0, 11, 30.610520000000001, "Ein Mor St 5, Mitzpe Ramon", 34.797150000000002, "Makhtesh Ramon", 40.0, (short)5, 2 },
                    { 9, 5, "a beautifully restored river which runs the width of Israel to its estuary near the moshav of Beit Yannai.", 3, 21, 32.370370000000001, "Ma'abarot", 34.904519999999998, "Alexander River", 60.0, (short)4, 1 },
                    { 8, 1, "Tranquil forested area with a stream, hiking trails & the remains of a medieval castle.", 3, 47, 33.045940000000002, "Nakhal Kziv Reserve", 35.178040000000003, "Nakhal Kziv", 0.0, (short)2, 8 },
                    { 7, 7, "Desert canyon with an ancient drinking water spring, plus a 4th-century monastery & cliff climbs.", 1, 14, 31.876069999999999, "Ein Prat Nature Reserve", 35.312429999999999, "Ein Prat", 0.0, (short)2, 5 },
                    { 6, 4, " Discover the charming neighbourhood of Florentin on this self-guided tour that takes in all its sights, aromas and flavours.", 4, 25, 32.058700000000002, "Florentin Street", 34.767249999999997, "Florentin", 150.0, (short)5, 4 },
                    { 5, 5, "A stream that drains the area of ​​the Sharon region in Israel", 3, 33, 32.273061291060493, "Netanya", 34.832977154632864, "Polag River", 100.0, (short)3, 8 },
                    { 3, 7, "Meaning `spring of the kid` is an oasis and a nature reserve in", 3, 9, 31.458285980770459, "Negev desert in southern Israel", 35.398741797896776, "Ein Gedi", 0.0, (short)5, 8 },
                    { 2, 7, "An ancient fortification", 2, 12, 31.31073847403702, "Southern District", 35.363164732954814, "Masada", 50.0, (short)4, 0 },
                    { 1, 9, "A site of a ruined Nabataean city", 1, 7, 30.794573169710944, "Negev desert in southern Israel", 34.773399402299013, "Avdat National Park", 25.0, (short)1, 0 },
                    { 4, 6, "Israel's capital", 4, 28, 31.766019862597236, "Middle of Israel", 35.201420085577446, "Jerusalem", 0.0, (short)5, 4 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "isAdmin" },
                values: new object[,]
                {
                    { "3", "tshuvanm@gmail.com", "ADMIN", true },
                    { "1", "mikimeerson44@gmail.com", "ADMIN", true },
                    { "2", "orelz16@gmail.com", "ADMIN", true },
                    { "4", "jackzaf96@hotmail.com", "ADMIN", true }
                });

            migrationBuilder.InsertData(
                table: "Img",
                columns: new[] { "Id", "Description", "ProductId", "ShopId", "Src", "TripId" },
                values: new object[,]
                {
                    { 95, "blandston1", 1, null, "~/Assets/products/shoes/blandston1.jpg", null },
                    { 88, "sleepingbag3", 24, null, "~/Assets/products/camping/sleepingbag3.jpg", null },
                    { 55, "shop1", null, 1, "~/Assets/shops/shop1.jpg", null },
                    { 56, "shop2", null, 2, "~/Assets/shops/shop2.jpg", null },
                    { 57, "shop3", null, 3, "~/Assets/shops/shop3.jpg", null },
                    { 58, "shop4", null, 4, "~/Assets/shops/shop4.jpg", null },
                    { 59, "shop5", null, 5, "~/Assets/shops/shop5.jpg", null },
                    { 60, "shop6", null, 6, "~/Assets/shops/shop6.jpg", null },
                    { 61, "shop7", null, 7, "~/Assets/shops/shop7.jpg", null },
                    { 62, "shop8", null, 8, "~/Assets/shops/shop8.jpg", null },
                    { 63, "shop9", null, 9, "~/Assets/shops/shop9.jpg", null },
                    { 11, "makhtesh-ramon", null, null, "~/Assets/trips/south/makhtesh-ramon.jpg", 10 },
                    { 7, "avdaat", null, null, "~/Assets/trips/south/avdaat.jpg", 1 },
                    { 21, "alexander", null, null, "~/Assets/trips/center/alexander.jpg", 9 },
                    { 47, "kziv", null, null, "~/Assets/trips/north/kziv.jpg", 8 },
                    { 12, "mesada", null, null, "~/Assets/trips/south/mesada.jpg", 2 },
                    { 14, "prat", null, null, "~/Assets/trips/south/prat.jpg", 7 },
                    { 9, "ein-gedi", null, null, "~/Assets/trips/south/ein-gedi.jpg", 3 },
                    { 25, "florentin", null, null, "~/Assets/trips/center/florentin.jpg", 6 },
                    { 33, "poleg", null, null, "~/Assets/trips/center/poleg.jpg", 5 },
                    { 87, "sleepingbag2", 23, null, "~/Assets/products/camping/sleepingbag2.jpg", null },
                    { 86, "sleepingbag1", 22, null, "~/Assets/products/camping/sleepingbag1.jpg", null },
                    { 28, "jerusalem", null, null, "~/Assets/trips/center/jerusalem.jpg", 4 },
                    { 93, "coat5", 20, null, "~/Assets/products/clothing/coat5.jpg", null },
                    { 80, "chair1", 17, null, "~/Assets/products/camping/chair1.jpg", null },
                    { 94, "pants1", 21, null, "~/Assets/products/clothing/pants1.jpg", null },
                    { 65, "backpack2", 13, null, "~/Assets/products/bags/backpack2.jpg", null },
                    { 74, "bag5", 16, null, "~/Assets/products/bags/bag5.jpg", null },
                    { 106, "white-shirt", 11, null, "~/Assets/products/soldiers/white-shirt.jpg", null },
                    { 66, "backpack3", 14, null, "~/Assets/products/bags/backpack3.jpg", null },
                    { 84, "cooking2", 18, null, "~/Assets/products/camping/cooking2.jpg", null },
                    { 72, "bag3", 15, null, "~/Assets/products/bags/bag3.jpg", null },
                    { 105, "leatherman", 10, null, "~/Assets/products/soldiers/leatherman.jpg", null },
                    { 64, "backpack1", 12, null, "~/Assets/products/bags/backpack1.jpg", null },
                    { 103, "beret", 8, null, "~/Assets/products/soldiers/beret.jpg", null },
                    { 104, "gshock", 9, null, "~/Assets/products/soldiers/gshock.jpg", null },
                    { 99, "ac", 5, null, "~/Assets/products/gadgets/ac.jpg", null },
                    { 97, "shoresh1", 3, null, "~/Assets/products/shoes/shoresh1.jpg", null },
                    { 101, "compass", 7, null, "~/Assets/products/gadgets/compass.jpg", null },
                    { 96, "shoes1", 2, null, "~/Assets/products/shoes/shoes1.jpg", null },
                    { 100, "camera-bag", 6, null, "~/Assets/products/gadgets/camera-bag.jpg", null },
                    { 102, "belt", 25, null, "~/Assets/products/soldiers/belt.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Img",
                columns: new[] { "Id", "Description", "ProductId", "ShopId", "Src", "TripId" },
                values: new object[,]
                {
                    { 89, "coat1", 19, null, "~/Assets/products/clothing/coat1.jpg", null },
                    { 98, "shoresh2", 4, null, "~/Assets/products/shoes/shoresh2.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" },
                values: new object[,]
                {
                    { 22, 6 },
                    { 6, 7 },
                    { 25, 6 },
                    { 24, 6 },
                    { 23, 6 },
                    { 7, 7 },
                    { 5, 7 },
                    { 15, 6 },
                    { 20, 6 },
                    { 14, 6 },
                    { 5, 6 },
                    { 3, 6 },
                    { 13, 7 },
                    { 25, 5 },
                    { 22, 5 },
                    { 21, 5 },
                    { 15, 5 },
                    { 14, 5 },
                    { 21, 6 },
                    { 2, 6 },
                    { 11, 8 },
                    { 5, 8 },
                    { 23, 9 },
                    { 22, 9 },
                    { 21, 9 },
                    { 13, 9 },
                    { 12, 9 },
                    { 11, 9 },
                    { 3, 9 },
                    { 2, 9 },
                    { 1, 9 },
                    { 25, 8 },
                    { 23, 8 },
                    { 21, 8 },
                    { 20, 8 },
                    { 19, 8 },
                    { 16, 8 },
                    { 15, 8 },
                    { 14, 8 },
                    { 13, 8 }
                });

            migrationBuilder.InsertData(
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" },
                values: new object[,]
                {
                    { 12, 8 },
                    { 13, 5 },
                    { 8, 8 },
                    { 7, 8 },
                    { 6, 8 },
                    { 3, 8 },
                    { 11, 5 },
                    { 4, 7 },
                    { 7, 5 },
                    { 14, 2 },
                    { 13, 2 },
                    { 12, 2 },
                    { 11, 2 },
                    { 10, 2 },
                    { 9, 2 },
                    { 8, 2 },
                    { 7, 2 },
                    { 4, 2 },
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 25, 1 },
                    { 24, 1 },
                    { 22, 1 },
                    { 21, 1 },
                    { 20, 1 },
                    { 17, 1 },
                    { 16, 1 },
                    { 15, 1 },
                    { 8, 5 },
                    { 12, 1 },
                    { 10, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 2, 1 },
                    { 1, 1 },
                    { 15, 2 },
                    { 16, 2 },
                    { 4, 6 },
                    { 18, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" },
                values: new object[,]
                {
                    { 17, 4 },
                    { 16, 4 },
                    { 17, 2 },
                    { 3, 5 },
                    { 4, 5 },
                    { 15, 4 },
                    { 5, 5 },
                    { 13, 4 },
                    { 12, 4 },
                    { 11, 4 },
                    { 10, 4 },
                    { 9, 4 },
                    { 23, 3 },
                    { 14, 4 },
                    { 20, 3 },
                    { 19, 2 },
                    { 20, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 6, 3 },
                    { 10, 3 },
                    { 22, 3 },
                    { 11, 3 },
                    { 18, 4 },
                    { 13, 3 },
                    { 19, 3 },
                    { 16, 3 },
                    { 12, 3 },
                    { 14, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductTrip",
                columns: new[] { "ProductId", "TripId" },
                values: new object[,]
                {
                    { 17, 7 },
                    { 15, 7 },
                    { 10, 7 },
                    { 7, 7 },
                    { 6, 7 },
                    { 5, 7 },
                    { 3, 7 },
                    { 1, 7 },
                    { 18, 7 },
                    { 20, 6 },
                    { 14, 6 },
                    { 3, 5 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductTrip",
                columns: new[] { "ProductId", "TripId" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 1, 6 },
                    { 6, 5 },
                    { 21, 5 },
                    { 17, 5 },
                    { 13, 5 },
                    { 12, 5 },
                    { 7, 6 },
                    { 6, 9 },
                    { 2, 8 },
                    { 22, 10 },
                    { 1, 5 },
                    { 20, 10 },
                    { 18, 10 },
                    { 17, 10 },
                    { 15, 10 },
                    { 12, 10 },
                    { 10, 10 },
                    { 5, 10 },
                    { 2, 10 },
                    { 1, 10 },
                    { 19, 9 },
                    { 18, 9 },
                    { 13, 9 },
                    { 9, 9 },
                    { 4, 9 },
                    { 2, 9 },
                    { 19, 8 },
                    { 18, 8 },
                    { 13, 8 },
                    { 9, 8 },
                    { 6, 8 },
                    { 4, 8 },
                    { 24, 7 },
                    { 21, 10 },
                    { 5, 2 },
                    { 13, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 19, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductTrip",
                columns: new[] { "ProductId", "TripId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 4, 1 },
                    { 1, 1 },
                    { 1, 4 },
                    { 4, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 10, 4 },
                    { 16, 4 },
                    { 20, 4 },
                    { 7, 3 },
                    { 15, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 23, 3 },
                    { 21, 2 },
                    { 2, 2 },
                    { 6, 2 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "VisitorsAttendance",
                columns: new[] { "Id", "Attendance", "Date", "TripId" },
                values: new object[,]
                {
                    { 109, 26, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 42, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 89, 26, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 88, 22, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 87, 28, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 86, 28, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 85, 20, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 84, 20, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 83, 20, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 82, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 81, 20, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 11, 18, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 90, 26, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 10, 18, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 95, 12, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 8, 27, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 108, 27, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 107, 20, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 106, 20, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 105, 21, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 104, 23, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 103, 21, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 102, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "VisitorsAttendance",
                columns: new[] { "Id", "Attendance", "Date", "TripId" },
                values: new object[,]
                {
                    { 101, 25, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 1, 20, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 23, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 26, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 23, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 25, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, 35, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 100, 35, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 99, 33, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 98, 32, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 97, 31, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 96, 12, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 12, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 94, 23, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 93, 27, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 92, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 91, 26, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 9, 15, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 17, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 77, 42, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 15, 32, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 36, 17, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 37, 18, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 38, 20, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 60, 41, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 59, 40, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 58, 43, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 57, 47, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 56, 47, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 55, 46, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 54, 45, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 53, 41, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 52, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 51, 40, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 39, 21, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 40, 29, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 50, 33, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 49, 34, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 48, 28, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 47, 21, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 46, 2, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "VisitorsAttendance",
                columns: new[] { "Id", "Attendance", "Date", "TripId" },
                values: new object[,]
                {
                    { 45, 28, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 44, 2, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 43, 21, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 35, 18, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 34, 19, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, 17, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 61, 21, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 16, 22, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 23, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 80, 11, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 79, 1, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 78, 24, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 41, 23, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 76, 24, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 75, 24, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 74, 31, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 73, 28, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 72, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 14, 31, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 71, 29, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 19, 22, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, 21, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 70, 24, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 69, 29, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 68, 18, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 67, 19, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 66, 19, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 65, 17, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 64, 18, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 63, 19, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 62, 18, new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 18, 25, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 110, 20, new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Img_ProductId",
                table: "Img",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Img_ShopId",
                table: "Img",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Img_TripId",
                table: "Img",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ProductId",
                table: "ProductShop",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTrip_ProductId",
                table: "ProductTrip",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorsAttendance_TripId",
                table: "VisitorsAttendance",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Img");

            migrationBuilder.DropTable(
                name: "ProductShop");

            migrationBuilder.DropTable(
                name: "ProductTrip");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VisitorsAttendance");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
