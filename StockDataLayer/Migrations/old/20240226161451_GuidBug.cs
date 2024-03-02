using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class GuidBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18c6759e-8702-4336-abe3-788b99494e1f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30a032b0-805d-43ae-b67d-4a9b44f212aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d5b0bea-21b8-4c6f-8d5a-8263d68a4094"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df606eb6-06ac-4b98-b21d-b35308b0f014"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image URL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00e7b90d-a8a4-4f08-8247-57a3ff89dc06"), "https://i.imgur.com/LvKZW4A.png", "Product 1", 100.0 },
                    { new Guid("577cfea5-c239-48c3-8267-7492d974f9cc"), "https://i.imgur.com/lHDLsU4.png", "Product 2", 200.0 },
                    { new Guid("9771b73d-3948-4aba-9cba-b2267eabad03"), "https://i.imgur.com/NXYAbHe.png", "Product 4", 400.0 },
                    { new Guid("e9196c30-6210-46c3-afa2-5699a11ba6de"), "https://i.imgur.com/174MybH.png", "Product 3", 300.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$yN66.wDmc1JeUOYj8o2WhOei07lOqOz7.wai3KEOnLmk5gz.y9f92");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00e7b90d-a8a4-4f08-8247-57a3ff89dc06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("577cfea5-c239-48c3-8267-7492d974f9cc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9771b73d-3948-4aba-9cba-b2267eabad03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e9196c30-6210-46c3-afa2-5699a11ba6de"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image URL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("18c6759e-8702-4336-abe3-788b99494e1f"), "https://i.imgur.com/lHDLsU4.png", "Product 2", 200.0 },
                    { new Guid("30a032b0-805d-43ae-b67d-4a9b44f212aa"), "https://i.imgur.com/174MybH.png", "Product 3", 300.0 },
                    { new Guid("8d5b0bea-21b8-4c6f-8d5a-8263d68a4094"), "https://i.imgur.com/NXYAbHe.png", "Product 4", 400.0 },
                    { new Guid("df606eb6-06ac-4b98-b21d-b35308b0f014"), "https://i.imgur.com/LvKZW4A.png", "Product 1", 100.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$KBJE60DCv6EmzOQL9vMi5OtM7/O41j1.8qDJ3zAJ0RaZysf5ndzvu");
        }
    }
}
