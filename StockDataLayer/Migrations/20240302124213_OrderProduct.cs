using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class OrderProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d37b540-19c8-426b-87a6-5bacec6feb0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50f4042b-02f9-4347-80f1-5870f11f2718"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e584bff-0e42-4d1f-8d3a-a4e36291d82f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3953ecb-b2a2-4eaf-abab-02df519b8f6a"));

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image URL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("09cb716d-e7d4-4d3d-af61-f2659924cd51"), "https://i.imgur.com/lHDLsU4.png", "Product 2", 200.0 },
                    { new Guid("0a2fb9bf-c182-46d2-8070-193f294e2828"), "https://i.imgur.com/LvKZW4A.png", "Product 1", 100.0 },
                    { new Guid("0ff0ca74-84fc-415c-a0f0-35ab91fe3481"), "https://i.imgur.com/NXYAbHe.png", "Product 4", 400.0 },
                    { new Guid("a902b534-3dea-41e6-b877-eea658d35d07"), "https://i.imgur.com/174MybH.png", "Product 3", 300.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$wYG56M84beizRMaW4OnEnO1gMAYeN7cF8yFQdKYK9UWrDmkKUOl1G");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09cb716d-e7d4-4d3d-af61-f2659924cd51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a2fb9bf-c182-46d2-8070-193f294e2828"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff0ca74-84fc-415c-a0f0-35ab91fe3481"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a902b534-3dea-41e6-b877-eea658d35d07"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image URL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2d37b540-19c8-426b-87a6-5bacec6feb0f"), "https://i.imgur.com/LvKZW4A.png", "Product 1", 100.0 },
                    { new Guid("50f4042b-02f9-4347-80f1-5870f11f2718"), "https://i.imgur.com/lHDLsU4.png", "Product 2", 200.0 },
                    { new Guid("6e584bff-0e42-4d1f-8d3a-a4e36291d82f"), "https://i.imgur.com/NXYAbHe.png", "Product 4", 400.0 },
                    { new Guid("e3953ecb-b2a2-4eaf-abab-02df519b8f6a"), "https://i.imgur.com/174MybH.png", "Product 3", 300.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$DgrJhT1LVRTwgY9/DcCjCuHB.VlzIvThnUH0WhhbNekPWn8Zi/EfG");
        }
    }
}
