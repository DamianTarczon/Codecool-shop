using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    public partial class AddingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Currency", "DefaultPrice", "Description", "Name", "ProductCategoryId", "SupplierId" },
                values: new object[,]
                {
                    { 1, "USD", 49.9m, "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", "Amazon Fire", 1, 1 },
                    { 2, "USD", 479.0m, "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", "Lenovo IdeaPad Miix 700", 1, 5 },
                    { 3, "USD", 89.0m, "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", "Amazon Fire HD 8", 1, 1 },
                    { 4, "USD", 500.9m, "Fantasic mobile phone", "iPhone 10", 2, 2 },
                    { 5, "USD", 500.9m, "Good enough", "iPhone 8", 2, 2 },
                    { 6, "USD", 50.9m, "Fantasic smartwatch with good price", "Xiaomi Redmi 2", 2, 3 },
                    { 7, "USD", 60.9m, "Smartwatch with a lot of functions", "Garmin Fenix 5", 3, 4 },
                    { 8, "USD", 70.9m, "The best smartwatch", "Xiaomi Mi Band 6", 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
