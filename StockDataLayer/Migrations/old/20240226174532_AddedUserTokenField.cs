using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTokenField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

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
    }
}
