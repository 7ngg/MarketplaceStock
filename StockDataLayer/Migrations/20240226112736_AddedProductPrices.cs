using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01d7e934-c911-4f93-9c1c-eb82b366ab94"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4563ab0b-06cd-4229-b303-23304d1071e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9479eba5-6391-4911-8466-2ec3d962843d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb532385-0df0-4226-a50e-16e039294e64"));

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "Image URL");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Image URL",
                table: "Products",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("01d7e934-c911-4f93-9c1c-eb82b366ab94"), "https://i.imgur.com/LvKZW4A.png", "Product 1" },
                    { new Guid("4563ab0b-06cd-4229-b303-23304d1071e2"), "https://i.imgur.com/174MybH.png", "Product 3" },
                    { new Guid("9479eba5-6391-4911-8466-2ec3d962843d"), "https://i.imgur.com/lHDLsU4.png", "Product 2" },
                    { new Guid("eb532385-0df0-4226-a50e-16e039294e64"), "https://i.imgur.com/NXYAbHe.png", "Product 4" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ZSELXpt8PigPEh.FZxt0h.JeNS.gWsFFTqsdah3gQSj1/Mx4MkLU.");
        }
    }
}
