using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateFav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "FavouriteRestaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 150m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 200m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 220m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[] { 6, 3, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "FavouriteRestaurants");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://example.com/margherita.jpg", 8.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://example.com/pepperoni.jpg", 10.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://example.com/bbqchicken.jpg", 12.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/spaghetti.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/fettuccine.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://example.com/penne.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://example.com/cheeseburger.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://example.com/baconburger.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://example.com/mushroomswiss.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://example.com/californiaroll.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://example.com/spicytuna.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://example.com/dragonroll.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://example.com/fourcheese.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://example.com/veggiepizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://example.com/hawaiian.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://example.com/margherita.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://example.com/pepperoni.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://example.com/bbqchicken.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://example.com/lavacake.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://example.com/moltenchocolate.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://example.com/fruittart.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://example.com/carrotcake.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://example.com/cheesecake.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://example.com/tiramisu.jpg");
        }
    }
}
