using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "CategoryImages/pizza.jpeg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "CategoryImages/Burger.jpeg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "CategoryImages/pasta.jpeg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "CategoryImages/Sushi.jpeg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "CategoryImages/shop-37.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "https://example.com/fourcheese.jpg", "Four Cheese Pizza", 11.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Loaded with fresh veggies and tomato sauce.", "https://example.com/veggiepizza.jpg", "Veggie Supreme", 10.49m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Ham and pineapple on a cheesy base.", "https://example.com/hawaiian.jpg", "Hawaiian Pizza", 9.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Classic pizza with tomato sauce and mozzarella.", "https://example.com/margherita.jpg", "Margherita Pizza", 8.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Spicy pepperoni with cheese on a crispy crust.", "https://example.com/pepperoni.jpg", "Pepperoni Pizza", 10.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "BBQ sauce with grilled chicken and red onions.", "https://example.com/bbqchicken.jpg", "BBQ Chicken Pizza", 12.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 5, "Warm chocolate cake with a gooey center.", "https://example.com/lavacake.jpg", "Chocolate Lava Cake", 6.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Rich chocolate cake with melted chocolate inside.", "https://example.com/moltenchocolate.jpg", "Molten Chocolate Cake", 6.99m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Fresh fruits on a creamy custard base.", "https://example.com/fruittart.jpg", "Fruit Tart", 7.49m, 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Moist carrot cake with cream cheese frosting.", "https://example.com/carrotcake.jpg", "Carrot Cake" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Creamy cheesecake with a graham cracker crust.", "https://example.com/cheesecake.jpg", "Cheesecake", 7.99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Classic Italian coffee-flavored dessert.", "https://example.com/tiramisu.jpg", "Tiramisu", 8.49m });

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 5, false },
                    { 5, 5, false }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A stylish and modern restaurant serving delicious pizza, pasta, and grilled meals in a cozy ambiance.", "ResturantImages/Tasty bites.PNG" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "A popular Egyptian burger chain known for its 100% real beef burgers, bold flavors, and high-quality ingredients.", "ResturantImages/Burger King.jpeg", "Burger King" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Ginger Restaurant & Sushi Bar offers a delightful fusion of authentic Japanese cuisine and fresh, expertly crafted sushi in a stylish ambiance.", "ResturantImages/Ginger.JPG", "Ginger" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Papa John’s Pizza is a popular American pizza chain known for its fresh ingredients and signature garlic sauce.", "ResturantImages/papaJohn.jpeg", "PaPa John" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "A globally renowned restaurant serving delicious pan pizzas, pasta, and sides in a casual, family-friendly setting.", "ResturantImages/PizzaHut.jpeg", "Pizza Hut" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryFees", "ImageUrl" },
                values: new object[] { 25m, "ResturantImages/Sweet Delight.PNG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/pizza.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/burgers.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/pasta.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/sushi.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/desserts.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Warm chocolate cake with a gooey center.", "https://example.com/lavacake.jpg", "Chocolate Lava Cake", 6.99m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Creamy cheesecake with a graham cracker crust.", "https://example.com/cheesecake.jpg", "Cheesecake", 7.99m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 5, "Classic Italian coffee-flavored dessert.", "https://example.com/tiramisu.jpg", "Tiramisu", 8.49m, 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Mozzarella, cheddar, parmesan, and gorgonzola.", "https://example.com/fourcheese.jpg", "Four Cheese Pizza", 11.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Loaded with fresh veggies and tomato sauce.", "https://example.com/veggiepizza.jpg", "Veggie Supreme", 10.49m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Ham and pineapple on a cheesy base.", "https://example.com/hawaiian.jpg", "Hawaiian Pizza", 9.99m, 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "Two beef patties with crispy bacon.", "https://example.com/doublebacon.jpg", "Double Bacon Cheeseburger", 11.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 2, "Tangy BBQ sauce with ranch and crispy onions.", "https://example.com/bbqranch.jpg", "BBQ Ranch Burger", 9.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { 2, "Juicy patty topped with melted blue cheese.", "https://example.com/bluecheese.jpg", "Blue Cheese Burger", 10.99m, 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Rich chocolate cake with melted chocolate inside.", "https://example.com/moltenchocolate.jpg", "Molten Chocolate Cake" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Fresh fruits on a creamy custard base.", "https://example.com/fruittart.jpg", "Fruit Tart", 7.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Moist carrot cake with cream cheese frosting.", "https://example.com/carrotcake.jpg", "Carrot Cake", 6.99m });

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[,]
                {
                    { 5, 3, false },
                    { 2, 5, false }
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A place for delicious and freshly cooked meals.", "https://example.com/tastybites.jpg" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Experience a wide range of gourmet flavors.", "https://example.com/urbandiner.jpg", "Urban Diner" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Fresh organic meals with a touch of perfection.", "https://example.com/greenfork.jpg", "The Green Fork" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "A paradise for pizza lovers, offering authentic flavors.", "https://example.com/pizzaparadise.jpg", "Pizza Paradise" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "The ultimate haven for juicy and delicious burgers.", "https://example.com/burgerhaven.jpg", "Burger Haven" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeliveryFees", "ImageUrl" },
                values: new object[] { 0m, "https://example.com/sweetdelights.jpg" });
        }
    }
}
