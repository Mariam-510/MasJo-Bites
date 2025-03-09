using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seddDataV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "Orange Juice", 60m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", "MenuItemImages/Moheto.jpeg", "Mojito", 55m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Classic pizza with tomato sauce and mozzarella.", "MenuItemImages/Margherita Pizza.jpeg", "Margherita Pizza", 160m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/BBQ.jpeg", "BBQ Chicken Pizza", 220m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", "Four Cheese Pizza", 185m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 5, "Warm chocolate cake with a gooey center.", "MenuItemImages/Chocolate Lava Cake.jpeg", "Chocolate Lava Cake", 80m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 30m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "MenuItemImages/Oragne Juice.jpeg", "Orange Juice", 40m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Rich chocolate cake with melted chocolate inside.", "MenuItemImages/Molten Chocolate Cake.jpeg", "Molten Chocolate Cake", 80m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fresh fruits on a creamy custard base.", "MenuItemImages/Fruit Tart.jpeg", "Fruit Tart", 70m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Moist carrot cake with cream cheese frosting.", "MenuItemImages/Carrot Cake.jpeg", "Carrot Cake", 75m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Creamy cheesecake with a graham cracker crust.", "MenuItemImages/Cheesecake.jpeg", "Cheesecake", 90m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 5, "Classic Italian coffee-flavored dessert.", "MenuItemImages/Tiramisu.jpeg", "Tiramisu", 95m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A refreshing, chilled coffee drink with bold flavors and a smooth finish.", "MenuItemImages/Iced Coffee.jpeg", "Ice Coffe", 120m });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[] { 33, 6, "A creamy, sweet blend of fresh strawberries and milk, topped with a smooth, velvety finish.", "MenuItemImages/Strawberry Milkshake.jpeg", true, false, "Strwberry Milkshake", 100m, 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "V7 Lemon", 25m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Classic pizza with tomato sauce and mozzarella.", "MenuItemImages/Margherita Pizza.jpeg", "Margherita Pizza", 160m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/BBQ.jpeg", "BBQ Chicken Pizza", 220m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", "Four Cheese Pizza", 185m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 5, "Warm chocolate cake with a gooey center.", "MenuItemImages/Chocolate Lava Cake.jpeg", "Chocolate Lava Cake", 80m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 6, "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 30m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "MenuItemImages/Oragne Juice.jpeg", "Orange Juice", 40m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Rich chocolate cake with melted chocolate inside.", "MenuItemImages/Molten Chocolate Cake.jpeg", "Molten Chocolate Cake", 80m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fresh fruits on a creamy custard base.", "MenuItemImages/Fruit Tart.jpeg", "Fruit Tart", 70m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Moist carrot cake with cream cheese frosting.", "MenuItemImages/Carrot Cake.jpeg", "Carrot Cake", 75m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Creamy cheesecake with a graham cracker crust.", "MenuItemImages/Cheesecake.jpeg", "Cheesecake", 90m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Classic Italian coffee-flavored dessert.", "MenuItemImages/Tiramisu.jpeg", "Tiramisu", 95m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 6, "A refreshing, chilled coffee drink with bold flavors and a smooth finish.", "MenuItemImages/Iced Coffee.jpeg", "Ice Coffe", 120m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A creamy, sweet blend of fresh strawberries and milk, topped with a smooth, velvety finish.", "MenuItemImages/Strawberry Milkshake.jpeg", "Strwberry Milkshake", 100m });
        }
    }
}
