using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class OrdersToProducts : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image URL", "Name", "Price" },
                values: new object[,]
                {
                    { "0bc12edf-26a5-43e6-8f13-bc135c5c050a", "https://i.imgur.com/NXYAbHe.png", "Product 4", 400.0 },
                    { "4e380a9a-3296-4972-98fd-f29efde14cd6", "https://i.imgur.com/lHDLsU4.png", "Product 2", 200.0 },
                    { "93d0730f-bc88-4712-99ee-4d2ca51ae609", "https://i.imgur.com/174MybH.png", "Product 3", 300.0 },
                    { "96a9770d-8c99-458f-b898-62c767a3ccd6", "https://i.imgur.com/LvKZW4A.png", "Product 1", 100.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$YUgft6NlzgvWPInrr18A/.XrPcYHEBtb8VbdsbM4h2vhU4n2q2Xhe");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "0bc12edf-26a5-43e6-8f13-bc135c5c050a");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4e380a9a-3296-4972-98fd-f29efde14cd6");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "93d0730f-bc88-4712-99ee-4d2ca51ae609");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "96a9770d-8c99-458f-b898-62c767a3ccd6");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
