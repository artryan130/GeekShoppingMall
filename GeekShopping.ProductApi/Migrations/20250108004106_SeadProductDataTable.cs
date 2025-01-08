using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeadProductDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "Category 2", "Description 2", "https://www.heidisql.com/download.php", "Name 2", 70.8m },
                    { 5L, "Category 5", "Description 5", "https://www.heidisql.com/download.php", "Name 5", 120.1m },
                    { 6L, "Category 6", "Description 6", "https://www.heidisql.com/download.php", "Name 6", 60.88m },
                    { 7L, "Category 7", "Description 7", "https://www.heidisql.com/download.php", "Name 7", 170.8m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);
        }
    }
}
