using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d9c265-64a3-4520-9b0f-164d5bfc6afa",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "admin1@gmail.com", "ADMIN1@GMAIL.COM", "ADMIN1@GMAIL.COM", "AQAAAAIAAYagAAAAEGs3LRYykr9WajXOK4Y11VLGHF14VzdhhAnyRd0aAgKTpCoR5r2nZlzuRr/6p2FDLQ==", "admin1@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "007e8fc5-4751-4514-8d48-842fe1478097", 0, "51266c8c-079d-4eed-abc6-9f6412ef2af4", "manager5@gmail.com", true, true, null, "MANAGER5@GMAIL.COM", "MANAGER5@GMAIL.COM", "AQAAAAIAAYagAAAAEJsFxPtWwJrhdHsbWzPv2mlJq6gkqkBLImRbB95k6qCtt0s18sCaIF0evY6O3McY+g==", null, false, "3e674cdc-01bd-42e1-afc8-4b4e4564be82", false, "manager5@gmail.com" },
                    { "19116f65-9e11-4b13-81b0-0b5a2f224fda", 0, "b92ecee8-0a51-4970-9ad2-db4bb66e244b", "manager6@gmail.com", true, true, null, "MANAGER6@GMAIL.COM", "MANAGER6@GMAIL.COM", "AQAAAAIAAYagAAAAEF5jzaGrwmpeB+afU4J3+f0hwmMkB7mRzui/d/qxsPUL3Q53aLr2p2wvSddOBBtgNg==", null, false, "7248531d-eaa3-4ddc-86f3-9f303e1a3874", false, "manager6@gmail.com" },
                    { "249116a4-54c9-4928-8de1-8c1c1b921695", 0, "a7ed6003-b034-4c31-8d11-23b45cf730fe", "manager4@gmail.com", true, true, null, "MANAGER4@GMAIL.COM", "MANAGER4@GMAIL.COM", "AQAAAAIAAYagAAAAEDuvofy/t/2NZIbiJ9n9mvM1uHuOB8ImAiLFjbhN/j3TjV4o3SkE8v3usBeLaeXtRA==", null, false, "91593a72-cd2d-4902-9e33-07a5a9ef9b38", false, "manager4@gmail.com" },
                    { "823d613d-51f5-44d0-af8c-98a5dcf1e070", 0, "8236404b-5356-422e-afd6-b54776a3e3dc", "manager2@gmail.com", true, true, null, "MANAGER2@GMAIL.COM", "MANAGER2@GMAIL.COM", "AQAAAAIAAYagAAAAEEzzzh6xvgWC74o9rwDkUUJfdbz/AEw6lHJtUWqjVUf1lAt2PCqqPjSfOZZeKFevMg==", null, false, "1ab93e8b-f2d8-459c-aa16-6d30c2cb47fd", false, "manager2@gmail.com" },
                    { "cfcc4d4f-598d-48d7-985c-973ade5c4a85", 0, "d8d751d6-f58f-4a15-b713-c3cd581cb551", "manager1@gmail.com", true, true, null, "MANAGER1@GMAIL.COM", "MANAGER1@GMAIL.COM", "AQAAAAIAAYagAAAAEKIH5mf5ukdcyNhy9cGyI3rO6aflvTikWXkyEzQ1xTUOmb8Y1Dc2W1i8XEHkvac9Sg==", null, false, "e1efa798-3d21-492a-bd10-56f58e015edd", false, "manager1@gmail.com" },
                    { "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f", 0, "bd8753f1-4f94-4be3-b63a-17bc2d7635a3", "manager3@gmail.com", true, true, null, "MANAGER3@GMAIL.COM", "MANAGER3@GMAIL.COM", "AQAAAAIAAYagAAAAEOoXQKojc6ZSiZyZtbTZz5JsnvW4dKBW5KUfkTb08aAAcysSB2T/KfwZiFoUEeIISQ==", null, false, "d8bed259-7a1b-4cfa-8368-dca899b2029a", false, "manager3@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "https://example.com/pizza.jpg", false, "Pizza" },
                    { 2, "https://example.com/burgers.jpg", false, "Burgers" },
                    { 3, "https://example.com/pasta.jpg", false, "Pasta" },
                    { 4, "https://example.com/sushi.jpg", false, "Sushi" },
                    { 5, "https://example.com/desserts.jpg", false, "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d6285ef2-cf06-475c-914f-119737485d65", "007e8fc5-4751-4514-8d48-842fe1478097" },
                    { "d6285ef2-cf06-475c-914f-119737485d65", "19116f65-9e11-4b13-81b0-0b5a2f224fda" },
                    { "d6285ef2-cf06-475c-914f-119737485d65", "249116a4-54c9-4928-8de1-8c1c1b921695" },
                    { "d6285ef2-cf06-475c-914f-119737485d65", "823d613d-51f5-44d0-af8c-98a5dcf1e070" },
                    { "d6285ef2-cf06-475c-914f-119737485d65", "cfcc4d4f-598d-48d7-985c-973ade5c4a85" },
                    { "d6285ef2-cf06-475c-914f-119737485d65", "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantManagers",
                columns: new[] { "Id", "AccountId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "cfcc4d4f-598d-48d7-985c-973ade5c4a85", false, "Manager One" },
                    { 2, "823d613d-51f5-44d0-af8c-98a5dcf1e070", false, "Manager Two" },
                    { 3, "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f", false, "Manager Three" },
                    { 4, "249116a4-54c9-4928-8de1-8c1c1b921695", false, "Manager Four" },
                    { 5, "007e8fc5-4751-4514-8d48-842fe1478097", false, "Manager Five" },
                    { 6, "19116f65-9e11-4b13-81b0-0b5a2f224fda", false, "Manager Six" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "DateColse", "DateOpen", "Description", "ImageUrl", "IsDeleted", "IsOpen", "Name", "RestaurantManagerId" },
                values: new object[,]
                {
                    { 1, new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0), "A place for delicious and freshly cooked meals.", "https://example.com/tastybites.jpg", false, true, "Tasty Bites", 1 },
                    { 2, new TimeOnly(22, 0, 0), new TimeOnly(10, 0, 0), "Experience a wide range of gourmet flavors.", "https://example.com/urbandiner.jpg", false, true, "Urban Diner", 2 },
                    { 3, new TimeOnly(20, 0, 0), new TimeOnly(8, 0, 0), "Fresh organic meals with a touch of perfection.", "https://example.com/greenfork.jpg", false, true, "The Green Fork", 3 },
                    { 4, new TimeOnly(23, 30, 0), new TimeOnly(11, 0, 0), "A paradise for pizza lovers, offering authentic flavors.", "https://example.com/pizzaparadise.jpg", false, true, "Pizza Paradise", 4 },
                    { 5, new TimeOnly(22, 0, 0), new TimeOnly(10, 0, 0), "The ultimate haven for juicy and delicious burgers.", "https://example.com/burgerhaven.jpg", false, true, "Burger Haven", 5 },
                    { 6, new TimeOnly(21, 0, 0), new TimeOnly(9, 0, 0), "A haven for those with a sweet tooth, offering the best desserts.", "https://example.com/sweetdelights.jpg", false, true, "Sweet Delights", 6 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, "Classic pizza with tomato sauce and mozzarella.", "https://example.com/margherita.jpg", true, false, "Margherita Pizza", 8.99m, 1 },
                    { 2, 1, "Spicy pepperoni with cheese on a crispy crust.", "https://example.com/pepperoni.jpg", true, false, "Pepperoni Pizza", 10.99m, 1 },
                    { 3, 1, "BBQ sauce with grilled chicken and red onions.", "https://example.com/bbqchicken.jpg", true, false, "BBQ Chicken Pizza", 12.99m, 1 },
                    { 4, 3, "Traditional spaghetti with beef sauce.", "https://example.com/spaghetti.jpg", true, false, "Spaghetti Bolognese", 9.99m, 1 },
                    { 5, 3, "Creamy Alfredo sauce with parmesan cheese.", "https://example.com/fettuccine.jpg", true, false, "Fettuccine Alfredo", 11.99m, 1 },
                    { 6, 3, "Penne pasta in a spicy tomato sauce.", "https://example.com/penne.jpg", true, false, "Penne Arrabbiata", 10.49m, 1 },
                    { 7, 2, "Beef patty with cheddar cheese and fresh lettuce.", "https://example.com/cheeseburger.jpg", true, false, "Classic Cheeseburger", 7.99m, 2 },
                    { 8, 2, "Crispy bacon and melted cheese on a juicy patty.", "https://example.com/baconburger.jpg", true, false, "Bacon Burger", 9.49m, 2 },
                    { 9, 2, "Grilled mushrooms and Swiss cheese on a beef patty.", "https://example.com/mushroomswiss.jpg", true, false, "Mushroom Swiss Burger", 8.99m, 2 },
                    { 10, 4, "Crab, avocado, and cucumber wrapped in seaweed.", "https://example.com/californiaroll.jpg", true, false, "California Roll", 12.99m, 3 },
                    { 11, 4, "Tuna mixed with spicy mayo and wrapped in rice.", "https://example.com/spicytuna.jpg", true, false, "Spicy Tuna Roll", 14.99m, 3 },
                    { 12, 4, "Eel, avocado, and cucumber topped with eel sauce.", "https://example.com/dragonroll.jpg", true, false, "Dragon Roll", 15.49m, 3 },
                    { 13, 5, "Warm chocolate cake with a gooey center.", "https://example.com/lavacake.jpg", true, false, "Chocolate Lava Cake", 6.99m, 3 },
                    { 14, 5, "Creamy cheesecake with a graham cracker crust.", "https://example.com/cheesecake.jpg", true, false, "Cheesecake", 7.99m, 3 },
                    { 15, 5, "Classic Italian coffee-flavored dessert.", "https://example.com/tiramisu.jpg", true, false, "Tiramisu", 8.49m, 3 },
                    { 16, 1, "Mozzarella, cheddar, parmesan, and gorgonzola.", "https://example.com/fourcheese.jpg", true, false, "Four Cheese Pizza", 11.99m, 4 },
                    { 17, 1, "Loaded with fresh veggies and tomato sauce.", "https://example.com/veggiepizza.jpg", true, false, "Veggie Supreme", 10.49m, 4 },
                    { 18, 1, "Ham and pineapple on a cheesy base.", "https://example.com/hawaiian.jpg", true, false, "Hawaiian Pizza", 9.99m, 4 },
                    { 19, 2, "Two beef patties with crispy bacon.", "https://example.com/doublebacon.jpg", true, false, "Double Bacon Cheeseburger", 11.49m, 5 },
                    { 20, 2, "Tangy BBQ sauce with ranch and crispy onions.", "https://example.com/bbqranch.jpg", true, false, "BBQ Ranch Burger", 9.99m, 5 },
                    { 21, 2, "Juicy patty topped with melted blue cheese.", "https://example.com/bluecheese.jpg", true, false, "Blue Cheese Burger", 10.99m, 5 },
                    { 22, 5, "Rich chocolate cake with melted chocolate inside.", "https://example.com/moltenchocolate.jpg", true, false, "Molten Chocolate Cake", 6.99m, 6 },
                    { 23, 5, "Fresh fruits on a creamy custard base.", "https://example.com/fruittart.jpg", true, false, "Fruit Tart", 7.49m, 6 },
                    { 24, 5, "Moist carrot cake with cream cheese frosting.", "https://example.com/carrotcake.jpg", true, false, "Carrot Cake", 6.99m, 6 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, false },
                    { 3, 1, false },
                    { 2, 2, false },
                    { 4, 3, false },
                    { 5, 3, false },
                    { 1, 4, false },
                    { 2, 5, false },
                    { 5, 6, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "007e8fc5-4751-4514-8d48-842fe1478097" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "19116f65-9e11-4b13-81b0-0b5a2f224fda" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "249116a4-54c9-4928-8de1-8c1c1b921695" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "823d613d-51f5-44d0-af8c-98a5dcf1e070" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "cfcc4d4f-598d-48d7-985c-973ade5c4a85" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6285ef2-cf06-475c-914f-119737485d65", "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f" });

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
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007e8fc5-4751-4514-8d48-842fe1478097");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19116f65-9e11-4b13-81b0-0b5a2f224fda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "249116a4-54c9-4928-8de1-8c1c1b921695");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "823d613d-51f5-44d0-af8c-98a5dcf1e070");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc4d4f-598d-48d7-985c-973ade5c4a85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d9c265-64a3-4520-9b0f-164d5bfc6afa",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "admin@gmail.com", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEP+ErsHGwsjLiP/LeNa9G+xKOOemIaOnBdvBGXNFiaMcQBaiEgeYqZXw19IN2yfGfQ==", "admin@gmail.com" });
        }
    }
}
