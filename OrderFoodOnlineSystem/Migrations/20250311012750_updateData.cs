using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "RestaurantImages/Tasty bites.PNG");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "RestaurantImages/Burger King.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "RestaurantImages/Ginger.JPG");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "RestaurantImages/papaJohn.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "RestaurantImages/PizzaHut.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "RestaurantImages/Sweet Delight.PNG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "ResturantImages/Tasty bites.PNG");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "ResturantImages/Burger King.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "ResturantImages/Ginger.JPG");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "ResturantImages/papaJohn.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "ResturantImages/PizzaHut.jpeg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "ResturantImages/Sweet Delight.PNG");
        }
    }
}
