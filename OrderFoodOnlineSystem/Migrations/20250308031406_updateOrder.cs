using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.RenameColumn(
                name: "DeliveryMethod",
                table: "Orders",
                newName: "PaymentMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Orders",
                newName: "DeliveryMethod");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, "Classic pizza with tomato sauce and mozzarella.", "MenuItemImages/Margherita Pizza.jpeg", true, false, "Margherita Pizza", 150m, 1 },
                    { 2, 1, "Spicy pepperoni with cheese on a crispy crust.", "MenuItemImages/Pepperoni Pizza.jpeg", true, false, "Pepperoni Pizza", 200m, 1 },
                    { 3, 1, "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/BBQ.jpeg", true, false, "BBQ Chicken Pizza", 220m, 1 },
                    { 4, 3, "Traditional spaghetti with beef sauce.", "MenuItemImages/Red Wine Bolognese.jpeg", true, false, "Spaghetti Bolognese", 145m, 1 },
                    { 5, 3, "Creamy Alfredo sauce with parmesan cheese.", "MenuItemImages/Fettuccine Alfredo.jpeg", true, false, "Fettuccine Alfredo", 170m, 1 },
                    { 6, 3, "Penne pasta in a spicy tomato sauce.", "MenuItemImages/Penne Arrabbiata.jpeg", true, false, "Penne Arrabbiata", 165m, 1 },
                    { 7, 6, "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", "MenuItemImages/Moheto.jpeg", true, false, "Mojito", 50m, 1 },
                    { 8, 2, "Beef patty with cheddar cheese and fresh lettuce.", "MenuItemImages/Classic Cheeseburger.jpeg", true, false, "Classic Cheeseburger", 175m, 2 },
                    { 9, 2, "Crispy bacon and melted cheese on a juicy patty.", "MenuItemImages/Bacon Burger.jpeg", true, false, "Bacon Burger", 180m, 2 },
                    { 10, 2, "Grilled mushrooms and Swiss cheese on a beef patty.", "MenuItemImages/Mushroom Swiss Burger.jpeg", true, false, "Mushroom Swiss Burger", 185m, 2 },
                    { 11, 6, "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", true, false, "V7 Pineapple ", 30m, 2 },
                    { 12, 4, "Crab, avocado, and cucumber wrapped in seaweed.", "MenuItemImages/California Roll.jpeg", true, false, "California Roll", 60m, 3 },
                    { 13, 4, "Tuna mixed with spicy mayo and wrapped in rice.", "MenuItemImages/Spicy Tuna Roll.jpeg", true, false, "Spicy Tuna Roll", 52m, 3 },
                    { 14, 4, "Eel, avocado, and cucumber topped with eel sauce.", "MenuItemImages/Dragon Roll.jpeg", true, false, "Dragon Roll", 55m, 3 },
                    { 15, 6, "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "MenuItemImages/v7_2.jpg", true, false, "Orange Juice", 60m, 3 },
                    { 16, 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", true, false, "Four Cheese Pizza", 185m, 4 },
                    { 17, 1, "Loaded with fresh veggies and tomato sauce.", "MenuItemImages/Hawaiian Pizza.jpeg", true, false, "Veggie Supreme", 180m, 4 },
                    { 18, 1, "Ham and pineapple on a cheesy base.", "MenuItemImages/Veggie Supreme.jpeg", true, false, "Hawaiian Pizza", 190m, 4 },
                    { 19, 6, "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "MenuItemImages/v7_2.jpg", true, false, "V7 Lemon", 25m, 4 },
                    { 20, 6, "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", "MenuItemImages/Moheto.jpeg", true, false, "Mojito", 55m, 4 },
                    { 21, 1, "Classic pizza with tomato sauce and mozzarella.", "MenuItemImages/Margherita Pizza.jpeg", true, false, "Margherita Pizza", 160m, 5 },
                    { 22, 1, "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/BBQ.jpeg", true, false, "BBQ Chicken Pizza", 220m, 5 },
                    { 23, 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", true, false, "Four Cheese Pizza", 185m, 5 },
                    { 24, 5, "Warm chocolate cake with a gooey center.", "MenuItemImages/Chocolate Lava Cake.jpeg", true, false, "Chocolate Lava Cake", 80m, 5 },
                    { 25, 6, "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", true, false, "V7 Pineapple ", 30m, 5 },
                    { 26, 6, "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "MenuItemImages/Oragne Juice.jpeg", true, false, "Orange Juice", 40m, 5 },
                    { 27, 5, "Rich chocolate cake with melted chocolate inside.", "MenuItemImages/Molten Chocolate Cake.jpeg", true, false, "Molten Chocolate Cake", 80m, 6 },
                    { 28, 5, "Fresh fruits on a creamy custard base.", "MenuItemImages/Fruit Tart.jpeg", true, false, "Fruit Tart", 70m, 6 },
                    { 29, 5, "Moist carrot cake with cream cheese frosting.", "MenuItemImages/Carrot Cake.jpeg", true, false, "Carrot Cake", 75m, 6 },
                    { 30, 5, "Creamy cheesecake with a graham cracker crust.", "MenuItemImages/Cheesecake.jpeg", true, false, "Cheesecake", 90m, 6 },
                    { 31, 5, "Classic Italian coffee-flavored dessert.", "MenuItemImages/Tiramisu.jpeg", true, false, "Tiramisu", 95m, 6 },
                    { 32, 6, "A refreshing, chilled coffee drink with bold flavors and a smooth finish.", "MenuItemImages/Iced Coffee.jpeg", true, false, "Ice Coffe", 120m, 6 },
                    { 33, 6, "A creamy, sweet blend of fresh strawberries and milk, topped with a smooth, velvety finish.", "MenuItemImages/Strawberry Milkshake.jpeg", true, false, "Strwberry Milkshake", 100m, 6 }
                });
        }
    }
}
