using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 35m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "MenuItemImages/v7_2.jpg", "V7 Lemon", 25m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "MenuItemImages/v7_2.jpg", "V7 Lemon", 25m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 30m });
        }
    }
}
