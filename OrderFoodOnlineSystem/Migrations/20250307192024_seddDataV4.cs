using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seddDataV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "CategoryImages/Drink Category.jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "MenuItemImages/Margherita Pizza.jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "MenuItemImages/Pepperoni Pizza.jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "MenuItemImages/BBQ.jpeg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/Red Wine Bolognese.jpeg", 145m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/Fettuccine Alfredo.jpeg", 170m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/Penne Arrabbiata.jpeg", 165m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", "MenuItemImages/Moheto.jpeg", "Moheto", 80m, 1 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Beef patty with cheddar cheese and fresh lettuce.", "MenuItemImages/Classic Cheeseburger.jpeg", "Classic Cheeseburger", 175m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Crispy bacon and melted cheese on a juicy patty.", "MenuItemImages/Bacon Burger.jpeg", "Bacon Burger", 180m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 2, "Grilled mushrooms and Swiss cheese on a beef patty.", "MenuItemImages/Mushroom Swiss Burger.jpeg", "Mushroom Swiss Burger", 185m, 2 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 30m, 2 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Crab, avocado, and cucumber wrapped in seaweed.", "MenuItemImages/California Roll.jpeg", "California Roll", 60m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 4, "Tuna mixed with spicy mayo and wrapped in rice.", "MenuItemImages/Spicy Tuna Roll.jpeg", "Spicy Tuna Roll", 52m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 4, "Eel, avocado, and cucumber topped with eel sauce.", "MenuItemImages/Dragon Roll.jpeg", "Dragon Roll", 55m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "MenuItemImages/v7_2.jpg", "V7 Lemon", 25m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", "Four Cheese Pizza", 185m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Loaded with fresh veggies and tomato sauce.", "MenuItemImages/Hawaiian Pizza.jpeg", "Veggie Supreme", 180m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Ham and pineapple on a cheesy base.", "MenuItemImages/Veggie Supreme.jpeg", "Hawaiian Pizza", 190m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", "MenuItemImages/v7_2.jpg", "V7 Lemon", 25m, 4 });

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
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/BBQ.jpeg", "BBQ Chicken Pizza", 220m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/Four Cheese Pizza.jpeg", "Four Cheese Pizza", 185m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Warm chocolate cake with a gooey center.", "MenuItemImages/Chocolate Lava Cake.jpeg", "Chocolate Lava Cake", 80m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 6, "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", "MenuItemImages/v7.jpg", "V7 Pineapple ", 30m, 5 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 25, 6, "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", "MenuItemImages/Oragne Juice.jpeg", true, false, "Orange Juice", 40m, 5 },
                    { 26, 5, "Rich chocolate cake with melted chocolate inside.", "MenuItemImages/Molten Chocolate Cake.jpeg", true, false, "Molten Chocolate Cake", 80m, 6 },
                    { 27, 5, "Fresh fruits on a creamy custard base.", "MenuItemImages/Fruit Tart.jpeg", true, false, "Fruit Tart", 70m, 6 },
                    { 28, 5, "Moist carrot cake with cream cheese frosting.", "MenuItemImages/Carrot Cake.jpeg", true, false, "Carrot Cake", 75m, 6 },
                    { 29, 5, "Creamy cheesecake with a graham cracker crust.", "MenuItemImages/Cheesecake.jpeg", true, false, "Cheesecake", 90m, 6 },
                    { 30, 5, "Classic Italian coffee-flavored dessert.", "MenuItemImages/Tiramisu.jpeg", true, false, "Tiramisu", 95m, 6 },
                    { 31, 6, "A refreshing, chilled coffee drink with bold flavors and a smooth finish.", "MenuItemImages/Iced Coffee.jpeg", true, false, "Ice Coffe", 120m, 6 },
                    { 32, 6, "A creamy, sweet blend of fresh strawberries and milk, topped with a smooth, velvety finish.", "MenuItemImages/Strawberry Milkshake.jpeg", true, false, "Strwberry Milkshake", 100m, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A popular Egyptian burger chain known for its real beef burgers and bold flavors.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ginger offers authentic Japanese cuisine and fresh sushi in a stylish setting.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Papa John’s is a popular American pizza chain known for fresh ingredients and garlic sauce.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A global restaurant known for pan pizzas, pasta, and sides.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "A cozy spot serving irresistible desserts and sweet treats.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "CategoryImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "MenuItemImages/");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 9.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 11.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "MenuItemImages/", 10.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 2, "Beef patty with cheddar cheese and fresh lettuce.", "MenuItemImages/", "Classic Cheeseburger", 7.99m, 2 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Crispy bacon and melted cheese on a juicy patty.", "MenuItemImages/", "Bacon Burger", 9.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Grilled mushrooms and Swiss cheese on a beef patty.", "MenuItemImages/", "Mushroom Swiss Burger", 8.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 4, "Crab, avocado, and cucumber wrapped in seaweed.", "MenuItemImages/", "California Roll", 12.99m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 4, "Tuna mixed with spicy mayo and wrapped in rice.", "MenuItemImages/", "Spicy Tuna Roll", 14.99m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Eel, avocado, and cucumber topped with eel sauce.", "MenuItemImages/", "Dragon Roll", 15.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "MenuItemImages/", "Four Cheese Pizza", 11.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Loaded with fresh veggies and tomato sauce.", "MenuItemImages/", "Veggie Supreme", 10.49m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Ham and pineapple on a cheesy base.", "MenuItemImages/", "Hawaiian Pizza", 9.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Classic pizza with tomato sauce and mozzarella.", "MenuItemImages/", "Margherita Pizza", 8.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Spicy pepperoni with cheese on a crispy crust.", "MenuItemImages/", "Pepperoni Pizza", 10.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "BBQ sauce with grilled chicken and red onions.", "MenuItemImages/", "BBQ Chicken Pizza", 12.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Warm chocolate cake with a gooey center.", "MenuItemImages/", "Chocolate Lava Cake", 6.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Rich chocolate cake with melted chocolate inside.", "MenuItemImages/", "Molten Chocolate Cake", 6.99m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Fresh fruits on a creamy custard base.", "MenuItemImages/", "Fruit Tart", 7.49m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Moist carrot cake with cream cheese frosting.", "MenuItemImages/", "Carrot Cake", 6.99m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Creamy cheesecake with a graham cracker crust.", "MenuItemImages/", "Cheesecake", 7.99m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Classic Italian coffee-flavored dessert.", "MenuItemImages/", "Tiramisu", 8.49m, 6 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A popular Egyptian burger chain known for its 100% real beef burgers, bold flavors, and high-quality ingredients.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ginger offers a delightful fusion of authentic Japanese cuisine and fresh, expertly crafted sushi in a stylish ambiance.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Papa John’s Pizza is a popular American pizza chain known for its fresh ingredients and signature garlic sauce.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A globally renowned restaurant serving delicious pan pizzas, pasta, and sides in a casual, family-friendly setting.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "A haven for those with a sweet tooth, offering the best desserts.");
        }
    }
}
