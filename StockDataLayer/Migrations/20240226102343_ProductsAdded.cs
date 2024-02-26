using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ProductsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ZSELXpt8PigPEh.FZxt0h.JeNS.gWsFFTqsdah3gQSj1/Mx4MkLU.", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$PnSNJyZ4yQrBBTnC/b60IO5TjYOxbAzjS1QvApayMl5ylaqB84BGq", 1 });
        }
    }
}
