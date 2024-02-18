using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username", "Role" },
                values: new object[] { 1, "stock_admin@gmail.com", "$2a$11$PnSNJyZ4yQrBBTnC/b60IO5TjYOxbAzjS1QvApayMl5ylaqB84BGq", "admin", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
