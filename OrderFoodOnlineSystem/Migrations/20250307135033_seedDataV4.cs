using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedDataV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[] { 6, 6, false });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ginger offers a delightful fusion of authentic Japanese cuisine and fresh, expertly crafted sushi in a stylish ambiance.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ginger Restaurant & Sushi Bar offers a delightful fusion of authentic Japanese cuisine and fresh, expertly crafted sushi in a stylish ambiance.");
        }
    }
}
