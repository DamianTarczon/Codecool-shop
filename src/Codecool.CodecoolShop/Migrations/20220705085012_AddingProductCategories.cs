using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    public partial class AddingProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[] { 1, "Hardware", "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display.", "Tablet" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[] { 2, "Hardware", "A mobile phone that is smart", "Smartphone" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[] { 3, "Luxury goods", "A watch with smart functions", "Smartwatch" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
